using System.IO;
using System.IO.Compression;

namespace VarContentSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SelectPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    tbx_SearchPath.Text = selectedFolder;
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string folderPath = tbx_SearchPath.Text.Trim();
            string partialFileName = txb_FileName.Text.Trim();

            if (string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(partialFileName))
            {
                MessageBox.Show("请输入合法的文件路径和文件名。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("搜索路径不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 清空现有的 ListView
            lsv_SearchResult.Items.Clear();

            // 搜索并显示结果
            List<string[]> searchResults = SearchFileInZips(folderPath, partialFileName);

            if (searchResults.Count == 0)
            {
                MessageBox.Show("没有找到！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 创建包含序号和搜索结果的新列表
                List<List<string>> numberedResults = new List<List<string>>();
                for (int i = 0; i < searchResults.Count; i++)
                {
                    List<string> numberedResult = new List<string>();
                    numberedResult.Add((i + 1).ToString()); // 添加序号
                    numberedResult.AddRange(searchResults[i]); // 添加搜索结果
                    numberedResults.Add(numberedResult);
                }

                foreach (List<string> result in numberedResults)
                {
                    ListViewItem item = new ListViewItem(result.ToArray());
                    lsv_SearchResult.Items.Add(item);
                    lsv_SearchResult.Refresh();
                }
            }
        }
        static List<string[]> SearchFileInZips(string folderPath, string partialFileName)
        {
            List<string[]> output = new List<string[]>();

            string[] zipFiles = Directory.GetFiles(folderPath, "*.var", SearchOption.AllDirectories);

            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = Path.Combine(programDirectory, "log.txt");

            Parallel.ForEach(zipFiles, (zipFile) =>
            {
                try
                {
                    using (ZipArchive archive = ZipFile.OpenRead(zipFile))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (Path.GetFileName(entry.FullName).IndexOf(partialFileName, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                string fileName = Path.GetFileName(entry.FullName);
                                string lastModified = entry.LastWriteTime.ToString("yyyy-MM-dd HH");
                                string fileSize = ConvertBytesToMegabytes(new FileInfo(zipFile).Length).ToString("0.##") + "MB";
                                string relativePath = entry.FullName.Substring(entry.FullName.IndexOf('/') + 1); // 获取压缩包内的相对路径
                                string[] result = { fileName, zipFile, lastModified, fileSize, relativePath };
                                lock (output)
                                {
                                    output.Add(result);
                                }
                                break;
                            }
                        }
                    }
                }
                catch (InvalidDataException ex)
                {
                    // Handle the case when the ZIP file format is corrupted
                    string errorMessage = "错误: Zip文件已损坏：" + ex.Message + "路径为：" + zipFile.ToString() + "\r\n";
                    LogError(logFilePath, errorMessage);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions if necessary
                    string errorMessage = "发生错误：" + ex.Message + "路径为：" +zipFile.ToString() + "\r\n";
                    LogError(logFilePath, errorMessage);
                }
            });

            return output;
        }

        private void lsv_SearchResult_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem clickedItem = listView.SelectedItems[0];
                string zipFilePath = clickedItem.SubItems[2].Text;
                // 使用默认方式打开文件
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = zipFilePath,
                    UseShellExecute = true
                });
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        static void LogError(string logFilePath, string errorMessage)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(errorMessage);
            }
        }
    }
}

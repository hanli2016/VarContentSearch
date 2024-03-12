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
                MessageBox.Show("������Ϸ����ļ�·�����ļ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("����·�������ڡ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ������е� ListView
            lsv_SearchResult.Items.Clear();

            // ��������ʾ���
            List<string[]> searchResults = SearchFileInZips(folderPath, partialFileName);

            if (searchResults.Count == 0)
            {
                MessageBox.Show("û���ҵ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ����������ź�������������б�
                List<List<string>> numberedResults = new List<List<string>>();
                for (int i = 0; i < searchResults.Count; i++)
                {
                    List<string> numberedResult = new List<string>();
                    numberedResult.Add((i + 1).ToString()); // ������
                    numberedResult.AddRange(searchResults[i]); // ����������
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
                                string relativePath = entry.FullName.Substring(entry.FullName.IndexOf('/') + 1); // ��ȡѹ�����ڵ����·��
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
                    string errorMessage = "����: Zip�ļ����𻵣�" + ex.Message + "·��Ϊ��" + zipFile.ToString() + "\r\n";
                    LogError(logFilePath, errorMessage);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions if necessary
                    string errorMessage = "��������" + ex.Message + "·��Ϊ��" +zipFile.ToString() + "\r\n";
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
                // ʹ��Ĭ�Ϸ�ʽ���ļ�
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

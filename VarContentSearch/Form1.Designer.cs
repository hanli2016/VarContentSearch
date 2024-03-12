namespace VarContentSearch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            btn_Search = new Button();
            label2 = new Label();
            txb_FileName = new TextBox();
            label1 = new Label();
            tbx_SearchPath = new TextBox();
            btn_SelectPath = new Button();
            lsv_SearchResult = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btn_Search);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txb_FileName);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(tbx_SearchPath);
            splitContainer1.Panel1.Controls.Add(btn_SelectPath);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lsv_SearchResult);
            splitContainer1.Size = new Size(1384, 861);
            splitContainer1.SplitterDistance = 78;
            splitContainer1.TabIndex = 9;
            // 
            // btn_Search
            // 
            btn_Search.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Search.Location = new Point(1033, 14);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(79, 47);
            btn_Search.TabIndex = 0;
            btn_Search.Text = "搜索";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += btn_Search_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(36, 27);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 7;
            label2.Text = "搜索路径:";
            // 
            // txb_FileName
            // 
            txb_FileName.Location = new Point(844, 26);
            txb_FileName.Name = "txb_FileName";
            txb_FileName.Size = new Size(152, 23);
            txb_FileName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(748, 28);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 6;
            label1.Text = "搜索文件名:";
            // 
            // tbx_SearchPath
            // 
            tbx_SearchPath.Location = new Point(113, 26);
            tbx_SearchPath.Name = "tbx_SearchPath";
            tbx_SearchPath.Size = new Size(446, 23);
            tbx_SearchPath.TabIndex = 3;
            // 
            // btn_SelectPath
            // 
            btn_SelectPath.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SelectPath.Location = new Point(577, 14);
            btn_SelectPath.Name = "btn_SelectPath";
            btn_SelectPath.Size = new Size(85, 47);
            btn_SelectPath.TabIndex = 4;
            btn_SelectPath.Text = "选择路径";
            btn_SelectPath.UseVisualStyleBackColor = true;
            btn_SelectPath.Click += btn_SelectPath_Click;
            // 
            // lsv_SearchResult
            // 
            lsv_SearchResult.Alignment = ListViewAlignment.Default;
            lsv_SearchResult.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lsv_SearchResult.Dock = DockStyle.Fill;
            lsv_SearchResult.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lsv_SearchResult.FullRowSelect = true;
            lsv_SearchResult.Location = new Point(0, 0);
            lsv_SearchResult.MultiSelect = false;
            lsv_SearchResult.Name = "lsv_SearchResult";
            lsv_SearchResult.Size = new Size(1384, 779);
            lsv_SearchResult.TabIndex = 3;
            lsv_SearchResult.UseCompatibleStateImageBehavior = false;
            lsv_SearchResult.View = View.Details;
            lsv_SearchResult.DoubleClick += lsv_SearchResult_DoubleClick;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "序号";
            columnHeader6.Width = 50;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "文件名";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "位置";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 600;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "修改时间";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "大小";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "相对路径";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 400;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 861);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "VarContentSearch";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btn_Search;
        private Label label2;
        private TextBox txb_FileName;
        private Label label1;
        private TextBox tbx_SearchPath;
        private Button btn_SelectPath;
        private ListView lsv_SearchResult;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
    }
}

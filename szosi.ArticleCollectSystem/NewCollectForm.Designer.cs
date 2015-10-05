namespace szosi.ArticleCollectSystem
{
    partial class NewCollectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选择网站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SiteCombox = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lv_ArticleTitleList = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_UpdateAndSave = new System.Windows.Forms.Button();
            this.txt_PublishDate = new System.Windows.Forms.TextBox();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pro_CollectProcess = new System.Windows.Forms.ProgressBar();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Collect = new System.Windows.Forms.Button();
            this.lab_statu = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择网站ToolStripMenuItem,
            this.menu_SiteCombox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1111, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选择网站ToolStripMenuItem
            // 
            this.选择网站ToolStripMenuItem.Name = "选择网站ToolStripMenuItem";
            this.选择网站ToolStripMenuItem.Size = new System.Drawing.Size(65, 26);
            this.选择网站ToolStripMenuItem.Text = "选择网站";
            // 
            // menu_SiteCombox
            // 
            this.menu_SiteCombox.Name = "menu_SiteCombox";
            this.menu_SiteCombox.Size = new System.Drawing.Size(200, 26);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_ArticleTitleList);
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 694);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lv_ArticleTitleList
            // 
            this.lv_ArticleTitleList.AutoArrange = false;
            this.lv_ArticleTitleList.CheckBoxes = true;
            this.lv_ArticleTitleList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_ArticleTitleList.FullRowSelect = true;
            this.lv_ArticleTitleList.GridLines = true;
            this.lv_ArticleTitleList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ArticleTitleList.Location = new System.Drawing.Point(6, 12);
            this.lv_ArticleTitleList.Name = "lv_ArticleTitleList";
            this.lv_ArticleTitleList.Size = new System.Drawing.Size(297, 676);
            this.lv_ArticleTitleList.TabIndex = 0;
            this.lv_ArticleTitleList.UseCompatibleStateImageBehavior = false;
            this.lv_ArticleTitleList.View = System.Windows.Forms.View.Details;
            this.lv_ArticleTitleList.SelectedIndexChanged += new System.EventHandler(this.lv_ArticleTitleList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Controls.Add(this.btn_UpdateAndSave);
            this.groupBox2.Controls.Add(this.txt_PublishDate);
            this.groupBox2.Controls.Add(this.txt_Title);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(315, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 646);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(83, 90);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(701, 517);
            this.webBrowser1.TabIndex = 7;
            // 
            // btn_UpdateAndSave
            // 
            this.btn_UpdateAndSave.Location = new System.Drawing.Point(709, 613);
            this.btn_UpdateAndSave.Name = "btn_UpdateAndSave";
            this.btn_UpdateAndSave.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateAndSave.TabIndex = 6;
            this.btn_UpdateAndSave.Text = "修改保存";
            this.btn_UpdateAndSave.UseVisualStyleBackColor = true;
            this.btn_UpdateAndSave.Click += new System.EventHandler(this.btn_UpdateAndSave_Click);
            // 
            // txt_PublishDate
            // 
            this.txt_PublishDate.Location = new System.Drawing.Point(83, 54);
            this.txt_PublishDate.Name = "txt_PublishDate";
            this.txt_PublishDate.Size = new System.Drawing.Size(701, 21);
            this.txt_PublishDate.TabIndex = 4;
            // 
            // txt_Title
            // 
            this.txt_Title.Location = new System.Drawing.Point(83, 22);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(701, 21);
            this.txt_Title.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "文章正文:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "发布日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题:";
            // 
            // pro_CollectProcess
            // 
            this.pro_CollectProcess.Location = new System.Drawing.Point(315, 697);
            this.pro_CollectProcess.Name = "pro_CollectProcess";
            this.pro_CollectProcess.Size = new System.Drawing.Size(703, 23);
            this.pro_CollectProcess.TabIndex = 3;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(1024, 697);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Collect
            // 
            this.btn_Collect.Location = new System.Drawing.Point(1024, 0);
            this.btn_Collect.Name = "btn_Collect";
            this.btn_Collect.Size = new System.Drawing.Size(75, 30);
            this.btn_Collect.TabIndex = 5;
            this.btn_Collect.Text = "采集";
            this.btn_Collect.UseVisualStyleBackColor = true;
            this.btn_Collect.Click += new System.EventHandler(this.btn_Collect_Click);
            // 
            // lab_statu
            // 
            this.lab_statu.AutoSize = true;
            this.lab_statu.Location = new System.Drawing.Point(321, 682);
            this.lab_statu.Name = "lab_statu";
            this.lab_statu.Size = new System.Drawing.Size(0, 12);
            this.lab_statu.TabIndex = 6;
            // 
            // NewCollectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 735);
            this.Controls.Add(this.lab_statu);
            this.Controls.Add(this.btn_Collect);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.pro_CollectProcess);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NewCollectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建采集";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择网站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox menu_SiteCombox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lv_ArticleTitleList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_UpdateAndSave;
        private System.Windows.Forms.TextBox txt_PublishDate;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pro_CollectProcess;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Collect;
        private System.Windows.Forms.Label lab_statu;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
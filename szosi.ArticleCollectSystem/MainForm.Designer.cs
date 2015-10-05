namespace szosi.ArticleCollectSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_NewCollect = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Classify = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lv_ArticleTitleList = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_DelArticle = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_UpdateArticle = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.main_webBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_MainMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1206, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_MainMenu
            // 
            this.menu_MainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_NewCollect,
            this.menu_Classify,
            this.menu_Setting,
            this.menu_About});
            this.menu_MainMenu.Name = "menu_MainMenu";
            this.menu_MainMenu.Size = new System.Drawing.Size(41, 20);
            this.menu_MainMenu.Text = "菜单";
            // 
            // menu_NewCollect
            // 
            this.menu_NewCollect.Name = "menu_NewCollect";
            this.menu_NewCollect.Size = new System.Drawing.Size(118, 22);
            this.menu_NewCollect.Text = "新建采集";
            this.menu_NewCollect.Click += new System.EventHandler(this.menu_NewCollect_Click);
            // 
            // menu_Classify
            // 
            this.menu_Classify.Name = "menu_Classify";
            this.menu_Classify.Size = new System.Drawing.Size(118, 22);
            this.menu_Classify.Text = "分类";
            this.menu_Classify.Click += new System.EventHandler(this.menu_Classify_Click);
            // 
            // menu_Setting
            // 
            this.menu_Setting.Name = "menu_Setting";
            this.menu_Setting.Size = new System.Drawing.Size(118, 22);
            this.menu_Setting.Text = "设置";
            this.menu_Setting.Click += new System.EventHandler(this.menu_Setting_Click);
            // 
            // menu_About
            // 
            this.menu_About.Name = "menu_About";
            this.menu_About.Size = new System.Drawing.Size(118, 22);
            this.menu_About.Text = "关于";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lv_ArticleTitleList);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 707);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lv_ArticleTitleList
            // 
            this.lv_ArticleTitleList.AllowColumnReorder = true;
            this.lv_ArticleTitleList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lv_ArticleTitleList.ContextMenuStrip = this.contextMenuStrip1;
            this.lv_ArticleTitleList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_ArticleTitleList.FullRowSelect = true;
            this.lv_ArticleTitleList.GridLines = true;
            this.lv_ArticleTitleList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ArticleTitleList.Location = new System.Drawing.Point(6, 11);
            this.lv_ArticleTitleList.MultiSelect = false;
            this.lv_ArticleTitleList.Name = "lv_ArticleTitleList";
            this.lv_ArticleTitleList.Size = new System.Drawing.Size(373, 690);
            this.lv_ArticleTitleList.TabIndex = 0;
            this.lv_ArticleTitleList.UseCompatibleStateImageBehavior = false;
            this.lv_ArticleTitleList.View = System.Windows.Forms.View.Details;
            this.lv_ArticleTitleList.SelectedIndexChanged += new System.EventHandler(this.lv_ArticleTitleList_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_DelArticle,
            this.ToolStripMenuItem_UpdateArticle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 48);
            // 
            // ToolStripMenuItem_DelArticle
            // 
            this.ToolStripMenuItem_DelArticle.Name = "ToolStripMenuItem_DelArticle";
            this.ToolStripMenuItem_DelArticle.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItem_DelArticle.Text = "删除";
            this.ToolStripMenuItem_DelArticle.Click += new System.EventHandler(this.ToolStripMenuItem_DelArticle_Click);
            // 
            // ToolStripMenuItem_UpdateArticle
            // 
            this.ToolStripMenuItem_UpdateArticle.Name = "ToolStripMenuItem_UpdateArticle";
            this.ToolStripMenuItem_UpdateArticle.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItem_UpdateArticle.Text = "修改";
            this.ToolStripMenuItem_UpdateArticle.Click += new System.EventHandler(this.ToolStripMenuItem_UpdateArticle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.main_webBrowser);
            this.groupBox2.Location = new System.Drawing.Point(391, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 707);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // main_webBrowser
            // 
            this.main_webBrowser.Location = new System.Drawing.Point(7, 11);
            this.main_webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.main_webBrowser.Name = "main_webBrowser";
            this.main_webBrowser.Size = new System.Drawing.Size(802, 690);
            this.main_webBrowser.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 747);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "东方宝源-文章采集";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem menu_NewCollect;
        private System.Windows.Forms.ToolStripMenuItem menu_Classify;
        private System.Windows.Forms.ToolStripMenuItem menu_Setting;
        private System.Windows.Forms.ToolStripMenuItem menu_About;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lv_ArticleTitleList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DelArticle;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_UpdateArticle;
        private System.Windows.Forms.WebBrowser main_webBrowser;
    }
}


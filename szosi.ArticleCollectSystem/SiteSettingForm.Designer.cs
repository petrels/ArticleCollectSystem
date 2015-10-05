namespace szosi.ArticleCollectSystem
{
    partial class SiteSettingForm
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
            this.components = new System.ComponentModel.Container();
            this.txt_NewSiteAddress = new System.Windows.Forms.TextBox();
            this.comb_Site = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SiteAdd = new System.Windows.Forms.Button();
            this.txt_NewSiteName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comb_TypeList = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_NewExpression = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_ExpressionList = new System.Windows.Forms.ListView();
            this.contMenu_Regular = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuItem_DelRegular = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_SiteAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_UpdateNewSiteAddress = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contMenu_Regular.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_NewSiteAddress
            // 
            this.txt_NewSiteAddress.Location = new System.Drawing.Point(84, 51);
            this.txt_NewSiteAddress.Name = "txt_NewSiteAddress";
            this.txt_NewSiteAddress.Size = new System.Drawing.Size(250, 21);
            this.txt_NewSiteAddress.TabIndex = 14;
            // 
            // comb_Site
            // 
            this.comb_Site.FormattingEnabled = true;
            this.comb_Site.Location = new System.Drawing.Point(95, 11);
            this.comb_Site.Name = "comb_Site";
            this.comb_Site.Size = new System.Drawing.Size(251, 20);
            this.comb_Site.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "采集网址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "网站：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SiteAdd);
            this.groupBox1.Controls.Add(this.txt_NewSiteName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_NewSiteAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 105);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加新网站";
            // 
            // btn_SiteAdd
            // 
            this.btn_SiteAdd.Location = new System.Drawing.Point(258, 76);
            this.btn_SiteAdd.Name = "btn_SiteAdd";
            this.btn_SiteAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_SiteAdd.TabIndex = 17;
            this.btn_SiteAdd.Text = "添加";
            this.btn_SiteAdd.UseVisualStyleBackColor = true;
            this.btn_SiteAdd.Click += new System.EventHandler(this.btn_SiteAdd_Click);
            // 
            // txt_NewSiteName
            // 
            this.txt_NewSiteName.Location = new System.Drawing.Point(84, 19);
            this.txt_NewSiteName.Name = "txt_NewSiteName";
            this.txt_NewSiteName.Size = new System.Drawing.Size(250, 21);
            this.txt_NewSiteName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "新网站：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comb_TypeList);
            this.groupBox2.Controls.Add(this.btn_OK);
            this.groupBox2.Controls.Add(this.txt_NewExpression);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lv_ExpressionList);
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 325);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "正则表达式";
            // 
            // comb_TypeList
            // 
            this.comb_TypeList.FormattingEnabled = true;
            this.comb_TypeList.Location = new System.Drawing.Point(264, 265);
            this.comb_TypeList.Name = "comb_TypeList";
            this.comb_TypeList.Size = new System.Drawing.Size(76, 20);
            this.comb_TypeList.TabIndex = 23;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(265, 291);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 22;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_NewExpression
            // 
            this.txt_NewExpression.Location = new System.Drawing.Point(72, 265);
            this.txt_NewExpression.Name = "txt_NewExpression";
            this.txt_NewExpression.Size = new System.Drawing.Size(180, 21);
            this.txt_NewExpression.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "新建正则：";
            // 
            // lv_ExpressionList
            // 
            this.lv_ExpressionList.ContextMenuStrip = this.contMenu_Regular;
            this.lv_ExpressionList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_ExpressionList.FullRowSelect = true;
            this.lv_ExpressionList.Location = new System.Drawing.Point(12, 20);
            this.lv_ExpressionList.Name = "lv_ExpressionList";
            this.lv_ExpressionList.Size = new System.Drawing.Size(328, 239);
            this.lv_ExpressionList.TabIndex = 17;
            this.lv_ExpressionList.UseCompatibleStateImageBehavior = false;
            this.lv_ExpressionList.View = System.Windows.Forms.View.Details;
            // 
            // contMenu_Regular
            // 
            this.contMenu_Regular.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuItem_DelRegular});
            this.contMenu_Regular.Name = "contMenu_Regular";
            this.contMenu_Regular.Size = new System.Drawing.Size(95, 26);
            this.contMenu_Regular.Opening += new System.ComponentModel.CancelEventHandler(this.contMenu_Regular_Opening);
            // 
            // toolMenuItem_DelRegular
            // 
            this.toolMenuItem_DelRegular.Name = "toolMenuItem_DelRegular";
            this.toolMenuItem_DelRegular.Size = new System.Drawing.Size(94, 22);
            this.toolMenuItem_DelRegular.Text = "删除";
            this.toolMenuItem_DelRegular.Click += new System.EventHandler(this.toolMenuItem_DelRegular_Click);
            // 
            // txt_SiteAddress
            // 
            this.txt_SiteAddress.Location = new System.Drawing.Point(95, 37);
            this.txt_SiteAddress.Name = "txt_SiteAddress";
            this.txt_SiteAddress.Size = new System.Drawing.Size(250, 21);
            this.txt_SiteAddress.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "采集网址：";
            // 
            // btn_UpdateNewSiteAddress
            // 
            this.btn_UpdateNewSiteAddress.Location = new System.Drawing.Point(270, 64);
            this.btn_UpdateNewSiteAddress.Name = "btn_UpdateNewSiteAddress";
            this.btn_UpdateNewSiteAddress.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateNewSiteAddress.TabIndex = 24;
            this.btn_UpdateNewSiteAddress.Text = "保存新网址";
            this.btn_UpdateNewSiteAddress.UseVisualStyleBackColor = true;
            this.btn_UpdateNewSiteAddress.Click += new System.EventHandler(this.btn_UpdateNewSiteAddress_Click);
            // 
            // SiteSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 536);
            this.Controls.Add(this.btn_UpdateNewSiteAddress);
            this.Controls.Add(this.txt_SiteAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comb_Site);
            this.Controls.Add(this.label1);
            this.Name = "SiteSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "网站设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contMenu_Regular.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_NewSiteAddress;
        private System.Windows.Forms.ComboBox comb_Site;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_NewSiteName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_SiteAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comb_TypeList;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_NewExpression;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lv_ExpressionList;
        private System.Windows.Forms.TextBox txt_SiteAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_UpdateNewSiteAddress;
        private System.Windows.Forms.ContextMenuStrip contMenu_Regular;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItem_DelRegular;
    }
}
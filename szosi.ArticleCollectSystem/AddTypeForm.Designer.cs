namespace szosi.ArticleCollectSystem
{
    partial class AddTypeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comb_Type = new System.Windows.Forms.ComboBox();
            this.txt_NewType = new System.Windows.Forms.TextBox();
            this.btn_AddType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "现有分类";
            // 
            // comb_Type
            // 
            this.comb_Type.FormattingEnabled = true;
            this.comb_Type.Location = new System.Drawing.Point(59, 9);
            this.comb_Type.Name = "comb_Type";
            this.comb_Type.Size = new System.Drawing.Size(233, 20);
            this.comb_Type.TabIndex = 1;
            // 
            // txt_NewType
            // 
            this.txt_NewType.Location = new System.Drawing.Point(59, 42);
            this.txt_NewType.Name = "txt_NewType";
            this.txt_NewType.Size = new System.Drawing.Size(151, 21);
            this.txt_NewType.TabIndex = 2;
            // 
            // btn_AddType
            // 
            this.btn_AddType.Location = new System.Drawing.Point(217, 41);
            this.btn_AddType.Name = "btn_AddType";
            this.btn_AddType.Size = new System.Drawing.Size(75, 23);
            this.btn_AddType.TabIndex = 3;
            this.btn_AddType.Text = "添加";
            this.btn_AddType.UseVisualStyleBackColor = true;
            this.btn_AddType.Click += new System.EventHandler(this.btn_AddType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "新建分类";
            // 
            // AddTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 84);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddType);
            this.Controls.Add(this.txt_NewType);
            this.Controls.Add(this.comb_Type);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建分类";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comb_Type;
        private System.Windows.Forms.TextBox txt_NewType;
        private System.Windows.Forms.Button btn_AddType;
        private System.Windows.Forms.Label label2;
    }
}
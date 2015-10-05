namespace xYuanShian.ControlLibrary
{
	partial class ListEditView
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.ListViewCustom = new xYuanShian.ControlLibrary.vListView();
			this.SuspendLayout();
			// 
			// ListViewCustom
			// 
			this.ListViewCustom.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.ListViewCustom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ListViewCustom.Cursor = System.Windows.Forms.Cursors.Default;
			this.ListViewCustom.GridLines = true;
			this.ListViewCustom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ListViewCustom.LabelEdit = true;
			this.ListViewCustom.Location = new System.Drawing.Point( 0, 0 );
			this.ListViewCustom.Name = "ListViewCustom";
			this.ListViewCustom.Size = new System.Drawing.Size( 380, 320 );
			this.ListViewCustom.TabIndex = 0;
			this.ListViewCustom.UseCompatibleStateImageBehavior = false;
			this.ListViewCustom.View = System.Windows.Forms.View.Details;
			// 
			// ListEditView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.ListViewCustom );
			this.Name = "ListEditView";
			this.Size = new System.Drawing.Size( 380, 320 );
			this.ResumeLayout( false );
		}

		#endregion

		private vListView ListViewCustom;
	}
}

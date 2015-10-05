using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace xYuanShian.ControlLibrary
{
	/// <summary>
	/// 自定义ListView控件
	/// </summary>
	public partial class ListEditView : UserControl
	{
		#region 私有成员
		/// <summary>
		/// 行高
		/// </summary>
		private int _LineHeight = 20;
		/// <summary>
		/// 绑定项
		/// </summary>
		private List<ListEditViewItem> _Items = new List<ListEditViewItem>();
		/// <summary>
		/// 水平滚动事件
		/// </summary>
		private const int WM_HSCROLL = 0x114;
		/// <summary>
		/// 垂直滚动事件
		/// </summary>
		private const int WM_VSCROLL = 0x115;
		#endregion 私有成员

		#region 公有属性
		/// <summary>
		/// 指示包含控件中项及子项的行和列之间是否显示网络线
		/// </summary>
		public bool GridLines
		{
			get { return this.ListViewCustom.GridLines; }
			set { this.ListViewCustom.GridLines = value; }
		}
		/// <summary>
		/// 所有子控件集合
		/// </summary>
		public ControlCollection ListViewControls
		{
			get { return this.ListViewCustom.Controls; }
		}
		/// <summary>
		/// 控件的行高
		/// </summary>
		public int LineHeight { get { return _LineHeight; } set { _LineHeight = value; this.SetLineHeight(); } }
		/// <summary>
		/// 项目集合
		/// </summary>
		public List<ListEditViewItem> Items { get { return _Items; } }
		#endregion 公有属性

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public ListEditView()
		{
			InitializeComponent();

			this.ListViewCustom.CheckBoxes = false;
			this.ListViewCustom.FullRowSelect = true;

			this.ListViewCustom.OnScroll += ControlScroll;
			this.ListViewCustom.DrawColumnHeader += DrawColumnHeader;

			this.SetLineHeight();
		}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 设置行高
		/// </summary>
		private void SetLineHeight()
		{
			Image bitmap = new System.Drawing.Bitmap( 1, _LineHeight );
			ImageList imgList = new ImageList();
			imgList.ImageSize = new Size( 1, _LineHeight ); //分别是宽和高
			imgList.Images.Add( bitmap );
			this.ListViewCustom.SmallImageList = imgList;
		}
		/// <summary>
		/// 当列宽度改变时
		/// </summary>
		/// <param name="Sender"></param>
		/// <param name="ex"></param>
		private void DrawColumnHeader( object Sender, DrawListViewColumnHeaderEventArgs ex )
		{
			this.MoveControl();
		}
		/// <summary>
		/// 滚动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="vscroll"></param>
		private void ControlScroll( object sender, bool vscroll )
		{
			this.MoveControl();
		}
		/// <summary>
		/// 删除控件
		/// </summary>
		private void DelControl( ListEditViewItem items )
		{
			ListEditViewItem clv = items;
			for ( int j = 0; j < this.ListViewCustom.Columns.Count; j++ )
			{
				EditViewColumnHeader ccl = this.ListViewCustom.Columns[j] as EditViewColumnHeader;
				if ( ccl.ColumnStyle == ListEditViewColumnStyle.Control )
				{
					Control tb1 = clv.Items[j] as Control;
					tb1.Dispose();
				}
			}
		}
		/// <summary>
		/// 移动控件，以保持滚动
		/// </summary>
		private void MoveControl()
		{
			for ( int i = 0; i < this.ListViewCustom.Items.Count; i++ )
			{
				ListEditViewItem clv = this.ListViewCustom.Items[i] as ListEditViewItem;
				for ( int j = 0; j < this.ListViewCustom.Columns.Count; j++ )
				{
					EditViewColumnHeader ccl = this.ListViewCustom.Columns[j] as EditViewColumnHeader;
					Point p1;
					Size s1;

					if ( clv.SubItems[j].Bounds.Y <= 5 )
						p1 = new Point( clv.SubItems[j].Bounds.X, clv.SubItems[j].Bounds.Y - 20 );
					else
						p1 = new Point( clv.SubItems[j].Bounds.X, clv.SubItems[j].Bounds.Y );

					if ( j == 0 && this.ListViewCustom.Columns.Count > 1 )
						s1 = new Size( clv.SubItems[1].Bounds.X - clv.SubItems[0].Bounds.X, clv.SubItems[j].Bounds.Height );
					else
						s1 = new Size( clv.SubItems[j].Bounds.Width, clv.SubItems[j].Bounds.Height );

					if ( ccl.ColumnStyle == ListEditViewColumnStyle.Control )
					{
						Control tb1 = clv.Items[j] as Control;
						tb1.Location = p1;
						tb1.Size = s1;
					}
				}
			}
		}
		/// <summary>
		/// 窗体重绘
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );

			this.MoveControl();
		}
		#endregion 私有方法

		#region 公共方法
		/// <summary>
		/// 刷新控件显示
		/// </summary>
		public void RefreshControl()
		{
			this.MoveControl();
		}
		/// <summary>
		/// 添加标题
		/// </summary>
		public void AddColumns( EditViewColumnHeader Header )
		{
			this.ListViewCustom.Columns.Add( Header );
		}
		/// <summary>
		/// 绑定一个数据源
		/// </summary>
		public void DataBind( List<ListEditViewItem> items )
		{
			foreach ( ListEditViewItem item in items )
			{
				this.AddItem( item );
			}
		}
		/// <summary>
		/// 添加一行
		/// </summary>
		/// <param name="items"></param>
		public void AddItem( ListEditViewItem items )
		{
			if ( items.Items.Count != this.ListViewCustom.Columns.Count )
				throw new Exception( "你提供的数据列数与标题列的数目不同" );

			for ( int i = 0; i < items.Items.Count; i++ )
			{
				EditViewColumnHeader ccl = this.ListViewCustom.Columns[i] as EditViewColumnHeader;
				string Titlestr = "";
				switch ( ccl.ColumnStyle )
				{
					case ListEditViewColumnStyle.Control:
						if ( items.Items[i] is Control )
							this.ListViewCustom.Controls.Add( items.Items[i] as Control );
						else
							throw new Exception( "列数据类型不正确!" );

						break;
					default:
						Titlestr = items.Items[i].ToString();
						break;
				}
				if ( i > 0 )
				{
					ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem( items, Titlestr );
					items.SubItems.Add( lvsi );
				}
			}
			this.Items.Add( items );
			this.ListViewCustom.Items.Add( items );
			this.MoveControl();
		}
		/// <summary>
		/// 删除一行
		/// </summary>
		public void DeleteItem( ListEditViewItem items )
		{
			this.Items.Remove( items );
			this.ListViewCustom.Items.Remove( items );

			this.MoveControl();
		}
		/// <summary>
		/// 删除一行
		/// </summary>
		public void DeleteItem( int index )
		{
			this.DelControl( this.Items[index] );
			this.Items.RemoveAt( index );
			this.ListViewCustom.Items.RemoveAt( index );
			this.MoveControl();
		}
		#endregion 公共方法
	}

	#region 工具子类
	/// <summary>
	/// 列风格枚举
	/// </summary>
	public enum ListEditViewColumnStyle
	{
		Text,	//文本字符串
		Control //控件类型
	}
	/// <summary>
	/// 自定义绑定项(一个对象代表一行)
	/// </summary>
	public class ListEditViewItem : ListViewItem
	{
		/// <summary>
		/// 集合
		/// </summary>
		private List<object> _Items = new List<object>( 0 );
		/// <summary>
		/// 是否是第一项
		/// </summary>
		private bool First = true;
		/// <summary>
		/// 该项绑定的控件
		/// </summary>
		public List<object> Items { get { return _Items; } }
		/// <summary>
		/// 构造自定义项
		/// </summary>
		public ListEditViewItem() { }
		/// <summary>
		/// 为本行添加一列数据
		/// </summary>
		/// <param name="subItem"></param>
		public void AddSubItem( object subItem )
		{
			Items.Add( subItem );
			if ( First )
			{
				First = false;

				if ( subItem is string )
					this.SubItems[0] = new ListViewSubItem( this, subItem.ToString() );
				else
					this.SubItems[0] = new ListViewSubItem( this, "" );
			}
		}
	}
	/// <summary>
	/// 列描述
	/// </summary>
	public class EditViewColumnHeader : ColumnHeader
	{
		private ListEditViewColumnStyle cStyle; //本列的风格
		private Type _Type;
		/// <summary>
		/// 构造标题
		/// </summary>
		public EditViewColumnHeader()
			: base()
		{
			cStyle = ListEditViewColumnStyle.Text;
		}
		/// <summary>
		/// 构造标题
		/// </summary>
		/// <param name="cStyle"></param>
		public EditViewColumnHeader( ListEditViewColumnStyle cStyle )
		{
			this.cStyle = cStyle;
			this.SetType();
		}
		/// <summary>
		/// 标题头的列风格
		/// </summary>
		public ListEditViewColumnStyle ColumnStyle
		{
			get { return cStyle; }
			set { cStyle = value; this.SetType(); }
		}
		/// <summary>
		/// 设置类型
		/// </summary>
		private void SetType()
		{
			if ( cStyle == ListEditViewColumnStyle.Text )
			{
				_Type = typeof( string );
			}
			else if ( cStyle == ListEditViewColumnStyle.Control )
			{
				_Type = typeof( Control );
			}
		}
	}
	/// <summary>
	/// ListView
	/// </summary>
	class vListView : ListView
	{
		public delegate void ListViewScroll( object sender, bool vscroll );

		public event ListViewScroll OnScroll;

		protected override void WndProc( ref Message m )
		{
			switch ( m.Msg )
			{
				case 0x20A:	// 鼠标滚轮滚动事件
				case 0x114:	// 滚动条水平滚动
				case 0x115:	// 滚动条垂直滚动
				case 0x4E:	// 通知事件(当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口）
					if ( OnScroll != null ) OnScroll( this, m.Msg == 0x115 );
					break;
			}

			base.WndProc( ref m );
		}
	}
	#endregion 工具子类
}

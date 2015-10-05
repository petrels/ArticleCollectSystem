using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szosi.ArticleCollectSystem.Entities;
using xYuanShian.ControlLibrary;

namespace szosi.ArticleCollectSystem
{
    /// <summary>
    /// 界面帮助类
    /// 提供UI控件的一般化操作
    /// </summary>
    public class UIHelper
    {
        /// <summary>
        /// 初始化ListView
        /// </summary>
        /// <param name="lv">指定已存在的ListView对象</param>
        /// <param name="columns">ListView的列名</param>
        public static void InitListView(ListView lv, params string[] columns)
        {
            for (int i = 0; i < columns.Count(); i++)
            {
                lv.Columns.Add(columns[i],150);
            }
        }

        /// <summary>
        /// 初始化ListEditView(第三方)
        /// </summary>
        /// <param name="lev"></param>
        /// <param name="columns"></param>
        public static void InitListView(ListEditView lev, params string[] columns)
        {
            for (int i = 0; i < columns.Count(); i++)
            {
                EditViewColumnHeader header = new EditViewColumnHeader();
                header.Text = columns[i];
                lev.AddColumns(header);
            }
        }
    }
}

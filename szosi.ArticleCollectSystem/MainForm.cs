using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szosi.ArticleCollectSystem.Entities;
using szosi.ArticleCollectSystem.DAL;

namespace szosi.ArticleCollectSystem
{
    public partial class MainForm : Form
    {
        public List<Article> ArticleList { get; set; }

        public MainForm()
        {
            InitializeComponent();
            UIHelper.InitListView(this.lv_ArticleTitleList, "标题", "时间", "来源");
            Bind();
        }

        private void menu_NewCollect_Click(object sender, EventArgs e)
        {
            NewCollectForm collectForm = new NewCollectForm(this);
            collectForm.ShowDialog();
        }

        private void menu_Classify_Click(object sender, EventArgs e)
        {
            AddTypeForm addTypeForm = new AddTypeForm();
            addTypeForm.ShowDialog();
        }

        private void menu_Setting_Click(object sender, EventArgs e)
        {
            SiteSettingForm ssF = new SiteSettingForm();
            ssF.ShowDialog();
        }

        /// <summary>
        /// 数据绑定 绑定文章列表
        /// </summary>
        public void Bind()
        {
            lv_ArticleTitleList.Items.Clear();
            //获取文章列表
            this.ArticleList = new ArticleDAL().GetArticleList();
            
            foreach (var item in ArticleList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Title;
                lvi.Name = item.ID.ToString();
                lvi.SubItems.Add(item.Time.ToString());
                lvi.SubItems.Add(item.Site.Name);

                this.lv_ArticleTitleList.Items.Add(lvi);
            }
        }

        private void lv_ArticleTitleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断选择的item的数量是否>0
            if (lv_ArticleTitleList.SelectedIndices!=null && lv_ArticleTitleList.SelectedIndices.Count>0)
            {
                main_webBrowser.DocumentText =
                  ArticleList.Where(a => a.ID == 
                   Guid.Parse(lv_ArticleTitleList.SelectedItems[0].Name))
                   .FirstOrDefault().Content;
            }
        }

        private void ToolStripMenuItem_DelArticle_Click(object sender, EventArgs e)
        {
            if (lv_ArticleTitleList.SelectedIndices.Count>0)
            {
                using (ArticleDAL dal = new ArticleDAL ())
                {
                    Article article = 
                        ArticleList.Where(a => a.ID == 
                        Guid.Parse(lv_ArticleTitleList.SelectedItems[0].Name)).First();
                    if (dal.DelArticle(article))
                    {
                        Bind();
                        MessageBox.Show("删除成功");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
        }

        private void ToolStripMenuItem_UpdateArticle_Click(object sender, EventArgs e)
        {
            if (lv_ArticleTitleList.SelectedIndices.Count>0)
            {
                Article article = ArticleList.Where(a => a.ID ==
                Guid.Parse(lv_ArticleTitleList.SelectedItems[0].Name)).First();

                NewCollectForm form = new NewCollectForm(ref article);
                form.ShowDialog();

                using (ArticleDAL dal = new ArticleDAL ())
                {
                    if (dal.UpdateArticle(article))
                    {
                        Bind();
                    }
                }
            }
        }
    }
}

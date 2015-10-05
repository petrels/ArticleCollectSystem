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
using szosi.ArticleCollectSystem.Model;
using System.Threading;

namespace szosi.ArticleCollectSystem
{
    public partial class NewCollectForm : Form
    {
        List<Site> siteList = new List<Entities.Site>();
        List<Article> articleList = new List<Article>();
        List<Address> addressList = new List<Address>();

        MainForm mainForm = new MainForm();

        public NewCollectForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            BindSiteList();
        }

        public NewCollectForm(ref Article article)
        {
            InitializeComponent();

            articleList.Add(article);

            btn_Collect.Enabled = false;
            btn_Save.Enabled = false;
            lv_ArticleTitleList.Enabled = false;
            
            txt_PublishDate.Text = article.Time.ToString();
            txt_Title.Text = article.Title;
            webBrowser1.DocumentText = article.Content;

            BindArticleList();
            lv_ArticleTitleList.Items[0].Checked = true;
            lv_ArticleTitleList.Items[0].Selected = true;
        }

        /// <summary>
        /// 绑定网站列表
        /// </summary>
        public void BindSiteList()
        {
            using (SiteDAL dal = new SiteDAL ())
            {
                siteList = dal.GetSiteList();
            }
            menu_SiteCombox.ComboBox.DataSource = siteList;
            menu_SiteCombox.ComboBox.DisplayMember = "Name";
            menu_SiteCombox.ComboBox.ValueMember = "ID";
        }

        private void btn_Collect_Click(object sender, EventArgs e)
        {
            lab_statu.Text = "就绪。。。";
            string html = String.Empty;
            
            List<Regular> regularList = new List<Regular>();
            articleList.Clear();

            if (menu_SiteCombox.ComboBox.SelectedItem!=null)
            {
                Collect collect = new Collect();

                // 得到相应的网页字符串
                html = collect.GetHtmlString(
                    collect.GetWebResponse(
                        (menu_SiteCombox.ComboBox.SelectedItem as Site).Address.ToString()));

                using (RegularDAL dal = new RegularDAL())
                {
                    // 得到相应网站的正则列表
                    regularList = dal
                        .GetRegularList(menu_SiteCombox.ComboBox.SelectedItem as Site);
                }

                CheckForIllegalCrossThreadCalls = false;

                // 使用另外一个线程来采集文章
                // 保证UI不阻塞
                Thread th = new Thread(new ThreadStart(()=> {
                    //设置
                    

                    foreach (var item in regularList)
                    {
                        addressList.AddRange(collect.GetArticleAddress(item, html));
                    }
                    //addressList.AddRange(collect.GetArticleAddress(html));
                    //设置进度条的最大值和初始值
                    //最大值是所有的地址的数量
                    pro_CollectProcess.Invoke(new Action(() => {
                        pro_CollectProcess.Maximum = addressList.Count;
                        pro_CollectProcess.Value = 0;
                    }));

                    lab_statu.Text = "开始采集";
                    //遍历地址列表
                    foreach (var address in addressList)
                    {
                        Article article = collect.GetArticle(address);
                        if (article.Time<DateTime.Now.Date)
                        {
                            continue;
                        }
                        articleList.Add(collect.GetArticle(address));
                        pro_CollectProcess.Invoke(new Action(() =>
                        {
                            pro_CollectProcess.Value += 1;
                        }));
                    }
                    lab_statu.Text = "采集完毕";
                    BindArticleList();
                }));
                th.IsBackground = true;
                th.Start();
                //绑定文章信息到listview
                
            }
        }

        /// <summary>
        /// 绑定文章列表
        /// </summary>
        public void BindArticleList()
        {
            lv_ArticleTitleList.Items.Clear();
            UIHelper.InitListView(lv_ArticleTitleList, "标题", "时间");

            if (articleList.Count<=0)
            {
                MessageBox.Show("没有获取到任何新文章");
                return;
            }

            foreach (var item in articleList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Title;
                lvi.SubItems.Add(item.Time.ToString());
                lvi.Name = item.ID.ToString();

                lv_ArticleTitleList.Items.Add(lvi);
            }
        }

        private void lv_ArticleTitleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_ArticleTitleList.SelectedIndices != null && lv_ArticleTitleList.SelectedIndices.Count > 0)
            {
                Article article = articleList.Where(a => a.ID ==
                   Guid.Parse(lv_ArticleTitleList.SelectedItems[0].Name))
                   .FirstOrDefault();

                //rtxt_ArticleContent.Text = article.Content; 
                txt_PublishDate.Text = article.Time.ToString();
                txt_Title.Text = article.Title;
                
                webBrowser1.DocumentText = article.Content;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (lv_ArticleTitleList.CheckedItems.Count<=0)
            {
                MessageBox.Show("没有勾选需要的文章，请勾选");
                return;
            }
            
            using (ArticleDAL dal = new ArticleDAL ())
            {
                for (int i = 0; i < lv_ArticleTitleList.CheckedItems.Count; i++)
                {
                    Article article = 
                        articleList.Where(
                            a => a.ID == Guid.Parse(
                                lv_ArticleTitleList.CheckedItems[i].Name
                                )).FirstOrDefault();

                    using (PicProcess pic = new PicProcess ())
                    {
                        if (pic.Process(article))
                        {
                            dal.AddArticle(article);
                        }
                        else
                        {
                            MessageBox.Show("上传失败");
                            return;
                        }
                    }
                }
            }
            mainForm.Bind();
            MessageBox.Show("保存成功!");
        }

        private void btn_UpdateAndSave_Click(object sender, EventArgs e)
        {
            if (lv_ArticleTitleList.SelectedIndices != null && lv_ArticleTitleList.SelectedIndices.Count > 0)
            {
                try
                {
                    Article article = articleList.Where(a => a.ID ==
                    Guid.Parse(lv_ArticleTitleList.SelectedItems[0].Name)).First();

                    article.Time = DateTime.Parse(txt_PublishDate.Text);
                    article.Content = webBrowser1.DocumentText;
                    article.Title = txt_Title.Text;

                    MessageBox.Show("修改成功!");
                    this.Close();
                    this.Dispose();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("系统出错\n\r" + ex.Message);
                }      
            }
        }
    }
}

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
using xYuanShian.ControlLibrary;

namespace szosi.ArticleCollectSystem
{
    public partial class SiteSettingForm : Form
    {
        List<Site> siteList = null;
        List<Regular> regularList = null;
        private List<Entities.Type> typeList = null;

        public SiteSettingForm()
        {   
            InitializeComponent();
            BindTypeList(); //初始化文章类型列表
            BindSiteList();//初始化网站列表
            txt_SiteAddress.Text = siteList[0].Address.ToString(); //首次加载窗体 显示网站默认项的网址
            BindRegularList(siteList[0]); //首次加载窗体              
        }
        /// <summary>
        /// 绑定combobox
        /// </summary>
        public void BindSiteList()
        {
            using (SiteDAL dal = new SiteDAL())
            {
                siteList = dal.GetSiteList();
            }
            comb_Site.DataSource = siteList;
            comb_Site.DisplayMember = "Name";
            comb_Site.ValueMember = "ID";

            //comb_Site的事件绑定
            this.comb_Site.SelectedIndexChanged += new System.EventHandler(this.comb_Site_SelectedIndexChanged);
        }

        /// <summary>
        /// 绑定正则表达式列表，根据网站
        /// </summary>
        /// <param name="site"></param>
        public void BindRegularList(Site site)
        {
            using (RegularDAL dal = new RegularDAL())
            {
                regularList = dal.GetRegularList(site);
            }

            //清理原来数据
            lv_ExpressionList.Items.Clear();
            lv_ExpressionList.Columns.Clear();

            //初始化listview的列头
            UIHelper.InitListView(lv_ExpressionList, "正则表达式", "文章类型");

            try
            {
                foreach (var item in regularList)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = item.Name;
                    lvi.SubItems.Add(item.Type.Name);
                    lvi.Name = item.ID.ToString();

                    lv_ExpressionList.Items.Add(lvi);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 绑定类型列表
        /// </summary>
        private void BindTypeList()
        {
            using (TypeDAL dal = new TypeDAL())
            {
                typeList = dal.GetTypeList();
            }
            //两个combobox
            comb_TypeList.DataSource = typeList;
            comb_TypeList.DisplayMember = "Name";
            comb_TypeList.ValueMember = "ID";
        }

        private void comb_Site_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combobox选中的值的获取   
            //SelectedItem指的是绑定的对象  取值时需要 as 转换
            //记得把combobox的事件绑定提取到现在的位置

            txt_SiteAddress.Text =
                siteList.Where(s => s.ID ==
                (comb_Site.SelectedItem as Site).ID)
                .FirstOrDefault().Address.ToString();

            BindRegularList(comb_Site.SelectedItem as Site);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_NewExpression.Text))
            {
                using (RegularDAL dal = new RegularDAL ())
                {
                    if (dal.GetRegular(txt_NewExpression.Text.Trim()) == null)
                    {
                        Regular regular = new Regular()
                        {
                            ID = Guid.NewGuid(),
                            Name = txt_NewExpression.Text.Trim(),
                            Site = comb_Site.SelectedItem as Site,
                            Type = comb_TypeList.SelectedItem as Entities.Type
                        };

                        if (dal.AddRegular(regular))
                        {
                            txt_NewExpression.Text = "";
                            BindRegularList(comb_Site.SelectedItem as Site);
                            MessageBox.Show("添加成功！");
                        }
                        else
                        {
                            MessageBox.Show("添加失败！");
                        }
                    }
                    else {
                        MessageBox.Show("该正则已存在!");
                    }
                }
            }
            else
            {
                MessageBox.Show("正则表达式不能为空!");
            }
        }

        private void btn_SiteAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_NewSiteName.Text) && !String.IsNullOrEmpty(txt_NewSiteAddress.Text))
            {
                using (SiteDAL dal = new SiteDAL())
                {
                    if (dal.GetSite(txt_NewSiteName.Text)==null)
                    {
                        Site site = new Entities.Site()
                        {
                            ID = Guid.NewGuid(),
                            Address = txt_NewSiteAddress.Text.Trim(),
                            Name = txt_NewSiteName.Text
                        };

                        if (dal.AddSite(site))
                        {
                            siteList.Add(site);
                            BindSiteList();
                            MessageBox.Show("添加网站成功！");
                        }
                        else
                        {
                            MessageBox.Show("添加失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("此网站已存在！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请添加完整信息！");
            }
        }

        private void btn_UpdateNewSiteAddress_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_SiteAddress.Text))
            {
                using (SiteDAL db = new SiteDAL ())
                {
                    if (db.UpdateSiteAddress(comb_Site.SelectedItem as Site,
                        txt_SiteAddress.Text.Trim()))
                    {
                        MessageBox.Show("修改网址成功！");
                    }
                    else
                    {
                        MessageBox.Show("更新失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("新网址不能为空！");
            }
        }

        private void toolMenuItem_DelRegular_Click(object sender, EventArgs e)
        {
            if (lv_ExpressionList.SelectedIndices.Count>0)
            {
                using (RegularDAL dal = new RegularDAL ())
                {
                    Regular regular = dal.GetRegular(Guid.Parse(lv_ExpressionList.SelectedItems[0].Name));
                    if (!dal.DelRegular(regular))
                    {
                        MessageBox.Show("删除失败");
                        return;
                    }
                    lv_ExpressionList.Items.Remove(lv_ExpressionList.SelectedItems[0]);
                    regularList.Remove(regular);
                }
            }
        }

        private void contMenu_Regular_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

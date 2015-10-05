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
    public partial class AddTypeForm : Form
    {
        /// <summary>
        /// combobox数据源  文章类型集合
        /// </summary>
        List<szosi.ArticleCollectSystem.Entities.Type> typeList = null;
        public AddTypeForm()
        {
            InitializeComponent();
            BindTypeList();
        }

        private void BindTypeList()
        {
            //获取文章类型列表
            typeList = new TypeDAL().GetTypeList();

            this.comb_Type.DataSource = typeList;//绑定
            this.comb_Type.DisplayMember = "Name";
            this.comb_Type.ValueMember = "ID";
        }

        /// <summary>
        /// 添加新文章类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddType_Click(object sender, EventArgs e)
        {
            //判断输入是否为空
            if (!String.IsNullOrEmpty(txt_NewType.Text))
            {
                using (TypeDAL dal = new TypeDAL ())
                {
                    //判断是否存在类型
                    if (dal.GetType(txt_NewType.Text)==null)
                    {
                        //实例化新类型
                        szosi.ArticleCollectSystem.Entities.Type type
                            = new Entities.Type()
                            {
                                ID = Guid.NewGuid(),
                                Name = txt_NewType.Text.Trim()
                            };
                        //添加新类型
                        if (dal.AddType(type))
                        {
                            typeList.Add(type);
                            BindTypeList();
                            txt_NewType.Text = "";
                            MessageBox.Show("添加成功！");
                        }
                        else
                        {
                            MessageBox.Show("添加失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("类型已存在");
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入新类型");
            }
        }
    }
}

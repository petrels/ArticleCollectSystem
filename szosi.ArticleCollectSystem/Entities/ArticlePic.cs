using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace szosi.ArticleCollectSystem.Entities
{
    /// <summary>
    /// 文章图片类
    /// 标记图片的文章归属，编号和查看地址
    /// </summary>
    class ArticlePic
    {
        private Guid id;
        [Key]
        [Required]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        private Article article;

        public Article Article
        {
            get { return article; }
            set { article = value; }
        }

        private string address;
        /// <summary>
        /// 存储路径
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int? number;
        /// <summary>
        /// 标记图片在文章的出现顺序
        /// int? 文章可以没有图片
        /// </summary>
        public int? Number
        {
            get { return number; }
            set { number = value; }
        }

    }
}

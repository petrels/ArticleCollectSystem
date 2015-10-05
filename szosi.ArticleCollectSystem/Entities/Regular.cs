
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace szosi.ArticleCollectSystem.Entities
{
    /// <summary>
    /// 正则表达式类
    /// 记录相应网站文章采集的正则表达式
    /// </summary>
    public class Regular
    {
        private Guid id;
        [Key]
        [Required]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 一条正则对应一个文章类型，一个文章类型可以对应多条正则
        /// </summary>
        private Type type;
        [Required]
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 一条正则对应一个网站，一个网站对应多条正则
        /// </summary>
        private Site site;
        [Required]
        public Site Site
        {
            get { return site; }
            set { site = value; }
        }
    }
}

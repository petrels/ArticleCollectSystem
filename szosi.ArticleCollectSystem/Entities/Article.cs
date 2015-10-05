using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace szosi.ArticleCollectSystem.Entities
{
    public class Article
    {
        private Guid id;
        [Key]
        [Required]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 考虑到采集算法的准确率问题（不是100%准确），所以可能会出现空的情况
        /// 所以这里不要求Title不为空
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 同上
        /// </summary>
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        
        private Type type;
        [Required]
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        private DateTime time;
        [Required]
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private Site site;
        [Required]
        public Site Site
        {
            get { return site; }
            set { site = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace szosi.ArticleCollectSystem.Entities
{
    /// <summary>
    /// 类型类
    /// 表示文章的类型
    /// 考虑到可能文章的类型会发生改变，所以就单独成类
    /// </summary>
    public class Type
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

    }
}

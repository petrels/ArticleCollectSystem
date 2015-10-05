using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace szosi.ArticleCollectSystem.Entities
{
    /// <summary>
    /// 网站类
    /// 记录要采集的网站
    /// </summary>
    public class Site
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
        /// 采集地址，不是网站首页，是提供网站文章链接的网页的网址
        /// </summary>
        private string address;
        [Required]
        public string Address
        {
            get { return Base64.Base64Decode(address); } // url用base64加密后存储
            set { address = Base64.Base64Encode(value); } // 然后取得时候解密
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

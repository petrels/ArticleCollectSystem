using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szosi.ArticleCollectSystem.Entities;

namespace szosi.ArticleCollectSystem.Model
{
    class Address
    {
        public string address { get; set; }

        public Site site { get; set; }

        public Entities.Type type { get; set; }
    }
}

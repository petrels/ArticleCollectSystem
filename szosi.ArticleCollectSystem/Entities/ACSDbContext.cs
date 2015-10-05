using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace szosi.ArticleCollectSystem.Entities
{
    class ACSDbContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Regular> Regulars { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<ArticlePic> Pictures { get; set; }

        /// <summary>
        /// 初始化数据库数据
        /// </summary>
        public ACSDbContext()
        {
            if (!this.Database.Exists())
            {
                this.Database.Create();

                Site site = new Site()
                {
                    ID = Guid.NewGuid(),
                    Address = "http://www.jrkz.com",
                    Name = "金融客栈"
                };

                this.Sites.Add(site);

                Type type = new Type() {
                    ID = Guid.NewGuid(),
                    Name = "时事"
                };

                this.Articles.Add(new Article()
                {
                    ID = Guid.NewGuid(),
                    Title = "hehe",
                    Time = DateTime.Now,
                    Site = site,
                    Content = "hehehee",
                    Type = type
                });

                this.Regulars.Add(new Regular
                {
                    ID = Guid.NewGuid(),
                    Name = @"<h1[\s\S]*?</h1>",
                    Site = site,
                    Type = type
                });

                // 记住要保存
                this.SaveChanges();
            }
        }

    }
}

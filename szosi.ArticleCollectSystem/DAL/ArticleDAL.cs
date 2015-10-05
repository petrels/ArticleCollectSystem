using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szosi.ArticleCollectSystem.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace szosi.ArticleCollectSystem.DAL
{
    /// <summary>
    /// 文章的数据访问类
    /// 提供直接操作数据库的方法
    /// </summary>
    class ArticleDAL:IDisposable
    {
        /// <summary>
        /// 获取所有的文章列表 
        /// 按时间排序
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticleList()
        {
            List<Article> articleList = null;
            try
            {
                using (ACSDbContext db = new ACSDbContext())
                {
                    //
                    //当要生成外键实体时 查询的时候加上.Include(a=>a.外键实体名)即可
                    //在使用.include()时，要记得using System.Data.Entity;
                    articleList =
                        db.Articles.Include(a => a.Site).Include(a=>a.Type)
                        .OrderByDescending(a => a.Time).ToList();
                }
                return articleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加一篇文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool AddArticle(Article article)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    db.Articles.Attach(article);
                    db.Articles.Add(article);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一个文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool DelArticle(Article article)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    db.Articles.Attach(article);
                    db.Articles.Remove(article);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateArticle(Article article)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext())
                {
                    DbEntityEntry<Article> entry = db.Entry<Article>(article);

                    entry.State = EntityState.Unchanged;
                    entry.Property("Title").IsModified = true;
                    entry.Property("Content").IsModified = true;
                    entry.Property("Time").IsModified = true;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~ArticleDAL() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

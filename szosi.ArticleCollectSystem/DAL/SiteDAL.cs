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
    /// 网站数据访问类
    /// 提供基本的数据库操作方法
    /// </summary>
    public class SiteDAL:IDisposable
    {
        /// <summary>
        /// 获取网站列表
        /// </summary>
        /// <returns></returns>
        public List<Site> GetSiteList()
        {
            List<Site> siteList = null;
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    siteList = db.Sites.ToList();
                }
                return siteList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加一个新网站
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public bool AddSite(Site site)
        { 
            try
            {
                using (ACSDbContext db = new ACSDbContext())
                {
                    db.Sites.Attach(site);
                    db.Sites.Add(site);
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
        /// 根据网站名获取一个网站
        /// 如果存在这样的网站则返回Site对象，如果不存在则返回Null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Site GetSite(string name)
        {
            Site site = null;
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    site = db.Sites.Where(s => s.Name == name).FirstOrDefault();
                }
                return site;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新网站地址
        /// </summary>
        /// <param name="site"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool UpdateSiteAddress(Site site, string address)
        {
            try
            {
                site.Address = address;
                // 这种更新数据的方法不用先查询，直接修改
                using (ACSDbContext db = new ACSDbContext())
                {
                    DbEntityEntry<Site> entry = db.Entry<Site>(site);

                    entry.State = EntityState.Unchanged;
                    entry.Property("Address").IsModified = true;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
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
        // ~SiteDAL() {
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

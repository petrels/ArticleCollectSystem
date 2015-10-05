using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szosi.ArticleCollectSystem.Entities;
using System.Data.Entity;

namespace szosi.ArticleCollectSystem.DAL
{
    /// <summary>
    /// 正则表达式数据访问类
    /// 提供基本的数据库操作方法
    /// </summary>
    public class RegularDAL:IDisposable
    {
        /// <summary>
        /// 通过网站获取相应的正则表达式列表
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public List<Regular> GetRegularList(Site site)
        {
            List<Regular> regularList = null;
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    //当要比较数据库外键对应的实体类时，应先取出实体集合，在在集合中比较
                    regularList =
                        db.Regulars.Include(r => r.Site).Include(r=>r.Type).ToList();
                }

                //////////////////////////////////////////////////////
                return regularList.Where(r=>r.Site.ID == site.ID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据正则名称获得正则对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Regular GetRegular(string name)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext())
                {
                    return db.Regulars.Include(r=>r.Site).Include(r=>r.Type).Where(r => r.Name == name).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 通过id取得一个正则表达式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Regular GetRegular(Guid id)
        {
            Regular regular = new Regular();
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    regular = db.Regulars.Include(r=>r.Site).Include(r=>r.Type).Where(r => r.ID == id).First();
                }
                return regular;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加正则表达式
        /// </summary>
        /// <param name="regular"></param>
        /// <returns></returns>
        public bool AddRegular(Regular regular)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    // 对于外来的实体对象（就是那些不是直接用同一个DbContext查询出来的实体） 
                    // 需要用Attach()附加到当前DbContext中
                    // 不然对于增删改操作会有异常
                    db.Regulars.Attach(regular);
                    db.Regulars.Add(regular);
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
        /// 删除选中的正则
        /// </summary>
        /// <param name="regular"></param>
        /// <returns></returns>
        public bool DelRegular(Regular regular)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    db.Regulars.Attach(regular);

                    db.Regulars.Remove(regular);

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
        // ~RegularDAL() {
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

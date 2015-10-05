using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szosi.ArticleCollectSystem.Entities;

namespace szosi.ArticleCollectSystem.DAL
{
    /// <summary>
    /// 文章类型数据访问类
    /// 提供直接访问数据库的方法
    /// </summary>
    public class TypeDAL:IDisposable
    {
        /// <summary>
        /// 获得类型列表
        /// </summary>
        /// <returns></returns>
        public List<szosi.ArticleCollectSystem.Entities.Type> GetTypeList()
        {
            List<szosi.ArticleCollectSystem.Entities.Type> typeList = null;
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    typeList = db.Types.ToList();
                }
                return typeList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取名字为name的文章类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public szosi.ArticleCollectSystem.Entities.Type GetType(string name)
        {
            szosi.ArticleCollectSystem.Entities.Type type = null;
            try
            {
                using (ACSDbContext db = new ACSDbContext())
                {
                    type = db.Types.Where(t => t.Name == name).FirstOrDefault();
                }
                return type;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加一个文章类型对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns>返回是否添加成功</returns>
        public bool AddType(szosi.ArticleCollectSystem.Entities.Type type)
        {
            try
            {
                using (ACSDbContext db = new ACSDbContext ())
                {
                    db.Types.Attach(type);
                    db.Types.Add(type);
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
        // ~TypeDAL() {
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

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szosi.ArticleCollectSystem.Entities;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace szosi.ArticleCollectSystem
{
    class PicProcess:IDisposable
    {
        /// <summary>
        /// 远程存储的目录
        /// </summary>
        private string remotePath { get; set; }
        private string localPath { get; set; }
        private string userName { get; set; }
        private string passWord { get; set; }

        /// <summary>
        /// 初始化连接配置
        /// </summary>
        public PicProcess()
        {
            remotePath = ConfigurationManager.AppSettings["remotePath"];
            localPath = ConfigurationManager.AppSettings["localPath"];
            userName = ConfigurationManager.AppSettings["userName"];
            passWord = ConfigurationManager.AppSettings["passWord"];
        }

        /// <summary>
        /// 图片处理
        /// 根据文章信息 获取img的数目和对应的address
        /// 返回一个List<ArticlePic>
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool Process(Article article)
        {
            //Regex regImg = new Regex(@"<img .*?>");// 匹配img标签的正则
            //MatchCollection mc = regImg.Matches(article.Content);

            Regex regSrc = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection mcSrc = regSrc.Matches(article.Content);
            //匹配img里面src

            int count = 0;

            foreach (Match item in mcSrc)
            {
                string imgName = Guid.NewGuid().ToString()+"_"+ (count++) + ".jpg";
                regSrc.Replace(item.Value, remotePath + imgName);
                try
                {
                    //WNetAddConnection2A
                    int tag = NASHelper.NetWorkConnection.Connect(localPath, remotePath, userName, passWord);
                    if ( tag == 0)
                    {
                        if (GetImage(item.Groups["imgUrl"].Value, remotePath +"\\"+ imgName))
                        {
                            NASHelper.NetWorkConnection.Disconnect(localPath);
                        }
                        NASHelper.NetWorkConnection.Disconnect(localPath);
                    }
                    else {
                        return false;
                    }

                }
                catch (Exception)
                {
                    return false;
                }    
            }
            return true;
        }

        public bool GetImage(string imgAddress, string remotePath)
        {
            try
            {
                WebRequest request = WebRequest.Create(imgAddress);
                WebResponse response = request.GetResponse();
                Stream reader = response.GetResponseStream();
                FileStream writer = new FileStream(remotePath, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] buff = new byte[512];
                int c = 0; //实际读取的字节数
                while ((c = reader.Read(buff, 0, buff.Length)) > 0)
                {
                    writer.Write(buff, 0, c);
                }
                writer.Close();
                writer.Dispose();
                reader.Close();
                reader.Dispose();
                response.Close();
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
        // ~PicProcess() {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StanSoft;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using szosi.ArticleCollectSystem.Entities;

namespace szosi.ArticleCollectSystem
{
    class Collect
    {
        Encoding DEFAULT_ENCODING = Encoding.GetEncoding("utf-8");
        string USERAGENT = @"Mozilla/4.0 
                    (compatible; MSIE 8.0; Windows NT 5.1; 
                    Trident/4.0;InfoPath.2; .NET CLR 2.0.50727; 
                    .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 
                    .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; 
                    msn OptimizedIE8;ZHCN)";
        /// <summary>
        /// 通过网址得到 webresponse;
        /// </summary>
        /// <param name="siteAddress"></param>
        /// <returns></returns>
        public WebResponse GetWebResponse(string siteAddress)
        {
            // 这里很诡异 EF在存储url格式字符串的时候会自动忽略掉前面的'http://'
            // 所以这里就要把http://拼接回去
            // 但是呢在网络取得的url是自带有http://的
            //？？？？？？？？？？？？？？？？？？？
            //string completeAddress = "";
            //if (!siteAddress.Contains("http://")&&!siteAddress.Contains("https://"))
            //{
            //    completeAddress = "http://" + siteAddress;
            //}
            //else
            //{
            //    completeAddress = siteAddress;
            //}
            Uri uriResult;
            bool result = Uri.TryCreate(siteAddress, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp
                              || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result)
            {
                return null;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(siteAddress);
                request.UserAgent = USERAGENT;
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();

                return response;
            }
            catch (Exception)
            {
                return null;
            }   
        }

        /// <summary>
        /// 获取response返回的html字符串
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string GetHtmlString(WebResponse response)
        {
            if (response==null)
            {
                return "";
            }
            string html = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, DEFAULT_ENCODING))
                {
                    html = reader.ReadToEnd();
                    reader.Close();
                }
            }

            return html;
        }

        /// <summary>
        /// 获取相应文章类型的文章链接列表
        /// </summary>
        /// <param name="articleRegulax"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public List<Model.Address> GetArticleAddress(string html)
        {
            List<Model.Address> addressList = new List<Model.Address>();

            string clearFilter = @"[\t\n\r]";
            html = Regex.Replace(html, clearFilter, "");
            //string newsFilter = regular.Name;
            //MatchCollection newsMatch = Regex.Matches(html, newsFilter);

            //去掉换行 拼接字符串
            //foreach (var item in newsMatch)
            //{
            //    mainNews += item.ToString();
            //}

            //取链接的正则表达式
            Regex regex2 = new Regex(@"<a[^>]+href=\s*(?:'(?<href>[^']+)'|""(?<href>[^""]+)""|(?<href>[^>\s]+))\s*[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase);
            for (Match match2 = regex2.Match(html); match2.Success; match2 = match2.NextMatch())
            {
                string url = match2.Groups["href"].Value;

                addressList.Add(new Model.Address() {
                    address = url
                    
                });
            }

            return addressList;
        }
        public List<Model.Address> GetArticleAddress(Regular regular, string html)
        {
            List<Model.Address> addressList = new List<Model.Address>();

            string clearFilter = @"[\t\n\r]";
            html = Regex.Replace(html, clearFilter, "");
            string mainNews = "";
            string newsFilter =@"<div class=" +"\""+regular.Name+"\""+ ">.*?</div>";
            MatchCollection newsMatch = Regex.Matches(html, newsFilter);
            if (newsMatch.Count<=0)
            {
                newsFilter =@"<div class="+"\'"+ regular.Name+"\'"+ ">.*?</div>";
                newsMatch = Regex.Matches(html, newsFilter);
            }
            //去掉换行 拼接字符串
            foreach (var item in newsMatch)
            {
                mainNews += item.ToString();
            }

            //取链接的正则表达式
            Regex regex2 = new Regex(@"<a[^>]+href=\s*(?:'(?<href>[^']+)'|""(?<href>[^""]+)""|(?<href>[^>\s]+))\s*[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase);
            for (Match match2 = regex2.Match(mainNews); match2.Success; match2 = match2.NextMatch())
            {
                string url = match2.Groups["href"].Value;

                addressList.Add(new Model.Address()
                {
                    address = url,
                    site = regular.Site,
                    type = regular.Type
                });
            }

            return addressList;
        }

        public Entities.Article GetArticle(Model.Address address)
        {
            string html = this.GetHtmlString(GetWebResponse(address.address));
            StanSoft.Article article = new StanSoft.Article();

            article = Html2Article.GetArticle(html);

            Entities.Article myArticle = new Entities.Article();
            myArticle.ID = Guid.NewGuid();
            myArticle.Time = article.PublishDate;

            // 这里要去掉采集出来的标题的制表符回车等等
            //以免在绑定到listview会看不见标题
            string clearFilter = @"[\t\n\r]";
            myArticle.Title = Regex.Replace(article.Title,clearFilter,"");
            myArticle.Title = myArticle.Title.TrimStart();
            myArticle.Title = myArticle.Title.TrimEnd();

            myArticle.Site = address.site;
            myArticle.Type = address.type;
            myArticle.Content = StanSoft.UrlUtility.FixUrl(address.address, article.ContentWithTags);
            
            return myArticle;
        }

    }
}

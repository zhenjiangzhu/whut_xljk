using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.MODEL;
using COMMON;

namespace EmptyProjectNet45_FineUI
{
    public partial class index : System.Web.UI.Page
    {
        ArticleBLL bll = new ArticleBLL();
        FileBLL fileBll = new FileBLL();
        ImgChangeBLL imgBll = new ImgChangeBLL();

        public string PreImg { get; set; }
        public string xwdt_toutiao { get; set; }

        public string xinxie_toutiao { get; set; }
        public string preMeiwen { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            PreImg = LoadIndexImage();
            xwdt_toutiao = LoadToutiaoNews();
            xinxie_toutiao = loadXinxieNews();
            preMeiwen = loadmeiwenNews();
        }



        //首页大图加载
        public string LoadIndexImage()
        {
            StringBuilder sb = new StringBuilder();
            List<T_ImgChange> list = imgBll.GetList();
            int i = 1;
            foreach (T_ImgChange model in list)
            {
                if (i == 1)
                {
                    //获得图片信息的位置
                    sb.AppendFormat("<div class='item active'><div class='carousel-title'>{2}</div><a href='" + @"http://" + "{1}' target='_blank'><img src='images/banner/back{0}.jpg' width='990' height='340' alt='{1}' /></a></div>", i, model.C_ImgUrl, model.C_ImgDes);
                }
                else
                {
                    sb.AppendFormat("<div class='item'><div class='carousel-title'>{2}</div><a href='" + @"http://" + "{1}' target='_blank'><img src='images/banner/back{0}.jpg' width='990' height='340' alt='{1}' /></a></div>", i, model.C_ImgUrl, model.C_ImgDes);

                }
                i++;
            }
            return sb.ToString();
        }
        //中心动态，搜的都是要有图片的新闻
        public string LoadToutiaoNews()
        {
            List<T_Article> list = bll.GetListByContent(4, 2);
            StringBuilder sb = new StringBuilder();
            int i = 0;

            foreach (var model in list)
            {
                //获得文章内容的简介
                T_Article first = new T_Article();
                first = bll.GetArticleById(model.ArticleId);

                string ab = Regex.Replace(first.ArticleContent, @"<.*?>", "");
                //如果文字没有超过100个字
                if (ab.Length > 70)
                {
                    ab = ab.Substring(0, 70);
                }
                ab = ab + "...";


                if (i == 0)
                {
                    //第一张提取图片
                    //精简文章主题内容
                    string imgurl = ImgHelper.getImgUrl(first.ArticleContent, @"<img[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", "src")[0].ToString();
                    sb.AppendFormat("<a href='articleDetail.aspx?articleId={0}'><img src='{1}'/></a><h3>{2}</h3><p>{3}</p>", model.ArticleId, imgurl, model.ArticleTitle, ab);
                    sb.AppendFormat("</div><div class='newsright'>");
                }
                else
                {
                    sb.AppendFormat("<a href='articleDetail.aspx?articleId={0}'> <p class='nrtitle'>{1}</p></a><p class='nrtxt' style='font-size:14px;'>{2}</p>", model.ArticleId, model.ArticleTitle,ab);
                }
                i++;
            }
            return sb.ToString();
        }

        //心协动态
        public string loadXinxieNews()
        {

            List<T_Article> list = bll.GetListByContent(4, 3);
            StringBuilder sb = new StringBuilder();
  
            foreach (T_Article model in list)
            {
                //获得文章内容的简介
                T_Article first = new T_Article();
                first = bll.GetArticleById(model.ArticleId);
                string ab = Regex.Replace(first.ArticleContent, @"<.*?>", "");
                //如果文字没有超过100个字
                if (ab.Length > 70)
                {
                    ab = ab.Substring(0, 70);
                }
                ab = ab + "...";

                //girdview,前端代码 


                //获得图片的地址
                string imgurl = ImgHelper.getImgUrl(first.ArticleContent, @"<img[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", "src")[0].ToString();
                

                sb.AppendFormat("<div class='newsbottom'><a href='articleDetail.aspx?articleId={2}' class='imglink'><img src='{4}'></a><p class='nrtitle'>{1}</p><a href='articleDetail.aspx?articleId={2}'>{3}</a></div>", first.ArticleContent, first.ArticleTitle, first.ArticleId, ab,imgurl);
            }

            return sb.ToString();
        }
        //心理美文
        public string loadmeiwenNews()
        {
            List<T_Article> list = bll.GetListByContent(4, 5);
            StringBuilder sb = new StringBuilder();

            foreach (T_Article model in list)
            {
                //获得文章内容的简介
                T_Article first = new T_Article();
                first = bll.GetArticleById(model.ArticleId);
                string ab = Regex.Replace(first.ArticleContent, @"<.*?>", "");
                //如果文字没有超过100个字
                if (ab.Length > 70)
                {
                    ab = ab.Substring(0, 70);
                }
                ab = ab + "...";
                //girdview,前端代码 
                //获得图片的地址
                string imgurl = ImgHelper.getImgUrl(first.ArticleContent, @"<img[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", "src")[0].ToString();

                sb.AppendFormat("<a href='articleDetail.aspx?articleId={1}' class='grid-block'><figure class='grid-item'><img src='{3}'/><figcaption><h3>{2}</h3></figcaption></figure></a>", model.ArticleContent, model.ArticleId, model.ArticleTitle,imgurl);

            }
            return sb.ToString();
        }
    }
}

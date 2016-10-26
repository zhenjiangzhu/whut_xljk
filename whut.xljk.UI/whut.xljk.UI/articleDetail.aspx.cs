using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using System.Text;

namespace EmptyProjectNet45_FineUI
{
    public partial class articleDetail : System.Web.UI.Page
    {
        ArticleBLL bll = new ArticleBLL();
        public string lastArticleHref { get; set; }
        public string lastArticleTitle { get; set; }
        public string nextArticleHref { get; set; }
        public string nextArticleTitle { get; set; }
        public string shangyipian { get; set; }
        public string xiayipian { get; set; }

        public T_Article model { get; set; }
        public string aAnnex { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["articleid"] != "" || Request["articleid"] != null)
            {
                string id = Context.Request["articleid"];

                model = bll.GetArticleById(id);
                if (model.ArticleCategory == 0)
                {
                    Response.Redirect("error.html");
                }

                if (model.ArticleAnnexAddr != "")
                {

                    string[] pathUrl = bll.GetAnnexAddrByAnnex(model.ArticleAnnexAddr);
                    string[] sp = null;
                    if (model.ArticleAnnexAddr.IndexOf(',') > 0)
                        sp = model.ArticleAnnexAddr.Split(',');
                    else
                        sp = new string[] { model.ArticleAnnexAddr };
                    aAnnex = GenerateATagByAnnex(pathUrl, sp);

                }

                //上下篇
                List<T_Article> lastArticleList = bll.GetLastArticle(id, model.ArticleCategory);
                List<T_Article> nextArticleList = bll.GetNextArticle(id, model.ArticleCategory);
                if (lastArticleList.Count > 0)
                {
                    lastArticleHref = "articleDetail.aspx?articleId=" + lastArticleList[0].ArticleId;
                    lastArticleTitle = lastArticleList[0].ArticleTitle;
                }
                else
                {
                    lastArticleHref = "";
                    lastArticleTitle = "没有了";
                }
                if (nextArticleList.Count > 0)
                {
                    nextArticleHref = "articleDetail.aspx?articleId=" + nextArticleList[0].ArticleId;
                    nextArticleTitle = nextArticleList[0].ArticleTitle;
                }
                else
                {
                    nextArticleHref = "";
                    nextArticleTitle = "没有了";
                }

            }
            else
            { Response.Redirect("error.html"); }
        }


        //生成a标签
        public string GenerateATagByAnnex(string[] path, string[] sp)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                sb.AppendFormat("<a href='{0}' target='_blank'>{1}</a>", path[i], sp[i]);
            }
            return sb.ToString();
        }


    }
}



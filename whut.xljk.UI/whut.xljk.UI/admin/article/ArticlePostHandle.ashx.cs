using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using whut.xljk.MODEL;
using whut.xljk.BLL;
using System.Web.SessionState;
using FineUI;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// ArticlePostHandle 的摘要说明
    /// </summary>
    public class ArticlePostHandle : IHttpHandler, IReadOnlySessionState
    {
        ArticleBLL bll = new ArticleBLL();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string articleId = bll.GetIdByTime(DateTime.Now.ToString("yyyyMMdd"));
                string articleTitle = context.Request.Form["txtTitle"] ?? "未设置标题".ToString();
                int articleCategory = int.Parse(context.Request.Form["txtCategory"].ToString());
                string articleSector = context.Request.Form["txtSector"] ?? "未设置来源".ToString();
                // (context.Session["model"] as T_InfoAdmin).InfoAdminSector;
                int articleTopic = 0;

                string articleContent = context.Request.Form["txtcontent"].ToString();
                string articlePostStaff = context.Request.Form["txtPostStaff"] ?? "未设置作者".ToString();
                //(context.Session["model"] as T_stuplazaInfoAdmin).InfoAdminName;

                string articleAnnexAddr = context.Request.Form["txtAnnex"].ToString();

                string articleTime = context.Request.Form["act_start_time"].ToString();
                if (String.IsNullOrEmpty(articleTime.Trim()))
                {
                    articleTime = DateTime.Now.ToString();
                }
                string articleColumn = "00000000";

                T_Article article = new T_Article();
                article = GetModel(articleId, articleTitle, articleCategory, articleSector, articleTopic, articleContent, articlePostStaff, articleAnnexAddr, articleTime, articleColumn);
                bll.InsertArticle(article);
                context.Response.Write("文章添加成功，请关闭此窗口~");
            }
            catch
            {
                throw;
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public T_Article GetModel(string id, string title, int category, string sector, int topic, string content, string poststaff, string annexaddr, string time, string column)
        {
            T_Article model = new T_Article();
            model.ArticleId = id;
            model.ArticleTitle = title;
            model.ArticleCategory = category;
            model.ArticleSector = sector;

            //model.topic = "";  用不到


            model.ArticleContent = content;
            model.ArticlePostStaff = poststaff;
            model.ArticleAnnexAddr = annexaddr;
            model.ArticleTime = time;
            model.ArticleColumn = column;
            return model;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using whut.xljk.MODEL;
using whut.xljk.BLL;
using COMMON;


namespace EmptyProjectNet45_FineUI
{

    public partial class articleList : System.Web.UI.Page
    {

        //新闻类别
        //1.中心概况
        //2.中心动态
        //3.心协动态
        //4.咨询师简介
        //5.心灵驿站

        public string leftList { get; set; }
        public string urlReq { get; set; }
        public string FirstTitle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["articleCategory"] != "" && Request["articleCategory"] != null)
            {
                int category = Convert.ToInt32(Context.Request["articleCategory"]);

                //图片链接地址
                //urlReq = category; 
                //case判断category
                switch (category)
                {
                    case 1:
                        urlReq = "images/center_conclude_icon.png";
                        //直接跳转到唯一的一个页面
                        break;
                    case 2:
                        urlReq = "images/center_conclude_icon.png";
                        break;
                    case 3:
                        urlReq = "images/center_conclude_icon.png";
                        break;
                    case 4:
                        urlReq = "images/center_conclude_icon.png";
                        break;
                    case 5:
                        urlReq = "images/center_conclude_icon.png";
                        break;
                };
                leftList = GenerateContent(category);
            }
            else
            {
                Response.Redirect("error.html");
            }
        }

        //获得专题中的新闻列表
        private String GenerateContent(int category)
        {
            StringBuilder sb = new StringBuilder();
            List<T_Article> list = new List<T_Article>();
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int total = 0;

            ArticleBLL bll = new ArticleBLL();
            list = bll.GetListByCategory(pageIndex, pageSize, category, out total);

            //形成列表
            if (list.Count > 0)
            {
                foreach (T_Article model in list)
                {
                    sb.AppendFormat("<li><a href='articleDetail.aspx?articleid={0}'  target='_blank'>{1}</a><span>{2}</span></li>", model.ArticleId, model.ArticleTitle, model.ArticleTime);
                }
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
            return sb.ToString();
        }
    }
}
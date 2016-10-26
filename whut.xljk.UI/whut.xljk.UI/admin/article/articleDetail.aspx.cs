using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.MODEL;


namespace EmptyProjectNet45_FineUI.admin.article
{
    public partial class articleDetail : System.Web.UI.Page
    {
        public T_Article model { get; set; }
        public string topicBind { get; set; }
        ArticleBLL bll = new ArticleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request["id"] ?? "00000000";
                model = bll.GetArticleById(id);//直接绑定

                txtid.Text =  model.ArticleId;
                title.Text = model.ArticleTitle;
                writer.Text = model.ArticlePostStaff;
                time.Text = model.ArticleTime;
                resourse.Text = model.ArticleSector;
                txtcontent.Text = model.ArticleContent;

                
                //绑定类别下拉菜单
                category.SelectedIndex = model.ArticleCategory - 1;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string id = Request["id"] ?? "00000000";

            T_Article model = new T_Article();
            model = bll.GetArticleById(id);
             model.ArticleId = txtid.Text.Trim(); ;
             model.ArticleTitle = title.Text.Trim() ;
             model.ArticlePostStaff = writer.Text.Trim() ;
             model.ArticleTime = time.Text.Trim() ;
             model.ArticleSector = resourse.Text.Trim() ;
             model.ArticleContent = txtcontent.Text.Trim() ;
            


            
            if(bll.Update(model))
            {
                Response.Write("文章内容修改成功，请关闭窗口~");
            }
            else
            {
                Response.Write("文章内容修改失败");
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.MODEL;
using whut.xljk.COMMON;
using System.Data;
using System.Data.SqlClient;

namespace EmptyProjectNet45_FineUI
{
    public partial class qaonline : System.Web.UI.Page
    {
        UserBLL userBLL = new UserBLL();
        MessageBLL messageBLL = new MessageBLL();

        public string MessageList { get; set; }
        public string NavHtml { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txb_NickName.Attributes.Add("style", "width:10vw");
                txb_Grade.Attributes.Add("style", "width:10vw");
                txb_BriefQuestion.Attributes.Add("style", "width:40vw");
                txb_DetailQuestion.Attributes.Add("style", "width:40vw; height:15vw;");
                rbl_Sex.Attributes.Add("style", "width:10vw");

                //ddl_TeacherName.DataSource = userBLL.GetTeacher();
                //ddl_TeacherName.Items.FindByText("不指定老师").Selected = true;
                //ddl_TeacherName
                DataBinding();


                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "3");
                int total = 0;
                int category = int.Parse(Request.QueryString["category"] ?? "0"); // 借用文章按类别分页

                if(category == 0)
                {
                    MessageList = messageBLL.GetAllMessageListString(pageIndex, pageSize, out total);
                    NavHtml = COMMON.CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
                }
                else
                {
                    MessageList = messageBLL.GetMessageListString(pageIndex, pageSize, category, out total);
                    NavHtml = COMMON.CjsPager.ShowPageNavFront(pageSize, pageIndex, category, total);
                }
               
            }
        }

        private void DataBinding()
        {
            DataTable dt = userBLL.GetTeacherTable();

            ddl_TeacherName.DataTextField = "Name";
            ddl_TeacherName.DataValueField = "Account";

            DataRow dr = dt.NewRow();
            dr["Name"] = "不指定老师";
            dr["Account"] = "不指定老师";
            dt.Rows.Add(dr);
            //dt.Rows.Add("--请选择--");

            ddl_TeacherName.DataSource = dt;
            

            ListItem item = ddl_TeacherName.Items.FindByValue("不指定老师");
            if(item != null)
            {
                item.Selected = true;
            }
            // ddl_TeacherName.Items.FindByText("--请选择--").Selected = true;
            ddl_TeacherName.DataBind();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            T_Message messageModel = new T_Message();
            MessageBLL messageBLL = new MessageBLL();

            messageModel.NickName = txb_NickName.Text.ToString().Trim();
            messageModel.Grade = txb_Grade.Text.ToString().Trim();
            messageModel.Sex = rbl_Sex.SelectedValue.ToString().Trim();
            messageModel.Email = txb_Email.Text.ToString().Trim();
            //messageModel.TeacherName = txb_TeacherName.Text.ToString().Trim();

            //if(ddl_TeacherName.SelectedValue)

            messageModel.TeacherName = ddl_TeacherName.SelectedValue.ToString().Trim();
            messageModel.BriefQuestion = txb_BriefQuestion.Text.ToString().Trim();
            messageModel.DetailQuestion = txb_DetailQuestion.Text.ToString().Trim();
            messageModel.Reply = "";
            messageModel.QuestionTime = DateTime.Now;
            messageModel.ReplyTime = DateTime.Now;
            messageModel.Category = 0; // 0为未分类
            messageModel.Status = int.Parse(rbl_Reference.SelectedValue.ToString().Trim()); // 获取是否愿意展示给其他人

            int insertResult = messageBLL.Insert(messageModel);
            if(insertResult > 0)
            {
                Response.Write("<script>alert('提问成功，请等待邮件回复');location.href=qaonline.aspx</script>");
                //Response.Redirect("qaonline.aspx");
            }
            else
            {
                Response.Write("<script>alert('出了点问题请稍后再试');location.href=qaonline.aspx</script>");
                //Response.Redirect("qaonline.aspx");
            }
        }

        public void LoadMessageList()
        {
            List<T_Message> list = new List<T_Message>();
            int Category = 0;
            if(Session["Category"] != null)
            {
                Category = (int)Session["Category"];
            }
            list = messageBLL.GetMessageList(Category);
        }
    }
}
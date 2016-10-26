using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using whut.xljk.MODEL;
using whut.xljk.BLL;
using System.Data;
using System.Data.SqlClient;

namespace EmptyProjectNet45_FineUI.admin.message
{
    public partial class Operation : System.Web.UI.Page
    {
        MessageBLL messageBLL = new MessageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {

            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            string id = Request.QueryString["id"].Trim();

            if (id != null)
            {
                int messageID = int.Parse(id);

                List<T_Message> message = messageBLL.GetMessageById(messageID);
                txb_NickName.Text = message[0].NickName;
                txb_Sex.Text = message[0].Sex;

                txa_BriefQuestion.Text = message[0].BriefQuestion;
                txa_DetailQuestion.Text = message[0].DetailQuestion;
                HtmlEditor1.Text = message[0].Reply;

                #region dropdownlist status 的一些操作

                ddl_Status.DataTextField = "StatusText";
                ddl_Status.DataValueField = "StatusValue";

                DataTable dt = new DataTable();
                dt.Columns.Add("StatusText", typeof(string));
                dt.Columns.Add("StatusValue", typeof(int));

                DataRow dr = dt.NewRow();
                dr["StatusText"] = "不同意展示";
                dr["StatusValue"] = 0;
                dt.Rows.Add(dr);
                DataRow dr2 = dt.NewRow();
                dr2["StatusText"] = "未纳入精选";
                dr2["StatusValue"] = 1;
                dt.Rows.Add(dr2);
                DataRow dr3 = dt.NewRow();
                dr3["StatusText"] = "已纳入精选";
                dr3["StatusValue"] = 2;
                dt.Rows.Add(dr3);

                ddl_Status.DataSource = dt;

                ddl_Status.DataBind();

                if (message[0].Status == 0)
                {
                    FineUI.ListItem item = ddl_Status.Items.FindByValue("0");
                    if(item != null)
                    {
                        ddl_Status.Items.FindByValue("0").Selected = true;
                    }
                    ddl_Status.Enabled = false;
                }
                else if (message[0].Status == 1)
                {
                    FineUI.ListItem item = ddl_Status.Items.FindByValue("1");
                    if (item != null)
                    {
                        ddl_Status.Items.FindByValue("1").Selected = true;
                    }

                    // 不同意展示的选项设置为不可选
                    FineUI.ListItem item0 = ddl_Status.Items.FindByValue("0");
                    if (item != null)
                    {
                        ddl_Status.Items.FindByValue("0").EnableSelect = false;
                    }

                    // ddl_Status.Text = "未纳入精选";
                }
                else if (message[0].Status == 2)
                {
                    FineUI.ListItem item = ddl_Status.Items.FindByValue("2");
                    if (item != null)
                    {
                        ddl_Status.Items.FindByValue("2").Selected = true;
                    }

                    // 不同意展示的选项设置为不可选
                    FineUI.ListItem item0 = ddl_Status.Items.FindByValue("0");
                    if (item != null)
                    {
                        ddl_Status.Items.FindByValue("0").EnableSelect = false;
                    }

                    // ddl_Status.Text = "已纳入精选";
                }

                //ddl_Status.DataBind();

                #endregion

                #region ddl_Category 的一些操作

                ddl_Categpry.DataTextField = "CategoryName";
                ddl_Categpry.DataValueField = "CategoryValue";

                DataTable dtCategory = new DataTable();
                dtCategory.Columns.Add("CategoryName", typeof(string));
                dtCategory.Columns.Add("CategoryValue", typeof(int));

                DataRow drCategory0 = dtCategory.NewRow();
                drCategory0["CategoryName"] = "--请选择--";
                drCategory0["CategoryValue"] = "0";
                dtCategory.Rows.Add(drCategory0);
                DataRow drCategory1 = dtCategory.NewRow();
                drCategory1["CategoryName"] = "个人发展";
                drCategory1["CategoryValue"] = "1";
                dtCategory.Rows.Add(drCategory1);
                DataRow drCategory2 = dtCategory.NewRow();
                drCategory2["CategoryName"] = "恋爱";
                drCategory2["CategoryValue"] = "2";
                dtCategory.Rows.Add(drCategory2);
                DataRow drCategory3 = dtCategory.NewRow();
                drCategory3["CategoryName"] = "情绪";
                drCategory3["CategoryValue"] = "3";
                dtCategory.Rows.Add(drCategory3);
                DataRow drCategory4 = dtCategory.NewRow();
                drCategory4["CategoryName"] = "人际";
                drCategory4["CategoryValue"] = "4";
                dtCategory.Rows.Add(drCategory4);
                DataRow drCategory5 = dtCategory.NewRow();
                drCategory5["CategoryName"] = "神经质";
                drCategory5["CategoryValue"] = "5";
                dtCategory.Rows.Add(drCategory5);
                DataRow drCategory6 = dtCategory.NewRow();
                drCategory6["CategoryName"] = "适应";
                drCategory6["CategoryValue"] = "6";
                dtCategory.Rows.Add(drCategory6);
                DataRow drCategory7 = dtCategory.NewRow();
                drCategory7["CategoryName"] = "学习";
                drCategory7["CategoryValue"] = "7";
                dtCategory.Rows.Add(drCategory7);
                DataRow drCategory8 = dtCategory.NewRow();
                drCategory8["CategoryName"] = "人格";
                drCategory8["CategoryValue"] = "8";
                dtCategory.Rows.Add(drCategory8);
                DataRow drCategory9 = dtCategory.NewRow();
                drCategory9["CategoryName"] = "自我";
                drCategory9["CategoryValue"] = "9";
                dtCategory.Rows.Add(drCategory9);
                DataRow drCategory10 = dtCategory.NewRow();
                drCategory10["CategoryName"] = "其他";
                drCategory10["CategoryValue"] = "10";
                dtCategory.Rows.Add(drCategory10);

                ddl_Categpry.DataSource = dtCategory;
                ddl_Categpry.DataBind();

                // 选中该纪录对应的Category
                switch(message[0].Category)
                {
                    case 0: ddl_Categpry.Items.FindByValue("0").Selected = true; break;
                    case 1: ddl_Categpry.Items.FindByValue("1").Selected = true; break;
                    case 2: ddl_Categpry.Items.FindByValue("2").Selected = true; break;
                    case 3: ddl_Categpry.Items.FindByValue("3").Selected = true; break;
                    case 4: ddl_Categpry.Items.FindByValue("4").Selected = true; break;
                    case 5: ddl_Categpry.Items.FindByValue("5").Selected = true; break;
                    case 6: ddl_Categpry.Items.FindByValue("6").Selected = true; break;
                    case 7: ddl_Categpry.Items.FindByValue("7").Selected = true; break;
                    case 8: ddl_Categpry.Items.FindByValue("8").Selected = true; break;
                    case 9: ddl_Categpry.Items.FindByValue("9").Selected = true; break;
                }

                #endregion

                txb_NickName.Enabled = false;

                txb_Sex.Enabled = false;

            }

            else
            {
                Alert alert = new Alert();
                alert.Message = "出错啦 请稍后再试";
                alert.Target = Target.Top;
                alert.Show();
            }

        }


        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑
            int messageID = int.Parse(Request.QueryString["id"].Trim());
            List<T_Message> message = messageBLL.GetMessageById(messageID);
            T_Message messageModel = new T_Message();

            messageModel.ID = messageID;
            messageModel.NickName = message[0].NickName;
            messageModel.Grade = message[0].Grade;
            messageModel.Sex = message[0].Sex;
            messageModel.QuestionTime = message[0].QuestionTime;
            messageModel.TeacherName = message[0].TeacherName;
            messageModel.Email = message[0].Email;

            messageModel.Category = int.Parse(ddl_Categpry.SelectedValue);
            messageModel.Status = int.Parse(ddl_Status.SelectedValue);
            messageModel.BriefQuestion = txa_BriefQuestion.Text.Trim();
            messageModel.DetailQuestion = txa_DetailQuestion.Text.Trim();
            messageModel.Reply = HtmlEditor1.Text.Trim();
            messageModel.ReplyTime = DateTime.Now;

            int result = messageBLL.Update(messageModel);
            if (result > 0)
            {
                Alert alert = new Alert();
                alert.Message = "处理成功";
                alert.Target = Target.Top;
                alert.Show();
            }
            else
            {
                Alert alert = new Alert();
                alert.Message = "出现问题，请稍后再试";
                alert.Target = Target.Top;
                alert.Show();
            }

            // 2. 关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        
    }
}
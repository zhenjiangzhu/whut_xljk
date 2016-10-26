using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using whut.xljk.BLL;
using whut.xljk.MODEL;

namespace EmptyProjectNet45_FineUI.admin.message
{
    public partial class messageNotHandled : System.Web.UI.Page
    {
        MessageBLL messageBLL = new MessageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["teacherName"] = "zhuz";
            if(!IsPostBack)
            {
                BindGrid();
                
            }
        }

        protected void rbtnAuto_CheckedChanged(object sender, CheckedEventArgs e)
        {

        }

        #region DataBind Grid绑定数据

        private void AutoBindGrid()
        {
            if (ViewState["BindGrid1"] != null && Convert.ToBoolean(ViewState["BindGrid1"]))
            {
                BindGrid();
                ViewState["BindGrid1"] = false;
            }
            else
            {
                BindGrid2();
                ViewState["BindGrid1"] = true;
            }
        }
        
        private void BindGrid()
        {

            DataTable dt = new DataTable(); 

            string teacherName = Session["teacherName"].ToString();
            if(teacherName.Equals("不指定老师"))
            {
                dt = messageBLL.GetAllMessageNotReplied();
            }
            else
            {
                dt = messageBLL.GetAllMessageNotRepliedByTeacher(teacherName);
                DataTable dt1 = messageBLL.GetAllMessageNotRepliedByTeacher("不指定老师");
                dt.Merge(dt1);
            }
            

            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        private void BindGrid2()
        {
            DataTable dt = new DataTable();

            string teacherName = Session["teacherName"].ToString();
            if (teacherName.Equals("不指定老师"))
            {
                dt = messageBLL.GetAllMessageNotReplied();
            }
            else
            {
                dt = messageBLL.GetAllMessageNotRepliedByTeacher(teacherName);
                DataTable dt1 = messageBLL.GetAllMessageNotRepliedByTeacher("不指定老师");
                dt.Merge(dt1);
            }

            Grid1.DataSource = dt;
            Grid1.DataBind();
        }
 

        #endregion

        #region events 表格事件

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "reply")
            {
                
            }
            else if(e.CommandName == "delete")
            {
                int id = int.Parse(Grid1.DataKeys[e.RowIndex].GetValue(0).ToString());
                int deleteResult = messageBLL.Delete(id);

                if (deleteResult > 0)
                {
                    Alert alert = new Alert();
                    alert.Message = "删除成功";
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

                BindGrid();
            }
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            AutoBindGrid();
        }
 

        #endregion
    }
}
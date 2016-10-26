using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using FineUI;
using System.Text;
using System.IO;
using AspNet = System.Web.UI.WebControls;
using EmptyProjectNet45_FineUI.admin.common;
using whut.xljk.BLL;

namespace EmptyProjectNet45_FineUI.admin.file
{
    public partial class fileList : System.Web.UI.Page, ISingleGridPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 父面板增加 5px 的内边距（显示表格的边框时，看起来比较美观）
                (Master.FindControl("Panel1") as Panel).BodyPadding = "5px";
                BindGrid();
            }
        }

        #region BindGrid

        /// <summary>
        /// [ISingleGridPage]重新绑定表格
        /// </summary>
        public void BindGrid()
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount();
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable();
            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        /// <summary>
        /// 绑定下拉菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            //System.Web.UI.WebControls.Label news_state = (System.Web.UI.WebControls.Label)Grid1.Rows[e.RowIndex].FindControl("news_state");

            ////List<string> news_statelist = new List<string>();
            ////news_statelist.Add("头条新闻");
            ////news_statelist.Add("强调新闻");
            ////news_statelist.Add("普通新闻");
            ////news_state.DataSource = news_statelist;
            ////news_state.DataBind();


            //DataRowView row = e.DataItem as DataRowView;

            //int state = Convert.ToInt32(row["news_state"]);
            //if (state == 1)
            //{
            //    news_state.Text = "头条新闻";
            //}
            //else if (state == 2)
            //{
            //    news_state.Text = "强调新闻";
            //}
            //else
            //{
            //    news_state.Text = "普通新闻";
            //}

        }

        /// <summary>
        /// 返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            whut.xljk.BLL.FileBLL bll = new whut.xljk.BLL.FileBLL();
            bll.GetAllList();
            return bll.GetAllList().Tables[0].Rows.Count;

        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable()
        {
            whut.xljk.BLL.FileBLL bll = new whut.xljk.BLL.FileBLL();
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;

            DataTable table2 = bll.GetAllList().Tables[0];
            DataView view2 = table2.DefaultView;
            view2.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable table = view2.ToTable();

            DataTable paged = table.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }

            return paged;
        }

        #endregion

        #region ISingleGridPage

        /// <summary>
        /// [ISingleGridPage]删除表格数据
        /// </summary>
        public void DeleteSelectedRows()
        {
            whut.xljk.BLL.FileBLL bll = new whut.xljk.BLL.FileBLL();

            foreach (int n in Grid.SelectedRowIndexArray)
            {
                object[] keys = Grid1.DataKeys[n];
                String id = keys[0].ToString();
                bll.deleteFile(id);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            Alert.ShowInTop("删除选中的 " + Grid1.SelectedRowIndexArray.Length + " 项纪录！");
        }

        /// <summary>
        /// [ISingleGridPage]主表格实例
        /// </summary>
        public Grid Grid
        {
            get
            {
                return Grid1;
            }
        }

        /// <summary>
        /// [ISingleGridPage]获取新增地址
        /// </summary>
        /// <returns></returns>
        public string GetNewUrl()
        {
            return "~/admin/file/fileAdd.aspx";
        }

        /// <summary>
        /// [ISingleGridPage]获取编辑地址
        /// </summary>
        /// <returns></returns>
        public string GetEditUrl()
        {
            object[] keys = Grid1.DataKeys[Grid1.SelectedRowIndex];
            return String.Format("~/admin/file/fileDetail.aspx?id={0}&name={1}", keys[0], HttpUtility.UrlEncode(keys[1].ToString()));
        }

        #endregion


        #region Events

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Alert.ShowInTop("尚未实现！");
        }

        /// <summary>
        /// excel 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=news.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid1));
            Response.End();
        }


        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");

            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");


            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateID = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateID);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("f-grid-static-checkbox"))
                        {
                            if (html.Contains("uncheck"))
                            {
                                html = "×";
                            }
                            else
                            {
                                html = "√";
                            }
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }

                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        /// <summary>
        /// 获取控件渲染后的HTML源代码
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        ctrl.RenderControl(htw);

                        return sw.ToString();
                    }
                }
            }
            return String.Empty;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Alert.ShowInTop("尚未实现！");
        }

        #endregion

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearch.Text = String.Empty;
            ttbSearch.ShowTrigger1 = false;

            Alert.ShowInTop("尚未实现！");
        }

        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearch.ShowTrigger1 = true;

            Alert.ShowInTop("尚未实现！");
        }
    }
}
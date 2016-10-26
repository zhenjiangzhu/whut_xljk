using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using COMMON;
namespace EmptyProjectNet45_FineUI
{
    public partial class fileList : System.Web.UI.Page
    {

        FileBLL bll = new FileBLL();
        public string ListPage { get; set; }
        public string NavHtml { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int total = 0;
            

            ListPage = GetListPage(pageIndex, pageSize, out total);
            NavHtml = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
        }
        public string GetListPage(int pageIndex, int pageSize, out int total)
        {
            StringBuilder sb = new StringBuilder();
            List<T_File> list = bll.GetListByPage(pageIndex, pageSize, out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {
                    sb.AppendFormat("<li><a href='fileDetail.aspx?fileid={0}' target='_blank' title=''>【{1}】{2}</a><span>{3}</span></li>", model.FileId, model.FileSummary, model.FileTime,model.FileTime);
                }
            }
            return sb.ToString();
        }
    }
}
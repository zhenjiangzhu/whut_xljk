using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using whut.xljk.BLL;
using COMMON;

namespace EmptyProjectNet45_FineUI
{

    public partial class fileDetail : System.Web.UI.Page
    {
        public string lastFileHref { get; set; }
        public string lastFileTitle { get; set; }
        public string nextFileHref { get; set; }
        public string nextFileTitle { get; set; }

        public T_File model = new T_File();
        FileBLL bll = new FileBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fileid"] != "" || Request["fileid"] != null)
            {
                string id = Context.Request["fileid"];
                model = bll.GetModelById(id);
                if (model.FileName == null)
                {
                    Response.Redirect("error.html");
                }
                //上下篇
                List<T_File> lastFileList = bll.GetLastFile(id);
                List<T_File> nextFileList = bll.GetNextFile(id);
                if (lastFileList.Count > 0)
                {
                    lastFileHref = "FileDetail.aspx?FileId=" + lastFileList[0].FileId;
                    lastFileTitle = lastFileList[0].FileSummary;
                }
                else
                {
                    lastFileHref = "";
                    lastFileTitle = "没有了";
                }
                if (nextFileList.Count > 0)
                {
                    nextFileHref = "FileDetail.aspx?FileId=" + nextFileList[0].FileId;
                    nextFileTitle = nextFileList[0].FileSummary;
                }
                else
                {
                    nextFileHref = "";
                    nextFileTitle = "没有了";
                }
            }
            else
            {
                Response.Redirect("error.html");
            }
        }
        public string GetFilePath(string filePath)
        {
            if (filePath != null)
            {
                return filePath;
            }
            else
            {
                Response.Redirect("error.html");
                return filePath;

            }

        }
    }
}
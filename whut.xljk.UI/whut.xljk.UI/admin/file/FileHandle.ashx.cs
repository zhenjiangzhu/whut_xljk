using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using whut.xljk.MODEL;
using System.Web.Script.Serialization;
using whut.xljk.BLL;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace EmptyProjectNet45_FineUI.admin.file
{
    /// <summary>
    /// FileHandle 的摘要说明
    /// </summary>
    public class FileHandle : IHttpHandler, IReadOnlySessionState
    {
        private HttpContext context;
        FileBLL bll = new FileBLL();
        public void ProcessRequest(HttpContext context)
        {
            String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

            //文件保存目录路径
            String savePath = "/FileSavePath/";

            //文件保存目录URL
            String saveUrl = "/FileSavePath/";

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "mp3,wmv,avi,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,pdf,txt,html,txt,zip,rar");

            //最大文件大小
            int maxSize = 1000000;
            this.context = context;

            HttpPostedFile imgFile = context.Request.Files["files"];
            if (imgFile == null)
            {
                showError("请选择文件。");
            }

            String dirPath = context.Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                showError("上传目录不存在。");
            }
            string dirName = "";
            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();
            if (CheckFileExt(fileExt) != "")

                dirName = CheckFileExt(fileExt);

            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "file";
            }
            if (!extTable.ContainsKey(dirName))
            {
                showError("目录名不正确。");
            }



            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }

            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath + newFileName;

            imgFile.SaveAs(filePath);

            String fileUrl = saveUrl + newFileName;

            //构造输出显示的model
            //FileDescription fileDes = new FileDescription();
            //fileDes.FileName = Path.GetFileNameWithoutExtension(fileName);
            //fileDes.FileSize = (imgFile.ContentLength / 1024).ToString()+"KB";
            //fileDes.FileTime = DateTime.Now.ToString();
            //fileDes.FileSavePath =filePath;
            //fileDes.FileExt = fileExt;
            //构造插入内容
            T_File model = new T_File();
            model.FileId = bll.GetIdByTime(DateTime.Now.ToString("yyyyMMdd"));
            model.FileName = fileName;
            model.FilePath = fileUrl;
            model.FileExt = fileExt;
            model.FileSector = "";//(context.Session["model"] as T_InfoAdmin).InfoAdminSector;
            model.FileSummary = context.Request["summary"];
            model.FileTime = DateTime.Now.ToString();
            model.FileSector = "liushangnan";
            bll.Insert(model);
            context.Response.Redirect("fileList.aspx");
            //JavaScriptSerializer java = new JavaScriptSerializer();
            //context.Response.ContentType = "text/plain";
            //context.Response.Write(java.Serialize(fileDes));
            //context.Response.End();

            //Hashtable hash = new Hashtable();
            //hash["error"] = 0;
            //hash["url"] = fileUrl;
            //context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            //context.Response.Write(LitJson.JsonMapper.ToJson(hash));
            //context.Response.End();
        }

        private void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(LitJson.JsonMapper.ToJson(hash));
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 根据拓展名确定文件类型
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string CheckFileExt(string ext)
        {

            //获取文件的后缀名
            if (ext.Equals(".doc") || ext.Equals(".docx") || ext.Equals(".txt") || ext.Equals(".pdf") || ext.Equals(".xls") || ext.Equals(".xlsx") || ext.Equals(".rar") || ext.Equals(".zip") || ext.Equals(".html") || ext.Equals(".ppt"))
            {
                return "file";
            }
            else if (ext.Equals(".swf") || ext.Equals(".flv"))
            {
                return "flash";
            }
            //mp3,wmv,avi,rmvb
            else if (ext.Equals(".mp3") || ext.Equals(".wmv") || ext.Equals(".avi") || ext.Equals(".rmvb"))
            {
                return "media";
            }
            else return "";



        }
        public enum FileTypeExt
        {
            file,
            flash,
            media,
            image
        }
    }
}
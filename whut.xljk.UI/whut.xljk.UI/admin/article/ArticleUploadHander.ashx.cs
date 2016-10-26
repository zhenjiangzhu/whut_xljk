using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// ArticleUploadHander 的摘要说明
    /// </summary>
    public class ArticleUploadHander : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            if (context.Request.HttpMethod.Equals("POST"))
            {
                HttpPostedFile file = context.Request.Files["Filedata"];
                string uploadPath =
                    HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\";

                if (file != null)
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    //调用函数，节省处理请求代码
                    FileSave(CheckFileExt(file), file, uploadPath);
                    //保存由若干附件名组成的字符串
                    sb = SaveFileNameStr(file.FileName, sb);
                    //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
            }
            else
            {
                string txt = context.Request["txtcontent"];
                context.Response.Write(txt);

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region 文件后缀名检测
        /// <summary>
        /// 检测文件的扩展名，对应分配文件类别
        /// </summary>
        /// <param name="file">上传文件类</param>
        /// <returns>枚举，区分文件类型FileTypeExt</returns>
        
        public FileTypeExt CheckFileExt(HttpPostedFile file)
        {
            if (file != null)
            {
                //获取文件的后缀名
                string ext=Path.GetExtension(file.FileName).ToLower();
                if (ext.Equals(".doc") || ext.Equals(".docx"))
                {
                    return FileTypeExt.doc;
                }
                else if (ext.Equals(".xsl") || ext.Equals(".xslx"))
                {
                    return FileTypeExt.xsl;
                }
                else if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png") || ext.Equals("gif"))
                {
                    return FileTypeExt.img;
                }
                else if (ext.Equals(".pdf"))
                {
                    return FileTypeExt.pdf;
                }
                else
                    return FileTypeExt.rar;
            }
            return 0;
           
        
        
        }
        #endregion

        #region 检测对应路径文件是否存在
        /// <summary>
        /// 检测对应文件是否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        /// 
        public bool CheckFileExist(string filePath)
        {
            return File.Exists(filePath) ? true : false;
        }
        #endregion

        #region 文件分类保存
        /// <summary>
        /// 文件分类别保存方法
        /// </summary>
        /// <param name="type">文件类别</param>
        /// <param name="file">文件管理类</param>
        /// <param name="uploadPath">文件保存大路径</param>
        public void FileSave(FileTypeExt type, HttpPostedFile file, string uploadPath)
        {
            try
            {
                switch (type)
                {
                    case FileTypeExt.doc: uploadPath += "doc" + "\\"; break;
                    case FileTypeExt.img: uploadPath += "img" + "\\"; break;
                    case FileTypeExt.pdf: uploadPath += "pdf" + "\\"; break;
                    case FileTypeExt.rar: uploadPath += "rar" + "\\"; break;
                    default: uploadPath += "xsl" + "\\"; break;
                }
                string filepath = uploadPath + file.FileName;
                //已经存在的文件就删除，然后重新上传一遍
                if (CheckFileExist(filepath))
                    File.Delete(filepath);
                //保存
                    file.SaveAs(filepath);
                
            }
            catch 
            {
                throw;
            
            }
        }
        #endregion

        #region 保存若干文件名组成的字符串
        public StringBuilder SaveFileNameStr(string filename,StringBuilder sb)
        {
            if (sb.Length == 0)
                sb.Append(filename);
            else
                sb.AppendFormat(",{0}", filename);
            return sb;
        }
        #endregion
    }
        
    /// <summary>
    /// 枚举
    /// </summary>
    public enum FileTypeExt
    { 
        doc,
        pdf,
        xsl,
        rar,
        img
    }
    
}
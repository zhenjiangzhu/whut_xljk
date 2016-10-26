using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Drawing;


namespace COMMON
{
    public static class Fileupload
    {

        public readonly static List<string> VALID_FILE_TYPES = new List<string> {     ".png",
    ".jpg",
    ".jpeg",
    ".gif",
    ".bmp",
    ".flv",
    ".swf",
    ".mkv",
    ".avi",
    ".rm",
    ".rmvb",
    ".mpeg",
    ".mpg",
    ".ogg",
    ".ogv",
    ".mov",
    ".wmv",
    ".mp4",
    ".webm",
    ".mp3",
    ".wav",
    ".mid",
    ".rar",
    ".zip",
    ".tar",
    ".gz",
    ".7z",
    ".bz2",
    ".cab",
    ".iso",
    ".doc",
    ".docx",
    ".xls",
    ".xlsx",
    ".ppt",
    ".pptx",
    ".pdf",
    ".txt",
    ".md",
    ".xml"};

        public static bool ValidateFileType(string fileName)
        {
            string fileType = String.Empty;
            int lastDotIndex = fileName.LastIndexOf(".");
            if (lastDotIndex >= 0)
            {
                fileType = fileName.Substring(lastDotIndex + 1).ToLower();
            }
            fileType = "." + fileType;
            if (VALID_FILE_TYPES.Contains(fileType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
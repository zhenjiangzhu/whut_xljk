using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON
{
    public class newsdeal
    {
        public string getimgurl(string news_content)
        {
            //获得数据库中的第一个图片名称
            string imgurl = "/res/ueditor/net/upload/image/";
            int n = news_content.IndexOf(imgurl);
            if(n>=0)
            {
                int length = "/res/ueditor/net/upload/image/20160807/6360620667605688401672615.jpg".Length;
                imgurl = news_content.Substring(n, length);
                return imgurl;
            }
            else
            {
                return null;
            }
        }
    }
}

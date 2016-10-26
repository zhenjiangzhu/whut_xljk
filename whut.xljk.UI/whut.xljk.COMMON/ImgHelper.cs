using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace COMMON
{
    public static class ImgHelper
    {
        /// <summary>  
        /// 获取文章中图片地址的方法  
        /// </summary>  
        /// <param name="html">文章内容</param>  
        /// <param name="regstr">正则表达式</param>  
        /// <param name="keyname">关键属性名</param>  
        /// <returns></returns>  
        public static ArrayList getImgUrl(string html, string regstr, string keyname)
        {
            ArrayList resultStr = new ArrayList();
            Regex r = new Regex(regstr, RegexOptions.IgnoreCase);
            MatchCollection mc = r.Matches(html);

            foreach (Match m in mc)
            {
                resultStr.Add(m.Groups[keyname].Value.ToLower());
            }
            if (resultStr.Count > 0)
            {
                return resultStr;
            }
            else
            {
                //没有地址的时候返回空字符  
                resultStr.Add("");
                return resultStr;
            }
        }

    }
}

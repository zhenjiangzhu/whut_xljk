﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON
{
    public class CjsPager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize">一页多少条</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        public static string ShowPageNavigate(int pageSize, int currentPage, int totalCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPage != 1)
                {//处理首页连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a> ", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, currentPage - 1, pageSize);
                }
                else
                {
                    // output.Append("<span class='pageLink'>上一页</span>");
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", redirectTo, currentPage + 1, pageSize);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPages);//这个统计加不加都行
            return output.ToString();
        }

        //前台的不同a标签样式
        public static string ShowPageNavFront(int pageSize, int currentPage, int category, int totalCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='list_page_btn' href='{0}?pageIndex={1}&pageSize={2}&category={3}'><</a> ", redirectTo, currentPage - 1, pageSize, category);
                }
                else
                {
                    // output.Append("<span class='last_page'>上一页</span>");
                }

                output.Append(" ");
                int currint = 3;
                for (int i = 0; i <= 7; i++)
                {//一共最多显示7个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='selected' href='{0}?pageIndex={1}&pageSize={2}&category={4}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage, category);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a  href='{0}?pageIndex={1}&pageSize={2}&category={4}'>{3}</a> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint, category);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='list_page_btn' href='{0}?pageIndex={1}&pageSize={2}&category={3}'>></a> ", redirectTo, currentPage + 1, pageSize, category);
                }
                output.Append(" ");
            }
            return output.ToString();
        }



        public static string ShowPageNavFront(int pageSize, int currentPage, int totalCount, int sector, int category)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='list_page_btn' href='{0}?sector={1}&category={2}&pageIndex={3}&pageSize={4}'><</a> ", redirectTo, sector, category, currentPage - 1, pageSize);
                }
                else
                {
                    // output.Append("<span class='last_page'>上一页</span>");
                }

                output.Append(" ");
                int currint = 3;
                for (int i = 0; i <= 7; i++)
                {//一共最多显示7个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='selected' href='{0}?sector={1}&category={2}&pageIndex={3}&pageSize={4}'>{5}</a> ", redirectTo, sector, category, currentPage, pageSize, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a  href='{0}?sector={1}&category={2}&pageIndex={3}&pageSize={4}'>{5}</a> ", redirectTo, sector, category, currentPage + i - currint, pageSize, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='list_page_btn' href='{0}?sector={1}&category={2}&pageIndex={3}&pageSize={4}'>></a> ", redirectTo, sector, category, currentPage + 1, pageSize);
                }
                output.Append(" ");
            }
            return output.ToString();
        }
    }
}

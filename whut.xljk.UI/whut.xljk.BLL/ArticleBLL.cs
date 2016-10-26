using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using whut.xljk.DAL;
using whut.xljk.MODEL;

namespace whut.xljk.BLL
{
    public class ArticleBLL
    {
        DAL.ArticleDAL dal = new DAL.ArticleDAL();

        //上下篇
        public List<T_Article> GetLastArticle(string articleId, int articleCategory)
        {
            return DataTableToList(dal.GetLastArticle(articleId, articleCategory));
        }

        public List<T_Article> GetNextArticle(string articleId, int articleCategory)
        {
            return DataTableToList(dal.GetNextArticle(articleId, articleCategory));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// 业务逻辑层添加model方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertArticle(T_Article model)
        {
            ArticleDAL dal = new ArticleDAL();
            return dal.Insert(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_Article model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }
        //根据部门获取列表
        public List<T_Article> GetListBySector(int pageIndex, int pageSize, string sector, int category, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, category, out total));
        }

        /// <summary>
        /// 根据查询的条数得到新闻通知的集合
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<T_Article> GetNoticeModelListByNum(int total, int category)
        {
            return DataTableToList(dal.GetNoticeDateTableByNum(total, category));

        }
        //转化成modal
        public List<T_Article> DataTableToList(DataTable table)
        {
            List<T_Article> list = new List<T_Article>();
            int rowCount = table.Rows.Count;
            if (rowCount > 0)
            {
                T_Article model;
                for (int i = 0; i < rowCount; i++)
                {

                    model = dal.DataRowToModel(table.Rows[i]);
                    if (model != null)
                        list.Add(model);

                }


            }
            return list;

        }
        //通过文章ID获得文章
        public T_Article GetArticleById(string id)
        {
            return dal.GetArticleById(id);
        }

        //根据日期时间模糊查询获取编号
        public string GetIdByTime(string dateTime)
        {
            T_Article AricleModel = new T_Article();
            DataTable articl = dal.GetIdByTime(dateTime);
            string str = null;
            if (articl.Rows.Count == 0)
            {
                str = dateTime + "001";
            }
            else
            {
                AricleModel.ArticleId = articl.Rows[0]["C_ArticleId"].ToString().Trim();
                int strId = Int32.Parse(AricleModel.ArticleId.Substring(8, 3)) + 1;
                if (strId >= 10)
                {
                    str = dateTime + "0" + strId.ToString().Trim();
                }
                else if (strId >= 100)
                {
                    str = dateTime + "0" + strId.ToString().Trim();
                }
                else
                {
                    str = dateTime + "00" + strId.ToString().Trim();
                }
            }
            return str;

        }

        //根据栏目id获取文章list集合
        public List<T_Article> GetListByColId(string columnid)
        {
            DataTable tb = new DataTable();
            tb = dal.GetListByColId(columnid);
            List<T_Article> list = new List<T_Article>();
            if (tb.Rows.Count > 0)
            {

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    T_Article model = new T_Article();
                    if (tb.Rows[i]["C_ArticleId"] != null && tb.Rows[i]["C_ArticleId"].ToString() != "")
                    {
                        model.ArticleId = tb.Rows[i]["C_ArticleId"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleTitle"] != null)
                    {
                        model.ArticleTitle = tb.Rows[i]["C_ArticleTitle"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleSector"] != null)
                    {
                        model.ArticleSector = tb.Rows[i]["C_ArticleSector"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleCategory"] != null)
                    {
                        model.ArticleCategory = int.Parse(tb.Rows[i]["C_ArticleCategory"].ToString());
                    }
                    if (tb.Rows[i]["C_ArticleContent"] != null)
                    {
                        model.ArticleContent = tb.Rows[i]["C_ArticleContent"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleColumn"] != null && tb.Rows[i]["C_ArticleColumn"].ToString() != "")
                    {

                        model.ArticleColumn = tb.Rows[i]["C_ArticleColumn"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleTopic"] != null && tb.Rows[i]["C_ArticleTopic"].ToString() != "")
                    {
                        model.topic = new T_Topic();
                        model.topic.TopicId = int.Parse(tb.Rows[i]["C_ArticleTopic"].ToString());
                    }
                    if (tb.Rows[i]["C_ArticlePostStaff"] != null)
                    {
                        model.ArticlePostStaff = tb.Rows[i]["C_ArticlePostStaff"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleAnnexAddr"] != null)
                    {
                        model.ArticleAnnexAddr = tb.Rows[i]["C_ArticleAnnexAddr"].ToString();
                    }
                    model.ArticleAnnexAddr = "0";
                    if (tb.Rows[i]["C_ArticleTime"] != null)
                    {
                        DateTime time = DateTime.Parse(tb.Rows[i]["C_ArticleTime"].ToString());
                        model.ArticleTime = time.ToString("yyyy-MM-dd");
                        //model.ArticleTime = Convert.ToDateTime((DateTime.Parse(row["C_ArticleTime"].ToString()).ToShortDateString().ToString()));
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        

        ////获取文章内容中有图片标签的list
        public List<T_Article> GetListByContent(int total, int category)
        {
            List<T_Article> list = DataTableToList(dal.GetListByContent(total, category));
            Regex re = new Regex(@"<img[\b\t\s\n]*[^<>]*[\b\t\s\n]*src=['""]/ArticleContentFile.*?['""][^<>]*?/>");
            foreach (var model in list)
            {
                Match mar = re.Match(model.ArticleContent);
                model.ArticleContent = mar.Value;
            }
            return list;

        }

        ///根据起始记录和终止记录和文章类型获取list集合
        public List<T_Article> GetListByIndexCategory(int beginIndex, int endIndex, int cateGory)
        {
            return DataTableToList(dal.GetListByIndexCategory(beginIndex, endIndex, cateGory));
        }
        //根据查询的附件字符串解析附件地址
        public string[] GetAnnexAddrByAnnex(string annex)
        {

            string[] sp = null;

            if (annex.IndexOf(',') > 0)
            { sp = annex.Split(','); }
            else
                sp = new string[] { annex };

            for (int i = 0; i < sp.Length; i++)
            {
                string downloadPath = "/ArticleUploadFile/";
                FileTypeExt type = CheckFileExt(sp[i]);
                switch (type)
                {
                    case FileTypeExt.doc: downloadPath += "doc" + "/"; break;
                    case FileTypeExt.img: downloadPath += "img" + "/"; break;
                    case FileTypeExt.pdf: downloadPath += "pdf" + "/"; break;
                    case FileTypeExt.rar: downloadPath += "rar" + "/"; break;
                    default: downloadPath += "xsl" + "/"; break;
                }
                sp[i] = downloadPath + sp[i];
            }
            return sp;
        }
        //检测附件的扩展名
        public FileTypeExt CheckFileExt(string str)
        {
            if (str != null)
            {
                //获取文件的后缀名
                string ext = Path.GetExtension(str).ToLower();
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
        public List<T_Article> GetListByTopic(int pageIndex, int pageSize, int topicid, out int total)
        {
            return DataTableToList(dal.GetListByTopic(pageIndex, pageSize, topicid, out total));
        }
        //根据类型分页
        public List<T_Article> GetListByCategory(int pageIndex, int pageSize, int category, out int total)
        {
            return DataTableToList(dal.GetListByCategory(pageIndex, pageSize, category, out total));
        }
        //根据部门获取分页
        public List<T_Article> GetListBySector(int pageIndex, int pageSize, string sector, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, out total));

        }
        //根据部门，类型分页
        public List<T_Article> GetListBySectorAndCategory(int pageIndex, int pageSize, string sector, int category, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, category, out total));
        }
        //根据标题分页
        public List<T_Article> GetListByTitle(int pageIndex, int pageSize, string title, out int total)
        {
            return DataTableToList(dal.GetListByTitle(pageIndex, pageSize, title, out total));
        }

        //根据部门、标题分页
        public List<T_Article> GetListByTitleAndSector(int pageIndex, int pageSize, string sector, string title, out int total)
        {
            return DataTableToList(dal.GetListByTitleAndSector(pageIndex, pageSize, sector, title, out total));
        }


    }
}

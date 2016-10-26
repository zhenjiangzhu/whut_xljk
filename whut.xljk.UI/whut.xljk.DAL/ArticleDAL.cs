using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using COMMON;

namespace whut.xljk.DAL
{
    public class ArticleDAL
    {

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ArticleId,C_ArticleTitle,C_ArticleSector,C_ArticleCategory,C_ArticleTopic,C_ArticleContent,C_ArticlePostStaff,C_ArticleAnnexAddr,C_ArticleTime,C_ArticleColumn ");
            strSql.Append(" FROM T_Article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        //对应文章表的增删改查方法
        /// <summary>
        ///得到文章总条数
        /// </summary>
        /// <returns>文章总条数</returns>
        public int GetRecordCountFromArticle()
        {
            string sql = "select COUNT(*) from T_Article";
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text);
        }


        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">传入model类</param>
        /// <returns></returns>
        public int Insert(T_Article model)
        {
            //C_ArticleId, C_ArticleTitle, C_ArticleSector, C_ArticleCategory, C_ArticleTopic, C_ArticleContent, C_ArticlePostStaff, C_ArticleAnnexAddr, C_ArticleTime
            string sql = "insert into T_Article values(@id,@title,@sector,@category,@topic,@content,@poststaff,@annexaddr,@time,@column)";

            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@id",model.ArticleId),
            new SqlParameter("@title",model.ArticleTitle),
            new SqlParameter("@sector",model.ArticleSector),
            new SqlParameter("@category",model.ArticleCategory),
            new SqlParameter("@topic",model.topic==null?DBNull.Value:(object)model.topic.TopicId),
            new SqlParameter("@content",model.ArticleContent),
            new SqlParameter("@poststaff",model.ArticlePostStaff),
            new SqlParameter("@annexaddr",model.ArticleAnnexAddr),
            new SqlParameter("@time",model.ArticleTime),
            new SqlParameter("@column",model.ArticleColumn==""?"00000000":model.ArticleColumn)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Article set ");
            strSql.Append("C_ArticleId=@id,");
            strSql.Append("C_ArticleTitle=@title,");
            strSql.Append("C_ArticleSector=@sector,");
            strSql.Append("C_ArticleCategory=@category,");
            strSql.Append("C_ArticleTopic=@topic,");
            strSql.Append("C_ArticleContent=@content,");
            strSql.Append("C_ArticlePostStaff=@poststaff,");
            strSql.Append("C_ArticleAnnexAddr=@annexaddr,");
            strSql.Append("C_ArticleColumn=@column");
            strSql.Append(" where C_ArticleId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,11),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@sector", SqlDbType.NVarChar,40),
					new SqlParameter("@category", SqlDbType.Int),
					new SqlParameter("@topic", SqlDbType.Int),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@poststaff", SqlDbType.NVarChar,20),
					new SqlParameter("@annexaddr", SqlDbType.NVarChar,200),
                    
                    new SqlParameter("@column", SqlDbType.Char,8)};
            parameters[0].Value = model.ArticleId;
            parameters[1].Value = model.ArticleTitle;
            parameters[2].Value = model.ArticleSector;
            parameters[3].Value = model.ArticleCategory;
            if (model.topic != null)
                parameters[4].Value = model.topic.TopicId;
            else
                parameters[4].Value = DBNull.Value;
            parameters[5].Value = model.ArticleContent;
            parameters[6].Value = model.ArticlePostStaff;
            parameters[7].Value = model.ArticleAnnexAddr;

            parameters[8].Value = model.ArticleColumn;
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model">传入对象实体</param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Article ");
            strSql.Append("where C_ArticleId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,11)
			};
            parameters[0].Value = id;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Article ");
            strSql.Append(" where C_ArticleId in (" + idlist + ")  ");
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //根据部门获取列表
        public DataTable GetListBySector(int pageIndex, int pageSize, string sector, int category, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@sector",sector),
                                  new SqlParameter("@category",category),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListBySector", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;

        }





        //public List<T_xljkArticle> GetArticleList(int i)
        //{
        //List<T_xljkArticle> list = new List<T_xljkArticle>();
        //if(i==1)
        //{
        //string sql = "select top 3 from" ;
        //using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
        //{
        //    if (reader.HasRows)
        //    {
        //        //reader.GetOrdinal("clsName");
        //        while (reader.Read())
        //        {
        //            //Fid, FName, FAge, FGender, FMath, FEnglish, FClassId, FBirthday
        //            MyStudent model = new MyStudent();
        //            model.FId = reader.GetInt32(0);
        //            model.FName = reader.GetString(1);
        //            model.FAge = reader.GetInt32(2);
        //            model.FGender = reader.GetString(3);
        //            model.FMath = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
        //            model.FEnglish = reader.GetInt32(5);
        //            model.ClassModel = new MyClass();
        //            model.ClassModel.ClassId = reader.GetInt32(6);
        //            model.ClassModel.ClassName = reader.GetString(8);
        //            model.FBirthday = reader.GetDateTime(7);

        //            list.Add(model);
        //        }
        //    }
        //}
        //return list;


        //}

        /// <summary>
        /// 转化datarow 到文章实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public T_Article DataRowToModel(DataRow row)
        {
            T_Article model = new T_Article();
            if (row != null)
            {
                if (row["C_ArticleId"] != null && row["C_ArticleId"].ToString() != "")
                {
                    model.ArticleId = row["C_ArticleId"].ToString();
                }
                if (row["C_ArticleTitle"] != null)
                {
                    model.ArticleTitle = row["C_ArticleTitle"].ToString();
                }
                if (row["C_ArticleSector"] != null)
                {
                    model.ArticleSector = row["C_ArticleSector"].ToString();
                }
                if (row["C_ArticleCategory"] != null)
                {
                    model.ArticleCategory = int.Parse(row["C_ArticleCategory"].ToString());
                }
                if (row["C_ArticleContent"] != null)
                {
                    model.ArticleContent = row["C_ArticleContent"].ToString();
                }
                if (row["C_ArticleColumn"] != null && row["C_ArticleColumn"].ToString() != "")
                {
                    model.ArticleColumn = row["C_ArticleColumn"].ToString();
                }
                if (row["C_ArticleTopic"] != null && row["C_ArticleTopic"].ToString() != "")
                {
                    model.topic = new T_Topic();
                    model.topic.TopicId = int.Parse(row["C_ArticleTopic"].ToString());
                }
                if (row["C_ArticlePostStaff"] != null)
                {
                    model.ArticlePostStaff = row["C_ArticlePostStaff"].ToString();
                }
                if (row["C_ArticleAnnexAddr"] != null)
                {
                    model.ArticleAnnexAddr = row["C_ArticleAnnexAddr"].ToString();
                }
                else
                {
                    model.ArticleAnnexAddr = "";
                }
                if (row["C_ArticleTime"] != null)
                {
                    DateTime time = DateTime.Parse(row["C_ArticleTime"].ToString());
                    model.ArticleTime = time.ToString("yyyy-MM-dd");
                    //model.ArticleTime = Convert.ToDateTime((DateTime.Parse(row["C_ArticleTime"].ToString()).ToShortDateString().ToString()));
                }

            }
            return model;




        }

        /// <summary>
        /// 根据文章类型和条数获取datatable
        /// </summary>
        /// <param name="total">总条数</param>
        /// <param name="category">文章分类</param>
        /// <returns></returns>
        public DataTable GetNoticeDateTableByNum(int total, int category)
        {
            string sql = "select top " + total + " * from T_Article where C_ArticleCategory=" + category + "order by C_ArticleTime desc";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, null);
        }



        /// <summary>
        /// 根据id来获取文章实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_Article GetArticleById(string id)
        {
            SqlParameter[] sp = { new SqlParameter("@id", id) };
            string sql = "select * from T_Article where C_ArticleId=@id";
            T_Article model = new T_Article();
            DataTable tb = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;

        }

        /// <summary>
        /// 获取同类型文章前一条记录
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="articleCategory"></param>
        /// <returns></returns>
        public DataTable GetLastArticle(string articleId, int articleCategory)
        {
            string sql = "select * from T_Article where C_ArticleId < '" + articleId + "' and C_ArticleCategory=" + articleCategory + " order by C_ArticleId desc";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        /// <summary>
        /// 获取同类型文章后一条记录
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="articleCategory"></param>
        /// <returns></returns>
        public DataTable GetNextArticle(string articleId, int articleCategory)
        {
            string sql = "select * from T_Article where C_ArticleId > '" + articleId + "' and C_ArticleCategory=" + articleCategory + " order by C_ArticleId";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }


        //根据日期模糊查询获取编号
        public DataTable GetIdByTime(string dateTime)
        {

            string sql = string.Format("select top(1) *from T_Article where(C_ArticleId like '{0}%') order by C_ArticleId desc", dateTime);
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);

        }

        //根据栏目id获取文章datatable
        public DataTable GetListByColId(string columnid)
        {
            string sql = "select * from T_Article where C_ArticleColumn=@column order by C_ArticleTime desc";
            SqlParameter[] pms = { new SqlParameter("@column", columnid) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, pms);
        }
        //获取文章内容中有图片标签的list
        //获取文章内容中有图片标签的list
        public DataTable GetListByContent(int total, int category)
        {
            string sql = "select top " + total + " * from T_Article where C_ArticleCategory=" + category + " and C_ArticleContent like '%<img%/>%' order by C_ArticleTime desc";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        ///根据起始记录和终止记录和文章类型获取list集合
        public DataTable GetListByIndexCategory(int beginIndex, int endIndex, int cateGory)
        {
            string sql = "select top " + beginIndex + " * from T_Article where C_ArticleId not in (select top " + endIndex + " C_ArticleId from T_Article where C_ArticleCategory=" + cateGory + " order by C_ArticleTime desc) and C_ArticleCategory=" + cateGory + " order by C_ArticleTime desc";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        //根据存储过程来查询专题的文章集合
        public DataTable GetListByTopic(int pageIndex, int pageSize, int topicid, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@topicid",topicid),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListByTopic", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;

        }
        //根据文章类型分页获取文章list
        public DataTable GetListByCategory(int pageIndex, int pageSize, int category, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@category",category), 
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListByCategory", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;
        }
        //根据文章部门分页获取list
        public DataTable GetListBySector(int pageIndex, int pageSize, string sector, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@sector",sector), 
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListByInfoAdminSector", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;
        }
        //根据文章部门，类型分页获取List
        public DataTable GetListBySectorAndCategory(int pageIndex, int pageSize, string sector, int category, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@sector",sector), 
                                  new SqlParameter("@category",category),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListBySector", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;
        }
        //根据标题分页获取List
        public DataTable GetListByTitle(int pageIndex, int pageSize, string title, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@title",title),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListByTitle", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;

        }
        //根据文章部门，标题分页获取List
        public DataTable GetListByTitleAndSector(int pageIndex, int pageSize, string sector, string title, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@sector",sector), 
                                  new SqlParameter("@title",title),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PArticleListByTitleAndSector", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;

        }
    }
}

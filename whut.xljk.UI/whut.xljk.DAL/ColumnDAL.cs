using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using COMMON;

namespace whut.xljk.DAL
{
   public class ColumnDAL
    {
        //根据父节点获取子节点
        public DataTable GetColDataTableByParent(string parent)
        {
            string sql = "select * from T_Column where C_ColumnParent=@parent and C_ColumnDelStatus!=1";
            SqlParameter[] sp = { new SqlParameter("@parent", parent) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }
        //插入model
        public int InsertColumn(T_Column model)
        {
            string sql = "insert into T_Column values(@ColumnId,@ColumnName,@ColumnStatus,@ColumnContent,@ColumnParent,@ColumnDelStatus)";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@ColumnId",model.ColumnId),
            new SqlParameter("@ColumnName",model.ColumnName),
            new SqlParameter("@ColumnStatus",model.ColumnStatus),
            new SqlParameter("@ColumnContent",model.ColumnContent),
            new SqlParameter("@ColumnParent",model.ColumnParent),
            new SqlParameter("@ColumnDelStatus",model.ColumnDelStatus),
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }




        public int GetRecordByParent(string parent)
        {
            string sql = "select count(*) from T_Column where C_ColumnParent=@parent";
            SqlParameter[] sp = { new SqlParameter("@parent", parent) };
            return int.Parse(SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString());
        }

        //根据栏目id获取兄弟list

        public DataTable GetDTSiblingsById(string columnid)
        {
            string sql = "select * from T_Column where C_ColumnParent=(select C_ColumnParent from T_Column where C_ColumnId=@columnid)";
            SqlParameter[] pms = { new SqlParameter("@columnid", columnid) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, pms);
        }


        //根据栏目id获取model
        public T_Column GetModelById(string columnid)
        {
            string sql = "select * from T_Column where C_ColumnId=@columnid";
            SqlParameter[] pms = { new SqlParameter("@columnid", columnid) };
            DataTable tb = SqlHelper.ExecuteDataTable(sql, CommandType.Text, pms);
            T_Column model = new T_Column();
            if (tb.Rows[0]["C_ColumnId"] != null)
                model.ColumnId = tb.Rows[0]["C_ColumnId"].ToString();
            if (tb.Rows[0]["C_ColumnName"] != null)
                model.ColumnName = tb.Rows[0]["C_ColumnName"].ToString();
            if (tb.Rows[0]["C_ColumnStatus"] != null)
                model.ColumnStatus = int.Parse(tb.Rows[0]["C_ColumnStatus"].ToString());
            if (tb.Rows[0]["C_ColumnContent"] != null)
                model.ColumnContent = tb.Rows[0]["C_ColumnContent"].ToString();
            if (tb.Rows[0]["C_ColumnParent"] != null)
                model.ColumnParent = tb.Rows[0]["C_ColumnParent"].ToString();
            if (tb.Rows[0]["C_ColumnDelStatus"] != null)
                model.ColumnDelStatus = int.Parse(tb.Rows[0]["C_ColumnDelStatus"].ToString());
            return model;
        }
        //根据name获取id
        public string GetIdByName(string parent)
        {
            string sql = "select C_ColumnId from T_Column where C_ColumnName=@parent";
            SqlParameter[] sp = { new SqlParameter("@parent", parent) };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString();
        }
        //根据name获取name
        public bool GetNameByName(string name)
        {
            string sql = "select count(*) from T_Column where C_ColumnName=@name";
            SqlParameter[] pms = { new SqlParameter("@name", name) };
            int flag = Int32.Parse(SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, pms).ToString());
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //根据一级栏目获取可以插入文章的栏目
        public DataTable GetColumnListByFirstCol(string firstColId)
        {
            string sql = "select * from T_Column where C_ColumnId　like @firstId and C_ColumnStatus=1";
            SqlParameter[] sp = { new SqlParameter("@firstId", firstColId.Substring(0, 2) + "%") };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);

        }
        //根据一级栏目获取其余栏目
        public DataTable GetChildModelById(string id)
        {
            SqlParameter[] sp = { new SqlParameter("@id", id) };
            string sql = "select * from T_Column where (SUBSTRING(C_ColumnId,1,2)=@id and C_ColumnDelStatus='0' )";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }

        //栏目的更新
        public bool Update(T_Column model)
        {
            // C_ColumnId, C_ColumnName, C_ColumnStatus, C_ColumnContent, C_ColumnParent, C_ColumnDelStatus
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Column set ");
            strSql.Append("C_ColumnName=@name,");
            strSql.Append("C_ColumnContent=@content,");
            strSql.Append("C_ColumnDelStatus=@delstatus ");
            strSql.Append("where C_ColumnId=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Char,8),
                    new SqlParameter("@name", SqlDbType.NVarChar,100),
                    new SqlParameter("@content", SqlDbType.NText),
                    new SqlParameter("@delstatus", SqlDbType.Int)};
            parameters[0].Value = model.ColumnId;
            parameters[1].Value = model.ColumnName;
            parameters[2].Value = model.ColumnContent;
            parameters[3].Value = model.ColumnDelStatus;
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
        //栏目的删除
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update   T_Column set ");
            strSql.Append("C_ColumnDelStatus=@delstatus ");
            strSql.Append("where C_ColumnId=@id");
            SqlParameter[] parameters = {
                       new SqlParameter("@delstatus", SqlDbType.Int),
                       new SqlParameter("@id", SqlDbType.Char,11)
            };
            parameters[0].Value = 1;
            parameters[1].Value = id;


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
        public DataTable GetListByColumn(int pageIndex, int pageSize, string columnId, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@column",columnId),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("ArticleListByColumn", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;
        }
    }
}

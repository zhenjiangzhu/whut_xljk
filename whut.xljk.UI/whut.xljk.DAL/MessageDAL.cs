using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace whut.xljk.DAL
{
    public class MessageDAL
    {
        /// 留言表增删查改
        /// <summary>
        /// 获取留言总数
        /// </summary>
        public int GetNumOfMessage()
        {
            string sql = "select COUNT(*) from T_Message";
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text);
        }

        /// <summary>
        /// 插入一条留言数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(T_Message model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into T_Message(NickName,Grade,Sex,Email,TeacherName,BriefQuestion,DetailQuestion,Reply,QuestionTime,ReplyTime,Category,Status)");
            sb.Append(" values(@NickName,@Grade,@Sex,@Email,@TeacherName,@BriefQuestion,@DetailQuestion,@Reply,@QuestionTime,@ReplyTime,@Category,@Status)");
            SqlParameter[] sp = 
            {
                new SqlParameter("@NickName",SqlDbType.NVarChar,64),
                new SqlParameter("@Grade",SqlDbType.NVarChar,32),
                new SqlParameter("@Sex",SqlDbType.NVarChar,32),
                new SqlParameter("@Email",SqlDbType.NVarChar,64),
                new SqlParameter("@TeacherName",SqlDbType.NVarChar,64),
                new SqlParameter("@BriefQuestion",SqlDbType.NVarChar,128),
                new SqlParameter("@DetailQuestion",SqlDbType.NVarChar,1024),
                new SqlParameter("@Reply",SqlDbType.NVarChar,1024),
                new SqlParameter("@QuestionTime",SqlDbType.DateTime),
                new SqlParameter("@ReplyTime",SqlDbType.DateTime),
                new SqlParameter("@Category",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int)
            };
            sp[0].Value = model.NickName;
            sp[1].Value = model.Grade;
            sp[2].Value = model.Sex;
            sp[3].Value = model.Email;
            sp[4].Value = model.TeacherName;
            sp[5].Value = model.BriefQuestion;
            sp[6].Value = model.DetailQuestion;
            sp[7].Value = model.Reply;
            sp[8].Value = model.QuestionTime;
            sp[9].Value = model.ReplyTime;
            sp[10].Value = model.Category;
            sp[11].Value = model.Status;

            string sql = sb.ToString();

            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }

        /// <summary>
        /// 根据留言的id编号删除一条留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from [T_Message] where [ID]=@id";
            SqlParameter[] sp = 
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }

        /// <summary>
        /// 根据留言编号修改留言内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(T_Message model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [T_Message] set ");
            sb.Append("[NickName]=@NickName,");
            sb.Append("[Grade]=@Grade,");
            sb.Append("[Sex]=@Sex,");
            sb.Append("[Email]=@Email,");
            sb.Append("[TeacherName]=@TeacherName,");
            sb.Append("[BriefQuestion]=@BriefQuestion,");
            sb.Append("[DetailQuestion]=@DetailQuestion,");
            sb.Append("[Reply]=@Reply,");
            sb.Append("[QuestionTime]=@QuestionTime,");
            sb.Append("[ReplyTime]=@ReplyTime,");
            sb.Append("[Category]=@Category,");
            sb.Append("[Status]=@Status");
            sb.Append(" where [ID]=@ID");
            SqlParameter[] sp = 
            {
                new SqlParameter("@NickName",SqlDbType.NVarChar,64),
                new SqlParameter("@Grade",SqlDbType.NVarChar,32),
                new SqlParameter("@Sex",SqlDbType.NVarChar,32),
                new SqlParameter("@Email",SqlDbType.NVarChar,64),
                new SqlParameter("@TeacherName",SqlDbType.NVarChar,64),
                new SqlParameter("@BriefQuestion",SqlDbType.NVarChar,128),
                new SqlParameter("@DetailQuestion",SqlDbType.NVarChar,1024),
                new SqlParameter("@Reply",SqlDbType.NVarChar,1024),
                new SqlParameter("@QuestionTime",SqlDbType.DateTime),
                new SqlParameter("@ReplyTime",SqlDbType.DateTime),
                new SqlParameter("@Category",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.NVarChar,64)
            };
            sp[0].Value = model.NickName;
            sp[1].Value = model.Grade;
            sp[2].Value = model.Sex;
            sp[3].Value = model.Email;
            sp[4].Value = model.TeacherName;
            sp[5].Value = model.BriefQuestion;
            sp[6].Value = model.DetailQuestion;
            sp[7].Value = model.Reply;
            sp[8].Value = model.QuestionTime;
            sp[9].Value = model.ReplyTime;
            sp[10].Value = model.Category;
            sp[11].Value = model.Status;
            sp[12].Value = model.ID;
            return (int)SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, sp);
        }

        /// <summary>
        /// 获取最新的几条留言
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetNewestMessage(int num)
        {
            string sql = "select top " + num + " * from [T_Message] order by [ID] desc";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        /// <summary>
        /// 获取所有留言
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMessage()
        {
            string sql = "select * from [T_Message]";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        /// <summary>
        /// 获取所有未回复的留言
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMessageNotReplied()
        {
            string sql = "select * from [T_Message] where [Reply] = ''";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        /// <summary>
        /// 获取所有指定老师的未回复的留言
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMessageNotRepliedByTeacher(string teacherName)
        {
            string sql = "select * from [T_Message] where [Reply] = '' and [TeacherName] = '" + teacherName + "'";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        /// <summary>
        /// 获取所有已回复的留言
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMessageReplied()
        {
            string sql = "select * from [T_Message] where [Reply] != ''";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        /// <summary>
        /// 根据留言状态获取留言列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetMessageList(int pageIndex, int pageSize, int category, out int total)
        {
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp = 
            {
                new SqlParameter("@pageIndex",pageIndex),
                new SqlParameter("@pageSize",pageSize),
                new SqlParameter("@category",category),
                totalParameter
            };
            DataTable dt = SqlHelper.ExecuteDataTable("P_MessageListByCategory", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return dt;
        }

        /// <summary>
        /// 加载所有留言的列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetAllMessageList(int pageIndex, int pageSize, out int total)
        {
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp = 
            {
                new SqlParameter("@pageIndex",pageIndex),
                new SqlParameter("@pageSize",pageSize),
                totalParameter
            };
            DataTable dt = SqlHelper.ExecuteDataTable("P_GetAllMessageList", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return dt;
        }

        /// <summary>
        /// 根据id获取留言
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public DataTable GetMessageById(int ID)
        {
            string sql = "select * from [T_Message] where [ID]=@ID";
            SqlParameter sp = new SqlParameter("@ID", ID);
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }

        public DataTable GetMessageList(int Category)
        {
            string sql = "";
            switch(Category)
            {
                case 1: sql = "select * from [T_Message] where [Status]=2 and [Category]=1"; break;
                case 2: sql = "select * from [T_Message] where [Status]=2 and [Category]=2"; break;
                case 3: sql = "select * from [T_Message] where [Status]=2 and [Category]=3"; break;
                case 4: sql = "select * from [T_Message] where [Status]=2 and [Category]=4"; break;
                case 5: sql = "select * from [T_Message] where [Status]=2 and [Category]=5"; break;
                case 6: sql = "select * from [T_Message] where [Status]=2 and [Category]=6"; break;
                case 7: sql = "select * from [T_Message] where [Status]=2 and [Category]=7"; break;
                case 8: sql = "select * from [T_Message] where [Status]=2 and [Category]=8"; break;
                case 9: sql = "select * from [T_Message] where [Status]=2 and [Category]=9"; break;
                case 10: sql = "select * from [T_Message] where [Status]=2 and [Category]=10"; break;
                default: sql = "select * from [T_Message] where [Status]=2"; break;
            }
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        //public DataTable GetMessageList(int pageIndex, int pageSize, int category, out int total)
        //{
        //    SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
        //    totalParameter.Direction = ParameterDirection.Output;
        //    SqlParameter[] sp = 
        //    {
        //        new SqlParameter("@pageIndex",pageIndex),
        //        new SqlParameter("@pageSize",pageSize),
        //        new SqlParameter("@category",category),
        //        totalParameter
        //    };
        //    DataTable dt = SqlHelper.ExecuteDataTable("PGetMessageListByCategory", CommandType.StoredProcedure, sp);
        //    total = (int)totalParameter.Value;
        //    return dt;
        //}
    }
}

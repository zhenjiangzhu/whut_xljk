using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using whut.xljk.DAL;

namespace whut.xljk.BLL
{
    public class MessageBLL
    {
        MessageDAL dal = new MessageDAL();
        public int GetNumOfMessage()
        {
            return dal.GetNumOfMessage();
        }

        public int Insert(T_Message model)
        {
            return dal.Insert(model);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public int Update(T_Message model)
        {
            return dal.Update(model);
        }

        public List<T_Message> GetNewestMessage(int num)
        {
            return DataTableToList(dal.GetNewestMessage(num));
        }

        public List<T_Message> GetAllMessage()
        {
            return DataTableToList(dal.GetAllMessage());
        }

        public DataTable GetAllMessageNotReplied()
        {
            return dal.GetAllMessageNotReplied();
        }

        public DataTable GetAllMessageNotRepliedByTeacher(string teacherName)
        {
            return dal.GetAllMessageNotRepliedByTeacher(teacherName);
        }

        public DataTable GetAllMessageReplied()
        {
            return dal.GetAllMessageReplied();
        }

        public List<T_Message> GetMessageList(int pageIndex, int pageSize, int category, out int total)
        {
            return DataTableToList(dal.GetMessageList(pageIndex, pageSize, category, out total));
        }

        public string GetMessageListString(int pageIndex, int pageSize, int category, out int total)
        {
            List<T_Message> list = DataTableToList(dal.GetMessageList(pageIndex, pageSize, category, out total));
            StringBuilder sb = new StringBuilder();

            foreach(var model in list)
            {
                sb.AppendFormat("<div class='qacontent'><div class='contentleft'><p>{0}</p></div><div class='contentright'><p>{1}<span class='all'>显示全部</span><span>{2}</span></p></hr><p><span>{3}</span><br>{4}<span class='all'>显示全部</span></p></div><hr style='width: 52.5vw;'></div>", model.TeacherName, model.BriefQuestion, model.QuestionTime, model.ReplyTime, model.Reply);
            }
            return sb.ToString();
        }

        public List<T_Message> GetAllMessageList(int pageIndex, int pageSize, out int total)
        {
            return DataTableToList(dal.GetAllMessageList(pageIndex, pageSize, out total));
        }

        public string GetAllMessageListString(int pageIndex, int pageSize, out int total)
        {
            List<T_Message> list = DataTableToList(dal.GetAllMessageList(pageIndex, pageSize, out total));
            StringBuilder sb = new StringBuilder();

            foreach(var model in list)
            {
                sb.AppendFormat("<div class='qacontent'><div class='contentleft'><p>{0}</p></div><div class='contentright'><p>{1}<span class='all'>显示全部</span><span>{2}</span></p></hr><p><span>{3}</span><br>{4}<span class='all'>显示全部</span></p></div><hr style='width: 52.5vw;'></div>",model.TeacherName,model.BriefQuestion,model.QuestionTime,model.ReplyTime,model.Reply);

            }
            return sb.ToString();
        }

        public List<T_Message> GetMessageById(int id)
        {
            return DataTableToList(dal.GetMessageById(id));
        }

        public List<T_Message> GetMessageList(int Category)
        {
            return DataTableToList(dal.GetMessageList(Category));
        }

        public List<T_Message> DataTableToList(DataTable dt)
        {
            List<T_Message> list = new List<T_Message>();
            int rowCount = dt.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                T_Message model = new T_Message();
                if (dt.Rows[i]["ID"] != null)
                {
                    model.ID = (int)dt.Rows[i]["ID"];
                }
                if (dt.Rows[i]["NickName"] != null)
                {
                    model.NickName = dt.Rows[i]["NickName"].ToString();
                }
                if (dt.Rows[i]["Grade"] != null)
                {
                    model.Grade = dt.Rows[i]["Grade"].ToString();
                }
                if (dt.Rows[i]["Sex"] != null)
                {
                    model.Sex = dt.Rows[i]["Sex"].ToString();
                }
                if (dt.Rows[i]["Email"] != null)
                {
                    model.Email = dt.Rows[i]["Email"].ToString();
                }
                if (dt.Rows[i]["TeacherName"] != null)
                {
                    model.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                }
                if (dt.Rows[i]["BriefQuestion"] != null)
                {
                    model.BriefQuestion = dt.Rows[i]["BriefQuestion"].ToString();
                }
                if (dt.Rows[i]["DetailQuestion"] != null)
                {
                    model.DetailQuestion = dt.Rows[i]["DetailQuestion"].ToString();
                }
                if (dt.Rows[i]["Reply"] != null)
                {
                    model.Reply = dt.Rows[i]["Reply"].ToString();
                }
                if (dt.Rows[i]["QuestionTime"] != null)
                {
                    model.QuestionTime = (DateTime)dt.Rows[i]["QuestionTime"];
                }
                if (dt.Rows[i]["ReplyTime"] != null)
                {
                    model.ReplyTime = (DateTime)dt.Rows[i]["ReplyTime"];
                }
                if (dt.Rows[i]["Category"] != null)
                {
                    model.Category = (int)dt.Rows[i]["Category"];
                }
                if (dt.Rows[i]["Status"] != null)
                {
                    model.Status = (int)dt.Rows[i]["Status"];
                }
                list.Add(model);
            }
            return list;
        }
    }
}

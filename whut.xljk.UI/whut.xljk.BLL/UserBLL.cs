using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.DAL;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace whut.xljk.BLL
{
    public class UserBLL
    {
        UserDAL userDAL = new DAL.UserDAL();
        public List<T_User> GetTeacher()
        {
            return DataTableToList(userDAL.GetTeacher());
        }

        public DataTable GetTeacherTable()
        {
            return userDAL.GetTeacher();
        }

        public List<T_User> DataTableToList(DataTable dt)
        {
            List<T_User> list = new List<T_User>();
            
            for(int i = 0; i < dt.Rows.Count;i++)
            {
                T_User model = new T_User();
                if(dt.Rows[i]["Account"] != null && dt.Rows[i]["Account"] != "")
                {
                    model.Account = dt.Rows[i]["Account"].ToString().Trim();
                }
                model.Password = "";
                if (dt.Rows[i]["Account"] != null && dt.Rows[i]["Account"] != "")
                {
                    model.Account = dt.Rows[i]["Account"].ToString().Trim();
                }
                if(dt.Rows[i]["Name"] != null && dt.Rows[i]["Name"] != "")
                {
                    model.Name = dt.Rows[i]["Name"].ToString().Trim();
                }
                if (dt.Rows[i]["Tel"] != null && dt.Rows[i]["Tel"] != "")
                {
                    model.Name = dt.Rows[i]["Tel"].ToString().Trim();
                }
                if (dt.Rows[i]["Sex"] != null && dt.Rows[i]["Sex"] != "")
                {
                    model.Name = dt.Rows[i]["Sex"].ToString().Trim();
                }
                if (dt.Rows[i]["Birth"] != null && dt.Rows[i]["Birth"] != "")
                {
                    model.Name = dt.Rows[i]["Birth"].ToString().Trim();
                }
                if (dt.Rows[i]["Email"] != null && dt.Rows[i]["Email"] != "")
                {
                    model.Name = dt.Rows[i]["Email"].ToString().Trim();
                }
                if (dt.Rows[i]["Status"] != null && dt.Rows[i]["Status"] != "")
                {
                    model.Name = dt.Rows[i]["Status"].ToString().Trim();
                }
                list.Add(model);
            }
            return list;
        }
    }
}

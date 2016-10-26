using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace whut.xljk.DAL
{
    public class UserDAL
    {
        // 返回所有老师信息
        public DataTable GetTeacher()
        {
            string sql = "select * from [T_User] where [Status]=1";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
    }
}

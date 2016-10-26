using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.COMMON;
using whut.xljk.MODEL;

namespace whut.xljk.DAL
{
    public class AppointmentDal
    {
        public DataTable Getlist(string para)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("select * from T_Appointment where id=@id");
            SqlParameter[] paras={
                    new SqlParameter("@id",para)
                                 };
            return SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text,paras);
        }

        public int updateTdInfo(Td tdinfo)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("update T_Appointment set appo_time=@appotime,t_name=@tname,state=@state where id=@id");
            SqlParameter[] paras={
                                     new SqlParameter("@id",tdinfo.name),
                                     new SqlParameter("@appotime",tdinfo.time),
                                     new SqlParameter("@tname",tdinfo.t_name),
                                     new SqlParameter("@state",tdinfo.state)
                                 };
            return SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, paras);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.DAL;
using whut.xljk.MODEL;

namespace whut.xljk.BLL
{
    public class AppointmentBll
    {
        AppointmentDal ADal = new AppointmentDal();
        public List<Td> Getlist(List<Td> list)
        {
            for (int i = 0; i < 36; i++)
            {
                DataTable dt = new DataTable();
                string id = list[i].name;
                dt = ADal.Getlist(id);
                if (dt.Rows.Count == 0)
                {
                    list[i].name = "";
                    list[i].t_name = "";
                    list[i].time = "";
                    list[i].state = "";
                }
                else
                {
                    list[i].name = dt.Rows[0][0].ToString().Trim();
                    list[i].time =dt.Rows[0][1].ToString().Trim();
                    list[i].t_name =dt.Rows[0][2].ToString().Trim();
                    list[i].state =dt.Rows[0][3].ToString().Trim();
                }
            }
            return list;
        }

        public Td GetTdinfo(string id)
        {
           DataTable dt= ADal.Getlist(id);
           Td td = new Td();
           if (dt.Rows.Count == 0)
           {
               td.name = "";
               td.t_name = "";
               td.time = "";
               td.state = "";
           }
           else
           {
               td.name = dt.Rows[0][0].ToString().Trim();
               td.time = dt.Rows[0][1].ToString().Trim();
               td.t_name = dt.Rows[0][2].ToString().Trim();
               td.state = dt.Rows[0][3].ToString().Trim();
           }
            return td;
        }
        public int updateTdInfo(Td td)
        {
            return ADal.updateTdInfo(td);
        }
    }
}

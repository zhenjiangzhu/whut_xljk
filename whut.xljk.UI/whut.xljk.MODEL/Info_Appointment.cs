using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.xljk.MODEL
{
    public class Info_Appointment
    {
        //单元格id
        public string id { get; set; }
        //预约时间
        public string appo_time { get; set; }
        //老师
        public string t_name { get; set; }
        //预约状态
        public Boolean state { get; set; }
    }
}

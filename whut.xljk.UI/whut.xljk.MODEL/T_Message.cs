using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.xljk.MODEL
{
    public class T_Message
    {
        public int ID { get; set; }
        public string NickName { get; set; }
        public string Grade { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string TeacherName { get; set; }
        public string BriefQuestion { get; set; }
        public string DetailQuestion { get; set; }
        public string Reply { get; set; }
        public DateTime QuestionTime { get; set; }
        public DateTime ReplyTime { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
    }
}

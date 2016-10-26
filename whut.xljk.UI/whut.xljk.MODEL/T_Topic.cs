using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace whut.xljk.MODEL
{
    public class T_Topic
    {
        //专题模型类--暂时不需要动态的添加栏目
        //C_TopicId, C_TopicTitle, C_TopicTime, C_TopicPriority, C_TopicSummary
        public int TopicId { get; set; }
        public string TopicTitle { get; set; }
        public string TopicTime { get; set; }
        public int TopicPriority { get; set; }
        public string TopicSummary { get; set; }
        public string TopicFileName { get; set; }
    }
}

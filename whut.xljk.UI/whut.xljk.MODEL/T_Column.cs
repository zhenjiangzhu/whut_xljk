using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.xljk.MODEL
{
   public class T_Column
    {
        //C_ColumnId, C_ColumnName, C_ColumnStatus, C_ColumnContent, C_ColumnParent
        public string ColumnId { get; set; }
        public string ColumnName { get; set; }
        public int ColumnStatus { get; set; }
        public string ColumnContent { get; set; }
        public string ColumnParent { get; set; }
        public int ColumnDelStatus { get; set; }
    }
}

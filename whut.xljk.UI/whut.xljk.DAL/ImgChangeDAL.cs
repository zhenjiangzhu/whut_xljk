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
    public class ImgChangeDAL
    {
        /// <summary>
        /// 更新数据库中的四条记录，来更新指向图片浏览的文本和url
        /// </summary>
        /// <param name="list">传递新提交的四条model</param>
        /// <returns></returns>
        public bool UpdateImageInfo(List<T_ImgChange> list)
        {
            string sql = "update T_ImgChange set C_ImgUrl=case C_ImgId when 1 then @imgurl1 when 2 then @imgurl2 when 3 then @imgurl3 when 4 then @imgurl4 end ,C_ImgDes=case C_ImgId when 1 then @imgdes1 when 2 then @imgdes2 when 3 then @imgdes3 when 4 then @imgdes4 end";
            SqlParameter[] sp ={new SqlParameter("@imgurl1",list[0].C_ImgUrl),
                             new SqlParameter("@imgdes1",list[0].C_ImgDes),
                             new SqlParameter("@imgurl2",list[1].C_ImgUrl),
                             new SqlParameter("@imgdes2",list[1].C_ImgDes),
                             new SqlParameter("@imgurl3",list[2].C_ImgUrl),
                             new SqlParameter("@imgdes3",list[2].C_ImgDes),
                             new SqlParameter("@imgurl4",list[3].C_ImgUrl),
                             new SqlParameter("@imgdes4",list[3].C_ImgDes),
                             };
            int flag = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<T_ImgChange> GetList()
        {
            string sql = "select * from T_ImgChange";
            DataTable tb = SqlHelper.ExecuteDataTable(sql, CommandType.Text);
            List<T_ImgChange> list = new List<T_ImgChange>();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    T_ImgChange model = new T_ImgChange();
                    model.C_ImgId = int.Parse(tb.Rows[i]["C_ImgId"].ToString());
                    model.C_ImgDes = tb.Rows[i]["C_ImgDes"].ToString();
                    model.C_ImgUrl = tb.Rows[i]["C_ImgUrl"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}

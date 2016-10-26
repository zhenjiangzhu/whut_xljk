using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.DAL;
using whut.xljk.MODEL;

namespace whut.xljk.BLL
{
    public class ImgChangeBLL
    {
        ImgChangeDAL dal = new ImgChangeDAL();
        /// <summary>
        /// 更新数据库中的四条记录，来更新指向图片浏览的文本和url
        /// </summary>
        /// <param name="list">传递新提交的四条model</param>
        /// <returns></returns>
        public bool UpdateImageInfo(List<T_ImgChange> list)
        {
            return dal.UpdateImageInfo(list);
        }
        public List<T_ImgChange> GetList()
        {
            return dal.GetList();
        }
    }
}

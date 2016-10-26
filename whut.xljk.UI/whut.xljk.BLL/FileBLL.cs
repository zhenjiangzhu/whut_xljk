using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using whut.xljk.DAL;
using whut.xljk.MODEL;

namespace whut.xljk.BLL
{
   public class FileBLL
    {
        FileDAL dal = new FileDAL();

        public List<T_File> GetLastFile(string FileId)
        {
            return DataTableToList(dal.GetLastFile(FileId));
        }

        public List<T_File> GetNextFile(string FileId)
        {
            return DataTableToList(dal.GetNextFile(FileId));
        }

        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        //根据所属部门获取List
        public List<T_File> GetListBySector(string sector)
        {
            return DataTableToList(dal.GetDataTableBySector(sector));
        }
        //获取所有文件list
        public List<T_File> GetListleAll()
        {
            return DataTableToList(dal.GetDataTableAll());
        }
        //转化datatable 为list
        public List<T_File> DataTableToList(DataTable tb)
        {
            List<T_File> list = new List<T_File>();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    T_File model = new T_File();
                    model.FileId = tb.Rows[i]["C_FileId"].ToString();
                    if (tb.Rows[i]["C_FileId"].ToString() != "")
                        model.FileName = tb.Rows[i]["C_FileName"].ToString();
                    if (tb.Rows[i]["C_FileSector"].ToString() != "")
                        model.FileSector = tb.Rows[i]["C_FileSector"].ToString();
                    if (tb.Rows[i]["C_FileTime"] != null)
                    {
                        DateTime time = DateTime.Parse(tb.Rows[i]["C_FileTime"].ToString());
                        model.FileTime = time.ToString("yyyy-MM-dd");
                    }
                    if (tb.Rows[i]["C_FileSummary"].ToString() != "")
                        model.FileSummary = tb.Rows[i]["C_FileSummary"].ToString();
                    if (tb.Rows[i]["C_FilePath"].ToString() != "")
                        model.FilePath = tb.Rows[i]["C_FilePath"].ToString();
                    if (tb.Rows[i]["C_FileExt"].ToString() != "")
                        model.FileExt = tb.Rows[i]["C_FileExt"].ToString();
                    if (tb.Rows[i]["C_FileDowNum"].ToString() != "")
                        model.FileDowNum = int.Parse(tb.Rows[i]["C_FileDowNum"].ToString());
                    list.Add(model);
                }

            }
            return list;
        }

        //插入
        public int Insert(T_File file)
        {
            return dal.Insert(file);
        }
        //根据日期模糊查询获取编号
        public string GetIdByTime(string dateTime)
        {
            T_File fileModel = new T_File();
            DataTable file = dal.GetIdByTime(dateTime);
            string str = null;
            if (file.Rows.Count == 0)
            {
                str = dateTime + "001";
            }
            else
            {
                fileModel.FileId = file.Rows[0]["C_FileId"].ToString().Trim();
                int strId = Int32.Parse(fileModel.FileId.Substring(8, 3)) + 1;
                if (strId >= 10)
                {
                    str = dateTime + "0" + strId.ToString().Trim();
                }
                else if (strId >= 100)
                {
                    str = dateTime + strId.ToString().Trim();
                }
                else
                {
                    str = dateTime + "00" + strId.ToString().Trim();
                }

            }
            return str;

        }
        /// <summary>
        /// 根据获取数目获取记录
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<T_File> GetPreNumList(int total)
        {
            return DataTableToList(dal.GetPreNumList(total));
        }
        //根据下载次数排列
        public List<T_File> GetListByNumOrderByDow(int num)
        {
            return DataTableToList(dal.GetListByNumOrderByDow(num));
        }
        //根据shijian
        public List<T_File> GetListByTime(int num)
        {
            return DataTableToList(dal.GetListByTime(num));
        }
        ///根据起始记录和终止记录和文章类型获取list集合
        public List<T_File> GetListByIndexCategory(int beginIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByIndexCategory(beginIndex, endIndex));
        }

        //更新下载次数
        public bool UpdateDowNumById(string fileId)
        {
            return dal.UpdateDowNumById(fileId);
        }
        //根据id获取mode
        public T_File GetModelById(string id)
        {
            DataTable tb = dal.GetModelById(id);
            T_File model = new T_File();
            if (tb.Rows.Count > 0)
            {

                model.FileId = tb.Rows[0]["C_FileId"].ToString();
                if (tb.Rows[0]["C_FileId"].ToString() != "")
                    model.FileName = tb.Rows[0]["C_FileName"].ToString();
                if (tb.Rows[0]["C_FileSector"].ToString() != "")
                    model.FileSector = tb.Rows[0]["C_FileSector"].ToString();
                if (tb.Rows[0]["C_FileTime"] != null)
                {
                    DateTime time = DateTime.Parse(tb.Rows[0]["C_FileTime"].ToString());
                    model.FileTime = time.ToString("yyyy-MM-dd");
                }
                if (tb.Rows[0]["C_FileSummary"].ToString() != "")
                    model.FileSummary = tb.Rows[0]["C_FileSummary"].ToString();
                if (tb.Rows[0]["C_FilePath"].ToString() != "")
                    model.FilePath = tb.Rows[0]["C_FilePath"].ToString();
                if (tb.Rows[0]["C_FileExt"].ToString() != "")
                    model.FileExt = tb.Rows[0]["C_FileExt"].ToString();
                if (tb.Rows[0]["C_FileDowNum"].ToString() != "")
                    model.FileDowNum = int.Parse(tb.Rows[0]["C_FileDowNum"].ToString());
            }
            return model;
        }
        //分页list
        public List<T_File> GetListByPage(int pageIndex, int pageSize, out int total)
        {
            return DataTableToList(dal.GetListByPage(pageIndex, pageSize, out total));
        }
        public List<T_File> GetListBySector(int pageIndex, int pageSize, string sector, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, out total));
        }


        public bool deleteFile(string id)
        {
            FileDAL dal = new FileDAL();
            return dal.deleteFile(id);
        }
    }
}

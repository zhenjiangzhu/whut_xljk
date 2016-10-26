using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.MODEL;
namespace EmptyProjectNet45_FineUI
{
    public partial class apppointment : System.Web.UI.Page
    {
        AppointmentBll ABll = new AppointmentBll();
        public string id;
        public List<Td> dongyuan = generate_DTd();
        public List<Td> nanhu = generate_NTd();
        public List<Td> shengsheng = generate_STd();
        public List<Td> xuehai = generate_XTd();
        public List<Td> yuqu = generate_YTd();
        protected void Page_Load(object sender, EventArgs e)
        {
            dongyuan=ABll.Getlist(dongyuan);
            nanhu = ABll.Getlist(nanhu);
            shengsheng = ABll.Getlist(shengsheng);
            xuehai = ABll.Getlist(xuehai);
            yuqu = ABll.Getlist(yuqu);

        }
        //东院
        public static List<Td> generate_DTd()
        {
            List<Td> list_td=new List<Td>();
            for (int i = 1; i <= 36; i++)
			{
			 Td td=new Td();
                td.name="11"+i.ToString();
                list_td.Add(td);
			}

            return list_td;
        }
        //南湖
        public static List<Td> generate_NTd()
        {
            List<Td> list_td = new List<Td>();
            for (int i = 1; i <= 36; i++)
            {
                Td td = new Td();
                td.name = "12" + i.ToString();
                list_td.Add(td);
            }

            return list_td;
        }
        //升升
        public static List<Td> generate_STd()
        {
            List<Td> list_td = new List<Td>();
            for (int i = 1; i <= 36; i++)
            {
                Td td = new Td();
                td.name = "13" + i.ToString();
                list_td.Add(td);
            }

            return list_td;
        }
        //学海
        public static List<Td> generate_XTd()
        {
            List<Td> list_td = new List<Td>();
            for (int i = 1; i <= 36; i++)
            {
                Td td = new Td();
                td.name = "14" + i.ToString();
                list_td.Add(td);
            }

            return list_td;
        }
        //余区
        public static List<Td> generate_YTd()
        {
            List<Td> list_td = new List<Td>();
            for (int i = 1; i <= 36; i++)
            {
                Td td = new Td();
                td.name = "2" + i.ToString();
                list_td.Add(td);
            }

            return list_td;
        }
    }
}
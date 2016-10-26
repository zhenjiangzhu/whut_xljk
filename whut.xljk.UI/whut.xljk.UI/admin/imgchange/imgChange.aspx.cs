using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.BLL;
using whut.xljk.MODEL;

namespace EmptyProjectNet45_FineUI.admin.imgchange
{
    public partial class imgChange : System.Web.UI.Page
    {
        ImgChangeBLL bll = new ImgChangeBLL();
        T_ImgChange model1, model2, model3, model4;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<T_ImgChange> list = bll.GetList();
                model1 = list[0];
                model2 = list[1];
                model3 = list[2];
                model4 = list[3];
                Image1.ToolTip = "描述：" + model1.C_ImgDes.ToString() + "；路径：" + model1.C_ImgUrl.ToString();
                Image2.ToolTip = "描述：" + model2.C_ImgDes.ToString() + "；路径：" + model2.C_ImgUrl.ToString();
                Image3.ToolTip = "描述：" + model3.C_ImgDes.ToString() + "；路径：" + model3.C_ImgUrl.ToString();
                Image4.ToolTip = "描述：" + model4.C_ImgDes.ToString() + "；路径：" + model4.C_ImgUrl.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string des = TextBox1.Text;
            string url = TextBox2.Text;

            int chooseImg = int.Parse(DropDownList1.SelectedValue);
            string path = "~/images/banner/back" + chooseImg.ToString() + ".jpg";
            ChangeImagePath(chooseImg, des, url);
            File.Delete(Request.MapPath(path));
            FileUpload1.SaveAs(Request.MapPath(path));
            Response.Redirect("ChangeImage.aspx");
        }


        public bool ChangeImagePath(int chooseImg, string des, string url)
        {

            JiaoTiChangeImg(chooseImg);
            T_ImgChange model = new T_ImgChange { C_ImgDes = des, C_ImgUrl = url, C_ImgId = chooseImg };
            return JiaoTiChangeInfo(model, chooseImg);



        }

        public void JiaoTiChangeImg(int chooseImg)
        {
            for (int i = 4; i > chooseImg; i--)
            {
                string path = Request.MapPath("~/images/banner/back" + (i - 1).ToString() + ".jpg");
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fs);


                    if (File.Exists(path.Substring(0, path.LastIndexOf('.') - 1) + i.ToString() + ".jpg"))
                    {
                        File.Delete(path.Substring(0, path.LastIndexOf('.') - 1) + i.ToString() + ".jpg");
                    }
                    image.Save(Request.MapPath("~/images/banner/back" + i.ToString() + ".jpg"));
                }
            }

        }
        public bool JiaoTiChangeInfo(T_ImgChange model, int chooseImg)
        {
            List<T_ImgChange> list = bll.GetList();
            list.RemoveAt(3);
            list.Insert(chooseImg - 1, model);

            return bll.UpdateImageInfo(list);

        }
    }
}
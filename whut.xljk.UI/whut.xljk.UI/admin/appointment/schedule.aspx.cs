using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.xljk.MODEL;
using whut.xljk.BLL;
namespace EmptyProjectNet45_FineUI.admin.appointment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        AppointmentBll ab = new AppointmentBll();
        static Td tdinfo = new Td();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        //根据选择从数据库中获取单位时间值班信息并绑定
        protected void choose_time_Click(object sender, EventArgs e)
        {
            string placeid = place.SelectedValue.ToString();
            int weekid =Convert.ToInt32(week.SelectedValue);
            int timeid =Convert.ToInt32(time.SelectedValue);
            string id = placeid + ((weekid-1)*6 + timeid).ToString();
            tdinfo = ab.GetTdinfo(id);
            teacher.Text = tdinfo.t_name.ToString();
            work_time.Text = tdinfo.time.ToString();
            state.SelectedValue = tdinfo.state.ToString();

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            tdinfo.t_name = teacher.Text.ToString();
            tdinfo.time = work_time.Text.ToString();
            tdinfo.state = state.SelectedText.ToString();
            int i=ab.updateTdInfo(tdinfo);
            if (i>0)
            {
                FineUI.Alert.Show("更新修改成功！");
                
            }
            else{
                FineUI.Alert.Show("更新修改失败，请联系后台人员！");
            }
        }
    }
}
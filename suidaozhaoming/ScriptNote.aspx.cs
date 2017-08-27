using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace suidaozhaoming
{
    public partial class ScriptNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Session["ScriptN"].ToString())
            {
                case "Systemset_Click":
                    TextBox1.Text = "对不起，你没有设置系统权限!";

                    break;
                case "Joblog_Click":
                    TextBox1.Text = "对不起，你不是值班人员!";

                    break;
                //case "Come from Page131-3":
                //    TextBox1.Text = "请仔细核对所修改的数据!";

                //    break;
                //case "Come from Page12":
                //    TextBox1.Text = "请仔细确认上报所填数据!";

                //   break;
                default:
                    break;
            }

        }
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage12.Text = DateTime.Now.ToString();

        }


        protected void Confirm_Click(object sender, EventArgs e)
        {

            if (Session["ScriptN"].ToString() =="Systemset_Click")
            {
                Session.Contents.Remove("ScriptN");
                Response.Redirect("Secondpage.aspx");
            }
            if (Session["ScriptN"].ToString() == "Joblog_Click")
            {
                Session.Contents.Remove("ScriptN");
                Session["IntoCode"] = "Welcome Into Firstpage";
                Response.Redirect("firstpage.aspx");
            }
        }

    }
}
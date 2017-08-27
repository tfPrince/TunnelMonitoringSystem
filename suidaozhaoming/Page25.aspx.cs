using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suidaozhaoming
{
    public partial class Page25 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                title.Text = Session["suidaoming"].ToString() + "洞外亮度数据月报表";
                ShowtimeSec.Text = DateTime.Now.ToString();
                if (Session["SelectIndex3"] != null)
                {
                    DropDownList3.SelectedValue = Session["SelectIndex3"].ToString();
                }
                else
                {
                    if (DropDownList3.Items.IndexOf(DropDownList3.Items.FindByValue(DateTime.Now.Month.ToString("D2"))) != -1)
                    {
                        DropDownList3.SelectedValue = DateTime.Now.Month.ToString("D2");
                    }
                }

                if (Session["SelectIndex4"] != null)
                {
                    DropDownList4.SelectedValue = Session["SelectIndex4"].ToString();
                }
                else
                {

                    DropDownList4.SelectedValue = DateTime.Now.Day.ToString("D2");

                }
                if ((Session["SelectIndex4"] == null) & (Session["SelectIndex4"] == null))
                {
                    //update(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 05:30:00"), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 19:30:00"));
                }
            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {
            ShowtimeSec.Text = DateTime.Now.ToString();
        }

        protected void ButtonPage25_Exit_Click(object sender, EventArgs e)
        {

            Session.Contents.Remove("SelectIndex2");
            Session.Contents.Remove("SelectIndex3");
            Session.Contents.Remove("SelectIndex4"); 
            Response.Redirect("Secondpage.aspx");
        }
        protected void Page25Screen_Click(object sender, EventArgs e)
        {


        }
        protected void Search_Click(object sender, EventArgs e)
        {
        }
    }
}
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
    public partial class Page29 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                title.Text = Session["suidaoming"].ToString() + "车流量曲线";

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
                    //if (DropDownList4.Items.IndexOf(DropDownList4.Items.FindByValue("0")) != -1)
                    {
                        DropDownList4.SelectedValue = DateTime.Now.Day.ToString("D2");
                    }
                }
                if ((Session["SelectIndex4"] == null) & (Session["SelectIndex4"] == null))
                {
                    update(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:01:00"), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:55:00"));
                }
            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {

            Session["SelectIndex3"] = DropDownList3.SelectedValue;
            Session["SelectIndex4"] = DropDownList4.SelectedValue;
            showtimePage29.Text = DateTime.Now.ToString();

        }

        protected void ButtonP29_Exit_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Welcome Into Secondpage";
            Session.Contents.Remove("SelectIndex3");
            Session.Contents.Remove("SelectIndex4");
            Response.Redirect("Secondpage.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string day1 = null;
            string day2 = null;
            if (DropDownList4.Text == "0")
            {
                day1 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-01 00:01:00";
                if (DropDownList3.SelectedValue == "12")
                {
                    day2 = (Convert.ToInt16(DateTime.Now.ToString("yyyy")) + 1).ToString() + "-01-01 23:55:00";
                }
                else
                {
                    day2 = DateTime.Now.ToString("yyyy") + "-" + (Convert.ToInt16(DropDownList3.Text) + 1).ToString() + "-01 23:55:00";
                }

            }
            else
            {

                day1 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-" + DropDownList4.Text + " 00:01:00";
                day2 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-" + DropDownList4.Text + " 23:55:00";
            }

            update(Convert.ToDateTime(day1), Convert.ToDateTime(day2));

            Session["SelectIndex3"] = DropDownList3.SelectedValue;
            Session["SelectIndex4"] = DropDownList4.SelectedValue;
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        protected void update(DateTime day1, DateTime day2)
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlempinfo = "select top(1) id from LightParam where ((cuid = 'CC0000000000')and( code = 'Page29')) order by id desc";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand lightinfo = new SqlCommand(Sqlempinfo, conn);
            conn.Open();
            SqlDataReader light_info = lightinfo.ExecuteReader();
            if (light_info.Read())
            {
                conn.Close();
                //String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                Sqlempinfo = "update LightParam set starttime = '" + day1 + "' ,endtime= '" + day2 + "'  where ((cuid = 'CC0000000000')and(code ='Page29')) ";
                //SqlConnection conn = new SqlConnection(sqlconnection);
                lightinfo = new SqlCommand(Sqlempinfo, conn);
                conn.Open();
                lightinfo.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Close();
                //SqlConnection conn = new SqlConnection(sqlconnection);
                String Sqlempinfosert = "insert into LightParam values( 'CC0000000000','" + day1 + "', '" + day2 + "','Page29')";
                SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                conn.Open();
                comminsert.ExecuteNonQuery();
                conn.Close();
            }
            
        }
    }
}
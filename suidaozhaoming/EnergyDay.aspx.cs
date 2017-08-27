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
    public partial class EnergyDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                switch (Session["suidaocode"].ToString())
                {
                    case "0100000000000":
                        title.Text = Session["suidaoming"].ToString() + "每日用电量曲线";
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
                        break;
                    case "0200000000000":
                        title.Text = Session["suidaoming"].ToString() + "每日用电量曲线";
                        break;
                    case "0300000000000":
                        title.Text = Session["suidaoming"].ToString() + "每日用电量曲线";
                        break;
                    default:
                        break;
                }

            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {

            Session["SelectIndex3"] = DropDownList3.SelectedValue;
            showtimeEnergy.Text = DateTime.Now.ToString();

        }

        protected void Energy_Exit_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Welcome Into Secondpage";
            Session.Contents.Remove("SelectIndex3");
            //Session.Contents.Remove("SelectIndex4");
            Response.Redirect("Secondpage.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string day1 = null;
            string day2 = null;
            int[] m = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};          
            {

                day1 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-" + "1" + " 00:01:00";
                day2 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-" + m[DropDownList3.SelectedIndex].ToString() + " 23:59:00";
            }

            update(Convert.ToDateTime(day1), Convert.ToDateTime(day2));

            Session["SelectIndex3"] = DropDownList3.SelectedValue;
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        protected void update(DateTime day1, DateTime day2)
        {
            switch (Session["suidaocode"].ToString())
            {
                case "0100000000000":
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "select top(1) id from LightParam where ((cuid = 'CC6012070168')and( code = 'EnergyDay')) order by id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand lightinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader light_info = lightinfo.ExecuteReader();
                    if (light_info.Read())
                    {
                        conn.Close();
                        //String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                        Sqlempinfo = "update LightParam set starttime = '" + day1 + "' ,endtime= '" + day2 + "'  where ((cuid = 'CC6012070168')and(code ='EnergyDay')) ";
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
                        String Sqlempinfosert = "insert into LightParam values( 'CC6012070168','" + day1 + "', '" + day2 + "','EnergyDay')";
                        SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                        conn.Open();
                        comminsert.ExecuteNonQuery();
                        conn.Close();
                    }
                    break;
                case "0200000000000":
                    break;
                case "0300000000000":
                    break;
                default:
                    break;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using suidaozhaoming.WeatherWebService;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace suidaozhaoming
{
    public partial class Page24 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                title.Text = Session["suidaoming"].ToString() + "洞外亮度数据日报表";
                string uid = null;
                switch (Session["suidaocode"].ToString())
                {
                    case "0100000000000":
                        uid = "CC6012070168";
                        break;
                    case "0200000000000":
                        uid = "CC6012071120";
                        break;
                    case "0300000000000":
                        uid = "CC0000000000";
                        break;
                    default:
                        uid = null;
                        break;
                }
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
                    update(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 05:30:00"), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 19:30:00"));
                }
                string day1 = null;
                string day2 = null;
                String sqlconnection1 = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfo = "select top(1) starttime,endtime from LightParam where ( cuid = '" + uid + "') and (code = 'Page24') order by id desc";
                SqlConnection conn1 = new SqlConnection(sqlconnection1);
                SqlCommand lightinfo = new SqlCommand(Sqlempinfo, conn1);
                conn1.Open();
                SqlDataReader light_info = lightinfo.ExecuteReader();
                if (light_info.Read())
                {
                    day1 = light_info["starttime"].ToString();  // DateTime.Now.ToString("yyyy-MM-dd") + " 05:00:00";
                    day2 = light_info["endtime"].ToString();  // DateTime.Now.ToString("yyyy-MM-dd") + " 20:00:00";
                }
                conn1.Close();
                BindGrid(day1,day2);
            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {
            ShowtimeSec.Text = DateTime.Now.ToString();
        }

        protected void ButtonPage24_Exit_Click(object sender, EventArgs e)
        {

            Session.Contents.Remove("SelectIndex2");
            Session.Contents.Remove("SelectIndex3");
            Session.Contents.Remove("SelectIndex4"); 
            Response.Redirect("Secondpage.aspx");
        }

        protected void Page24Screen_Click(object sender, EventArgs e)
        {


        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string day1 = null;
            string day2 = null;
            //if (DropDownList4.Text == "0")
            //{
            //    day1 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-01 05:30:00";
            //    if (DropDownList3.SelectedValue == "12")
            //    {
            //        day2 = (Convert.ToInt16(DateTime.Now.ToString("yyyy")) + 1).ToString() + "-01-01 05:30:00";
            //    }
            //    else
            //    {
            //        day2 = DateTime.Now.ToString("yyyy") + "-" + (Convert.ToInt16(DropDownList3.Text) + 1).ToString() + "-01 05:30:00";
            //    }

            //}
            //else
            {

                day1 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-" + DropDownList4.Text + " 05:30:00";
                day2 = DateTime.Now.ToString("yyyy") + "-" + DropDownList3.Text + "-" + DropDownList4.Text + " 19:30:00";
            }

            update(Convert.ToDateTime(day1), Convert.ToDateTime(day2));

            Session["SelectIndex3"] = DropDownList3.SelectedValue;
            Session["SelectIndex4"] = DropDownList4.SelectedValue;
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        private void BindGrid(string day1,string day2)
        {
           
            string uid = null;
            switch (Session["suidaocode"].ToString())
            {
                case "0100000000000":
                    uid = "CC6012070168";
                    break;
                case "0200000000000":
                    uid = "CC6012071120";
                    break;
                case "0300000000000":
                    uid = "CC0000000000";
                    break;
                default:
                    uid = null;
                    break;
            }

            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ConnectionString);
            sqlcon.Open();
            //String Sqlempinfo1 = "SELECT emp_Id as '序号',job_date as '日期',emp_No as '工号',emp_Name as ' 姓名',job_starttime as '上班时间' ,job_endtime as '下班时间' ,job_type as '班次'";
            String Sqlempinfo1 ="SELECT [id] as '序号', [cuid] as '探头UID编号', [lightness] as '光照亮度值', [lightlevel] as '光照亮度等级', [dbtime] as '采样时间' ";
            String Sqlempinfo2 = "FROM [LightLevel] WHERE ([cuid] = '" + uid + "') and  ((dbtime) between '" + day1 + "' and '" + day2 + "') ORDER BY [id] DESC";
            SqlDataAdapter adsa = new SqlDataAdapter(Sqlempinfo1 + Sqlempinfo2, sqlcon);
            DataSet ds = new DataSet();

            adsa.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridViewPage24.DataSource = ds;
                GridViewPage24.DataBind();

            }

            sqlcon.Close();
        }

        protected void update(DateTime day1, DateTime day2)
        {
            string uid = null;
            switch (Session["suidaocode"].ToString())
            {
                case "0100000000000":
                    uid = "CC6012070168";
                    break;
                case "0200000000000":
                    uid = "CC6012071120";
                    break;
                case "0300000000000":
                    uid = "CC0000000000";
                    break;
                default:
                    uid = null;
                    break;
            }

            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlempinfo = "select top(1) id from LightParam where ( cuid =  '" + uid + "') and (code = 'Page24') order by id desc";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand lightinfo = new SqlCommand(Sqlempinfo, conn);
            conn.Open();
            SqlDataReader light_info = lightinfo.ExecuteReader();

            if (light_info.Read())
            {
                conn.Close();
                Sqlempinfo = "update LightParam set starttime = '" + day1 + "' ,endtime= '" + day2 + "'  where ((cuid =  '" + uid + "') and (code = 'Page24'))";
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
                String Sqlempinfosert = "insert into LightParam values( '" + uid + "','" + day1 + "', '" + day2 + "','Page24')";
                SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                conn.Open();
                comminsert.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
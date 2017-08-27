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
    public partial class Page14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                string month1;
                string month2;
                if (Session["month1"] != null)
                {
                     month1 = Session["month1"].ToString();
                     month2 = Session["month2"].ToString();
                     
                }
                else
                {
                    month1 = DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2") + "-1";
                    month2 = null;
                    if (DateTime.Now.Month == 12)
                    {
                        month2 = (DateTime.Now.Year + 1).ToString() + "-" + "01-01";
                    }
                    else
                    {
                        month2 = DateTime.Now.Year.ToString("D4") + "-" + (DateTime.Now.Month + 1).ToString("D2") + "-1";
                    }
                }
               
                BindGrid(month1,month2);
                if (Session["SelectIndex1"] != null)
                {
                    DropDownList1.SelectedValue = Session["SelectIndex1"].ToString();
                }
                else
                {
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "select job_month from joblog where job_month <> 'Null' order by job_month desc  ";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand jobinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader job_info = jobinfo.ExecuteReader();
                    bool monthbool = false;
                    while (job_info.Read() == true)
                    {
                        if ((job_info["job_month"]).ToString() == (DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2")))
                        {
                            monthbool = true;
                            break;
                        }
                    }
                    conn.Close();

                    if (monthbool)
                    {
                        DropDownList1.SelectedValue = DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2");

                    }
                }

                if (Session["SelectIndex2"] != null)
                {
                    DropDownList2.SelectedValue = Session["SelectIndex2"].ToString();
                }
                else
                {
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "select job_year from joblog where job_year <> 'Null' order by job_year desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand jobinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader job_info = jobinfo.ExecuteReader();
                    bool yearbool = false;
                    while (job_info.Read() == true)
                    {
                        if (job_info["job_year"].ToString() == DateTime.Now.Year.ToString("D4"))
                        {
                            yearbool = true;
                            break;
                        }
                    }
                    conn.Close();
                    if (yearbool)
                    {
                        DropDownList2.SelectedValue = DateTime.Now.Year.ToString("D4");
                    }
                }
            }
        }

       
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage14.Text = DateTime.Now.ToString();

        }
        protected void ButtonP14_Exit_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("command");
            Session.Contents.Remove("month1");
            Session.Contents.Remove("month2");
            Session.Contents.Remove("SelectIndex1");
            Session.Contents.Remove("SelectIndex2");
            Session["IntoCode"] = "Welcome Into Firstpage";
            Response.Redirect("firstpage.aspx");
        }

     

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime temp = Convert.ToDateTime(DropDownList1.SelectedValue.ToString() + "-1");
            string month1 = temp.Year.ToString("D4") + "-" + temp.Month.ToString("D2")+ "-1";
            string month2 = Convert.ToDateTime(month1).Year.ToString("D4") + "-" + (Convert.ToDateTime(month1).Month + 1).ToString("D2")+ "-1";
            Session["month1"] = month1;
            Session["month2"] = month2;
            Session["SelectIndex1"] = DropDownList1.SelectedValue;
            Response.Redirect(Request.UrlReferrer.ToString());
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime temp = Convert.ToDateTime(DropDownList2.SelectedValue.ToString() + "-1-1");
            string month1 = temp.Year.ToString("D4") +"-1-1";
            string month2 = (Convert.ToDateTime(month1).Year + 1).ToString() + "-1-1";
            Session["month1"] = month1;
            Session["month2"] = month2;
            Session["SelectIndex2"] = DropDownList2.SelectedValue;
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        private void BindGrid(string month1,string month2)
        {

            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ConnectionString);

            sqlcon.Open();
            String Sqlempinfo1 = "SELECT job_id as '序号',emp1_name as '主值班',emp2_name as '值班员',emp3_name as '值班员',emp4_name as '主接班', emp5_name as '接班员',emp6_name as '接班员', job_time1 as '接班时间',job_time2 as '交班时间' ,job_remark1 as '监控运行',job_remark2 as '区域图象',job_remark3 as '照明控制',job_remark4 as '通风情况' ,job_remark5 as '紧急情况' , job_remark6 as '存在问题' ,job_remark7 as '卫生情况' ,job_remark8 as '物品交接' ,job_remarkdetail as '备注' ";
            String Sqlempinfo2 = "FROM [JobLog] where (job_time1) between  '" + month1 + "' and  '" + month2 + "' order by job_id desc ;";
            SqlDataAdapter adsa = new SqlDataAdapter(Sqlempinfo1+Sqlempinfo2, sqlcon);

            DataSet ds = new DataSet();

            adsa.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }

            sqlcon.Close();
        }

    }

}
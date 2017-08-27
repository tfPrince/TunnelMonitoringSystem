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
    public partial class Page15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                
                string month1 = null;
                string month2 = null;
                string emp_Name = "";
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
                        month2 = (DateTime.Now.Year + 1).ToString("D4") + "-" + "01-01";
                    }
                    else
                    {
                        month2 = DateTime.Now.Year.ToString("D4") + "-" + (DateTime.Now.Month + 1).ToString() + "-1";
                    }
                }
                if (Session["name"] != null)
                {
                    emp_Name = Session["name"].ToString();
                }

                BindGrid(month1, month2, emp_Name);


                if (Session["SelectIndex1"] != null)
                {
                    DropDownList1.SelectedValue = Session["SelectIndex1"].ToString();
                }
                else
                {
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "select emp_Name from employee_info where (emp_Name = ' ') OR (emp_limited = '33')  order by emp_Id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand jobinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader job_info = jobinfo.ExecuteReader();
                    bool yearbool = false;
                    while (job_info.Read() == true)
                    {
                        if (job_info["emp_Name"].ToString() == "")
                        {
                            yearbool = true;
                            break;
                        }
                    }
                    conn.Close();
                    if (yearbool)
                    {
                        DropDownList1.Text = "";
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
                    if (DropDownList4.Items.IndexOf(DropDownList4.Items.FindByValue("0")) != -1)
                    {
                        DropDownList4.SelectedValue = "0";
                    }

                }
            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage15.Text = DateTime.Now.ToString();

        }

        protected void ButtonP14_Exit_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("command");
            Session.Contents.Remove("month1");
            Session.Contents.Remove("month2");
            Session.Contents.Remove("SelectIndex1");
            Session.Contents.Remove("SelectIndex2");
            Session.Contents.Remove("SelectIndex3");
            Session.Contents.Remove("SelectIndex4");
            Session.Contents.Remove("name");
            Session["IntoCode"] = "Welcome Into Firstpage";
            Response.Redirect("firstpage.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string month1 = null;
            string month2 = null;
            if (DropDownList4.Text == "0")
            {
                if (DropDownList3.Text == "0")
                {
                    month1 = DropDownList2.Text + "-01-01";
                    month2 = (Convert.ToInt16(DropDownList2.Text) + 1).ToString() + "-01-01";

                }
                else
                {
                    month1 = DropDownList2.Text + "-" + DropDownList3.Text + " -01";
                    if (DropDownList3.SelectedValue == "12")
                    {
                        month2 = (Convert.ToInt16(DropDownList2.Text) + 1).ToString() + "-01-01";
                    }
                    else
                    {
                        month2 = DropDownList2.Text + "-"+(Convert.ToInt16(DropDownList3.Text) + 1).ToString() + "-01";
                    }

                }
            }
            else
            {
                if (DropDownList3.Text == "0")
                {
                    month1 = DropDownList2.Text + "-" + DateTime.Now.Month.ToString("D2") + "-" + DropDownList4.Text;
                }
                else
                {
                    month1 = DropDownList2.Text + "-" + DropDownList3.Text + "-" + DropDownList4.Text;
                    
                }
                month2 = "1900-01-01";
            }
            Session["month1"] = month1;
            Session["month2"] = month2;
            Session["name"] = DropDownList1.Text;
            Session["SelectIndex1"] = DropDownList1.SelectedValue;
            Session["SelectIndex2"] = DropDownList2.SelectedValue;
            Session["SelectIndex3"] = DropDownList3.SelectedValue;
            Session["SelectIndex4"] = DropDownList4.SelectedValue;
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        private void BindGrid(string month1, string month2, string emp_Name)
        {

            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ConnectionString);

            sqlcon.Open();
            String Sqlempinfo1 = "SELECT emp_Id as '序号',job_date as '日期',emp_No as '工号',emp_Name as ' 姓名',job_starttime as '上班时间' ,job_endtime as '下班时间' ,job_type as '班次'";
            String Sqlempinfo2 = null;
            if (month2 == "1900-01-01")
            {
                if (emp_Name == "")
                {
                    Sqlempinfo2 = "FROM [employee_manage] where( (job_date)= '" + month1 + "' )  ORDER BY  [emp_Id] DESC;";
                }
                else
                {
                    Sqlempinfo2 = "FROM [employee_manage] where( (job_date) = '" + month1 + "') and (emp_Name = '" + emp_Name + "') ORDER BY  [emp_Id] DESC;";
                }
            }
            else
            {
                if (emp_Name == "")
                {
                    Sqlempinfo2 = "FROM [employee_manage] where( (job_starttime) between  '" + month1 + "' and  '" + month2 + "')  ORDER BY  [emp_Id] DESC;";
                }
                else
                {
                    Sqlempinfo2 = "FROM [employee_manage] where( (job_starttime) between  '" + month1 + "' and  '" + month2 + "') and (emp_Name = '" + emp_Name + "') ORDER BY  [emp_Id] DESC;";
                }
            }
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

            //<asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            //  ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
    
            //  SelectCommand="SELECT emp_Id as '序号',emp_No as '工号',emp_Name as ' 姓名',job_starttime as '上班时间' ,job_endtime as '下班时间' ,job_type as '班次'  FROM [employee_manage] ORDER BY  [emp_Id] DESC">
            //</asp:SqlDataSource>
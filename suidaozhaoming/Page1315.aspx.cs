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
    public partial class Page1315 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Session["Three"].ToString())
            {
                case "Come from Page131-1":
                    TextBox1.Text = "请仔细核对你输入的数据!";
                    TextBox2.Text = "正确无误后输入密码确认";
                    break;
                case "Come from Page131-2":
                    TextBox1.Text = "请仔细考虑是否要注消该用户!";
                    TextBox2.Text = "无误后输入密码确认";
                    break;
                case "Come from Page131-3":
                    TextBox1.Text = "请仔细核对所修改的数据!";
                    TextBox2.Text = "正确无误后输入密码确认";
                    break;
                case  "Come from Page12":
                    TextBox1.Text = "请仔细确认上报所填数据!";
                    TextBox2.Text = "确认正确后输入密码确认";
                    break;
                default:
                    break;
            }
            
        }
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage12.Text = DateTime.Now.ToString();

        }
        protected void ButtonP1315_Exit_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Page131.aspx");
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            //Session["Emp_Name"] = "系管员";
            //if ((Session["Three"].ToString() == "Come from Page131-1") | (Session["Three"].ToString() == "Come from Page131-2") | (Session["Three"].ToString() == "Come from Page12"))
            //{
                string temp = null;
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String SqlempinfoIndex = "select top(1) emp_Key from employee_info  where emp_Name = '" + Session["Emp_Oper"] + "' order by emp_Id desc";
                SqlConnection connIndex = new SqlConnection(sqlconnection);
                SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
                while (emp_infoIndex.Read())
                {
                    temp = emp_infoIndex["emp_Key"].ToString();
                }
                connIndex.Close();
                if (temp == TextBoxPassword.Text)
                {
                    switch (Session["Three"].ToString())

                    //if (Session["Three"].ToString() == "Come from Page131-1")
                    {
                        case "Come from Page131-1":
                            SqlConnection conn = new SqlConnection(sqlconnection);
                            String Sqlempinfosert = "insert into employee_info values( '" + Session["Emp_No"] + "','" + Session["Emp_Name"] + "', '" + Session["Emp_Sex"] + "','" + Session["Emp_Lim"] + "','" + Session["Emp_Key"] + "',getdate(),'','true','" + Session["Emp_Tel1"] + "','" + Session["Emp_Tel2"] + "','" + Session["Emp_Oper"] + "','" + Session["Emp_Mark"] + "')";
                            SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                            conn.Open();
                            comminsert.ExecuteNonQuery();
                            conn.Close();
                            Session.Contents.Remove("Emp_No");
                            Session.Contents.Remove("Emp_Name");
                            Session.Contents.Remove("Emp_Sex");
                            Session.Contents.Remove("Emp_Lim");
                            Session.Contents.Remove("Emp_Key");
                            Session.Contents.Remove("Emp_Tel1");
                            Session.Contents.Remove("Emp_Tel2");
                            //Session.Contents.Remove("Emp_Oper");
                            Session.Contents.Remove("Emp_Mark");
                            //Session.Contents.Remove("Three");
                            Response.Redirect("Page131.aspx");
                            break;
                        //}
                        case "Come from Page131-2":
                            //if (Session["Three"].ToString() == "Come from Page131-2")
                            //{
                            String Sqlempinfo = "update employee_info set emp_Delete_Date = getdate(),emp_Register_State = 'false'  where Emp_Name ='" + Session["Emp_Name"] + "'";
                            conn = new SqlConnection(sqlconnection);
                            SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                            conn.Open();
                            empinfo.ExecuteNonQuery();
                            conn.Close();
                            Session.Contents.Remove("Emp_Name");
                            //Session.Contents.Remove("Three");
                            Response.Redirect("Page131.aspx");
                            //}
                            break;
                        case "Come from Page131-3":
                            Sqlempinfo = "update employee_info set emp_Name = '" + Session["Emp_Name"] + "',emp_Sex =  '" + Session["Emp_Sex"] + "',emp_Limited = '" + Session["Emp_Lim"] + "',emp_Key = '" + Session["Emp_Key"] + "',emp_telephon1 = '" + Session["Emp_Tel1"] + "' ,emp_telephon2 = '" + Session["Emp_Tel2"] + "',emp_Remark = '"+ Session["emp_Mark"] +"' where Emp_No ='" + Session["Emp_No"] + "'";
                            conn = new SqlConnection(sqlconnection);
                            empinfo = new SqlCommand(Sqlempinfo, conn);
                            conn.Open();
                            empinfo.ExecuteNonQuery();
                            conn.Close();
                            //Session.Contents.Remove("Emp_No");
                            Session.Contents.Remove("Emp_Name");
                            Session.Contents.Remove("Emp_Sex");
                            Session.Contents.Remove("Emp_Lim");
                            Session.Contents.Remove("Emp_Key");
                            Session.Contents.Remove("Emp_Tel1");
                            Session.Contents.Remove("Emp_Tel2");
                            Session.Contents.Remove("Emp_Mark");
                            //Session.Contents.Remove("Three");
                            Session["Joglog"] = "Come from Page131-3";
                            Response.Redirect("Page131.aspx");
                            break;
                        case "Come from Page12":
                           
                            String Text1 = string.Empty;
                            String Text2 = string.Empty;
                            String Text3 = string.Empty;
                            String Text4 = string.Empty;
                            String Text5 = string.Empty;
                            String Text6 = string.Empty;
                            String Text7 = string.Empty;
                            String Text8 = string.Empty;
                            String Text9 = string.Empty;
                            Sqlempinfo = "select top(1) job_No,job_remark1,job_remark2,job_remark3,job_remark4,job_remark5,job_remark6,job_remark7,job_remark8,job_remarkdetail from joblog_Temp order by job_No desc";
                            conn = new SqlConnection(sqlconnection);
                            SqlCommand jobinfo = new SqlCommand(Sqlempinfo, conn);
                            conn.Open();
                            SqlDataReader job_info = jobinfo.ExecuteReader();
                            if (job_info.Read())
                            {
                                Session["job_No"] = job_info["job_No"].ToString();
                                Text1 = job_info["job_remark1"].ToString();
                                Text2 = job_info["job_remark2"].ToString();
                                Text3 = job_info["job_remark3"].ToString();
                                Text4 = job_info["job_remark4"].ToString();
                                Text5 = job_info["job_remark5"].ToString();
                                Text6 = job_info["job_remark6"].ToString();
                                Text7 = job_info["job_remark7"].ToString();
                                Text8 = job_info["job_remark8"].ToString();
                                Text9 = job_info["job_remarkdetail"].ToString();
                            }
                            conn.Close();
                            //DateTime lastDate = new DateTime();
                            //lastDate = Convert.ToDateTime(Session["time"]);
                            string job_month = "Null";
                            string job_year = "Null";

                            Sqlempinfo = "select job_month from joblog where job_month <> 'Null' order by job_month desc  ";
                            conn = new SqlConnection(sqlconnection);
                            jobinfo = new SqlCommand(Sqlempinfo, conn);
                            conn.Open();
                            job_info = jobinfo.ExecuteReader();
                            bool monthbool = true;
                            while (job_info.Read() == true)
                            {
                                if ((job_info["job_month"]).ToString() == (DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2")))
                                {
                                    monthbool = false;
                                    break;
                                }
                            }
                            conn.Close();
                            if (monthbool)
                            {
                                job_month = DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2");
                                
                            }

                            Sqlempinfo = "select job_year from joblog where job_year <> 'Null' order by job_year desc";
                            conn = new SqlConnection(sqlconnection);
                            jobinfo = new SqlCommand(Sqlempinfo, conn);
                            conn.Open();
                            job_info = jobinfo.ExecuteReader();
                            bool yearbool = true;
                            while (job_info.Read() == true)
                            {
                                if (job_info["job_year"].ToString() == DateTime.Now.Year.ToString("D4"))
                                {
                                    yearbool = false;
                                    break;
                                }
                            }
                            conn.Close();
                            if (yearbool)
                            {
                                job_year = DateTime.Now.Year.ToString("D4");
                            }
                            
                            String Sqlempinfosert1 = "insert into joblog values('" + Session["No1"] + "','" + Session["Name1"] + "','" + Session["No2"] + "','" + Session["Name2"] + "','" + Session["No3"] + "','" + Session["Name3"] + "',";
                            String Sqlempinfosert2 = "'" + Session["emp_Oper_No"] + "','" + Session["emp_Oper"] + "','" + Session["No5"] + "','" + Session["Name5"] + "','" + Session["No6"] + "','" + Session["Name6"] + "','" + Session["time"] + "', getdate(),";
                            String Sqlempinfosert3 = " '"+job_month+"','"+ job_year +"','" + Text1 + "','" + Text2 + "','" + Text3 + "','" + Text4 + "','" + Text5 + "',";
                            String Sqlempinfosert4 = "'" + Text6 + "','" + Text7 + "','" + Text8 + "','" + Text9 + "')";

                            conn = new SqlConnection(sqlconnection);
                            comminsert = new SqlCommand(Sqlempinfosert1 + Sqlempinfosert2 + Sqlempinfosert3 + Sqlempinfosert4, conn);
                            conn.Open();
                            comminsert.ExecuteNonQuery();
                            conn.Close();
                            String Sqlempinfo1 = "update jobLog_Temp set job_remark1 = '" + string.Empty + "' ,job_remark2 = '" + string.Empty + "' ,job_remark3 = '" + string.Empty + "' ,job_remark4 = '" + string.Empty + "' ,job_remark5 = '" + string.Empty + "' ,job_remark6 = '" + string.Empty + "' ,";
                            String Sqlempinfo2 = "job_remark7 = '" + string.Empty + "' ,job_remark8 = '" + string.Empty + "' , job_remarkdetail = '" + string.Empty + "'  where job_No ='" + Session["job_No"] + "'";
                            conn = new SqlConnection(sqlconnection);
                            empinfo = new SqlCommand(Sqlempinfo1 + Sqlempinfo2, conn);
                            conn.Open();
                            empinfo.ExecuteNonQuery();
                            conn.Close();
                            //Session.Contents.Remove("Three");
                            Response.Redirect("Page12.aspx");
                            //}
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    TextBox1.Text = "你输入的密码有误!";
                    TextBox2.Text = "请输入正确密码";
                }
            //}
            
            

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            if ((Session["Three"].ToString() == "Come from Page131-1")|(Session["Three"].ToString() == "Come from Page131-2"))
            {
                Session.Contents.Remove("Emp_No");
                Session.Contents.Remove("Emp_Name");
                Session.Contents.Remove("Emp_Sex");
                Session.Contents.Remove("Emp_Lim");
                Session.Contents.Remove("Emp_Key");
                Session.Contents.Remove("Emp_Tel1");
                Session.Contents.Remove("Emp_Tel2");
                Session.Contents.Remove("Emp_Mark");
                //Session.Contents.Remove("Three");
                Response.Redirect("Page131.aspx");
            }
            if (Session["Three"].ToString() == "Come from Page12")
            {
                Session.Contents.Remove("No1");
                Session.Contents.Remove("No2");
                Session.Contents.Remove("No3");
                Session.Contents.Remove("No5");
                Session.Contents.Remove("No6");
                Session.Contents.Remove("Name1");
                Session.Contents.Remove("Name2");
                Session.Contents.Remove("Name3");
                Session.Contents.Remove("Name5");
                Session.Contents.Remove("Name6");
                //Session.Contents.Remove("Three");
                Response.Redirect("Page12.aspx");
            }
        }
    }
}
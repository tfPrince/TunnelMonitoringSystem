using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using suidaozhaoming.weatherwebservice;

namespace suidaozhaoming
{
    public partial class Page12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         if (Session["Joglog"].ToString() == "SH-LIGHT")
            {
                if (Page.IsPostBack)
                {

                }
                else
                {
                 if(Session["IntoPage121Code"].ToString() == "Confirm")
                    {
                        TextBoxName1.ReadOnly = true;
                        TextBoxName2.ReadOnly = true;
                        TextBoxName3.ReadOnly = true;
                        TextBoxName4.ReadOnly = true;
                        TextBoxName5.ReadOnly = true;
                        TextBoxName6.ReadOnly = true;
                        //DropDownList4.Enabled = false;
                        String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                        String Sqlempinfo = "select top(1) emp4_No,emp4_Name, emp5_No,emp5_Name, emp6_No,emp6_Name ,job_time2 from joblog order by job_Id desc";
                        SqlConnection conn = new SqlConnection(sqlconnection);
                        SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                        conn.Open();
                        SqlDataReader emp_info = empinfo.ExecuteReader();

                        if (emp_info.Read())
                        {

                            TextBoxName1.Text = emp_info["emp4_Name"].ToString();
                            TextBoxName2.Text = emp_info["emp5_Name"].ToString();
                            TextBoxName3.Text = emp_info["emp6_Name"].ToString();
                            TextBoxId1.Text = emp_info["emp4_No"].ToString();
                            TextBoxId2.Text = emp_info["emp5_No"].ToString();
                            TextBoxId3.Text = emp_info["emp6_No"].ToString();

                            TextBoxID4.Text = Session["emp_Oper_No"].ToString();
                            TextBoxName4.Text = Session["emp_Oper"].ToString();
                            
                            //DropDownList4.SelectedValue = Session["emp_Oper_No"].ToString();
                            DropDownList5.SelectedValue = Session["emp_Oper_No"].ToString();
                            DropDownList6.SelectedValue = Session["emp_Oper_No"].ToString();
                            TextBoxName5.Text = Session["emp_Oper"].ToString();
                            TextBoxName6.Text = Session["emp_Oper"].ToString();
                            Job_time1.Text = emp_info["job_time2"].ToString();

                        }
                        conn.Close();

                        Sqlempinfo = "select top(1) job_No,job_remark1,job_remark2,job_remark3,job_remark4,job_remark5,job_remark6,job_remark7,job_remark8,job_remarkdetail from joblog_Temp order by job_No desc";
                        empinfo = new SqlCommand(Sqlempinfo, conn);
                        conn.Open();
                        emp_info = empinfo.ExecuteReader();
                        if (emp_info.Read())
                        {
                            Session["job_No"] = emp_info["job_No"].ToString();
                            TextBoxJoblog1.Text = emp_info["job_remark1"].ToString(); 
                            TextBoxJoblog2.Text = emp_info["job_remark2"].ToString();
                            TextBoxJoblog3.Text = emp_info["job_remark3"].ToString();
                            TextBoxJoblog4.Text = emp_info["job_remark4"].ToString();
                            TextBoxJoblog5.Text = emp_info["job_remark5"].ToString();
                            TextBoxJoblog6.Text = emp_info["job_remark6"].ToString();
                            TextBoxJoblog7.Text = emp_info["job_remark7"].ToString();
                            TextBoxJoblog8.Text = emp_info["job_remark8"].ToString();
                            TextBoxMemo.Text = emp_info["job_remarkdetail"].ToString();
                        }
                        conn.Close();
                    }
                    else  //if (Session["IntoPage121Code"].ToString() == "Cancel")
                    {
                        String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                        String Sqlempinfo = "select top(1) * from joblog order by job_Id desc";    //desc 排到序
                        SqlConnection comm = new SqlConnection(sqlconnection);
                        SqlCommand empinfo = new SqlCommand(Sqlempinfo, comm);
                        string job_Id = string.Empty;

                        comm.Open();
                        SqlDataReader emp_info = empinfo.ExecuteReader();
                        if (emp_info.Read())
                        {
                            job_Id = emp_info["job_Id"].ToString();
                            TextBoxName1.Text = emp_info["emp1_Name"].ToString();
                            TextBoxName2.Text = emp_info["emp2_Name"].ToString();
                            TextBoxName3.Text = emp_info["emp3_Name"].ToString();
                            TextBoxId1.Text = emp_info["emp1_No"].ToString();
                            TextBoxId2.Text = emp_info["emp2_No"].ToString();
                            TextBoxId3.Text = emp_info["emp3_No"].ToString();
                           
                            TextBoxName4.Text = emp_info["emp4_Name"].ToString();
                            TextBoxName5.Text = emp_info["emp5_Name"].ToString();
                            TextBoxName6.Text = emp_info["emp6_Name"].ToString();
                            //DropDownList4.SelectedValue = emp_info["emp4_No"].ToString();
                            DropDownList5.SelectedValue = emp_info["emp5_No"].ToString();
                            DropDownList6.SelectedValue = emp_info["emp6_No"].ToString();

                            TextBoxJoblog1.Text = null;
                            TextBoxJoblog2.Text = null;
                            TextBoxJoblog3.Text = null;
                            TextBoxJoblog4.Text = null;
                            TextBoxJoblog5.Text = null;
                            TextBoxJoblog6.Text = null;
                            TextBoxJoblog7.Text = null;
                            TextBoxJoblog8.Text = null;
                            TextBoxMemo.Text = null;
                            //TextBoxJoblog1.Text = emp_info["job_remark1"].ToString();
                            //TextBoxJoblog2.Text = emp_info["job_remark2"].ToString();
                        }
                        comm.Close();
                        Sqlempinfo = "delete from joblog where (job_Id = '"+job_Id +"')";
                        SqlCommand emp_delete = new SqlCommand(Sqlempinfo, comm);
                        comm.Open();
                        emp_delete.ExecuteNonQuery();
                        comm.Close();
                    }
                }
                
            }
           else
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>window.close()</script>");
            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage12.Text = DateTime.Now.ToString();

        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //}

        //protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
        //    String Sqlempinfodel = "select emp_Name from employee_info  where (emp_No = '" + DropDownList4.SelectedValue.ToString() + "') ";
        //    SqlConnection conn = new SqlConnection(sqlconnection);
        //    SqlCommand empinfo = new SqlCommand(Sqlempinfodel, conn);
        //    //string emp_Name4 = string.Empty;
        //    conn.Open();
        //    SqlDataReader emp_info = empinfo.ExecuteReader();
        //    if (emp_info.Read())
        //    {
        //        TextBoxName4.Text  = emp_info["emp_Name"].ToString();
        //     }
        //    conn.Close();
            
        //}

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlempinfodel = "select emp_Name from employee_info  where (emp_No = '" + DropDownList5.SelectedValue.ToString() + "') ";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand empinfo = new SqlCommand(Sqlempinfodel, conn);
            //string emp_Name5 = string.Empty;
            conn.Open();
            SqlDataReader emp_info = empinfo.ExecuteReader();
            if (emp_info.Read())
            {
                TextBoxName5.Text = emp_info["emp_Name"].ToString();
            }
            conn.Close();
            
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlempinfodel = "select emp_Name from employee_info  where (emp_No = '" + DropDownList6.SelectedValue.ToString() + "') ";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand empinfo = new SqlCommand(Sqlempinfodel, conn);
            //string emp_Name6 = string.Empty;
            conn.Open();
            SqlDataReader emp_info = empinfo.ExecuteReader();
            if (emp_info.Read())
            {
                TextBoxName6.Text = emp_info["emp_Name"].ToString();
            }
            conn.Close();
            
        }

        protected void ButtonP12_Exit_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("job_No");
            Response.Redirect("firstpage.aspx");
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlempinfo1 = "update jobLog_Temp set job_remark1 = '" + TextBoxJoblog1.Text + "' ,job_remark2 = '" + TextBoxJoblog2.Text + "' ,job_remark3 = '" + TextBoxJoblog3.Text + "' ,job_remark4 = '" + TextBoxJoblog4.Text + "' ,job_remark5 = '" + TextBoxJoblog5.Text + "' ,job_remark6 = '" + TextBoxJoblog6.Text + "' ,";
            String Sqlempinfo2 = "job_remark7 = '" + TextBoxJoblog7.Text + "' ,job_remark8 = '" + TextBoxJoblog8.Text + "' , job_remarkdetail = '"+ TextBoxMemo.Text +"'  where job_No ='" + Session["job_No"] + "'";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand empinfo = new SqlCommand(Sqlempinfo1+Sqlempinfo2, conn);
            conn.Open();
            if (empinfo.ExecuteNonQuery() != 0)
            {
                //empinfo.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('数据保存成功')</script>", false);
            
            }
            else
            {
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('操作失败')</script>", false);
            
            }
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlempinfo1 = "update jobLog_Temp set job_remark1 = '" + TextBoxJoblog1.Text + "' ,job_remark2 = '" + TextBoxJoblog2.Text + "' ,job_remark3 = '" + TextBoxJoblog3.Text + "' ,job_remark4 = '" + TextBoxJoblog4.Text + "' ,job_remark5 = '" + TextBoxJoblog5.Text + "' ,job_remark6 = '" + TextBoxJoblog6.Text + "' ,";
            String Sqlempinfo2 = "job_remark7 = '" + TextBoxJoblog7.Text + "' ,job_remark8 = '" + TextBoxJoblog8.Text + "' , job_remarkdetail = '" + TextBoxMemo.Text + "'  where job_No ='" + Session["job_No"] + "'";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand empinfo = new SqlCommand(Sqlempinfo1 + Sqlempinfo2, conn);
            conn.Open();
            empinfo.ExecuteNonQuery();
            conn.Close();
            Session["Three"] = "Come from Page12";
            Session["Name1"] = TextBoxName1.Text.ToString();
            Session["Name2"] = TextBoxName2.Text.ToString();
            Session["Name3"] = TextBoxName3.Text.ToString();
            //Session["Name4"] = TextBoxName4.Text.ToString();
            Session["Name5"] = TextBoxName5.Text.ToString();
            Session["Name6"] = TextBoxName6.Text.ToString();
            Session["No1"] = TextBoxId1.Text.ToString();
            Session["No2"] = TextBoxId2.Text.ToString();
            Session["No3"] = TextBoxId3.Text.ToString();
            //Session["No4"] = DropDownList4.SelectedValue.ToString();
            Session["No5"] = DropDownList5.SelectedValue.ToString();
            Session["No6"] = DropDownList6.SelectedValue.ToString();
            Session["time"] = Job_time1.Text;
            Response.Redirect("Page1315.aspx");
           
        }
    }
}
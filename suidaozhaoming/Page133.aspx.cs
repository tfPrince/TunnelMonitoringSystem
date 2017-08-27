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
    public partial class Page133 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Joglog"].ToString() == "Into Page133")
            {
                
                if (Page.IsPostBack)
                {


                }
                else
                {
                    Emp_Id.ReadOnly = true;
                    Emp_No.ReadOnly = true;
                    Emp_Name.ReadOnly = true;
                    Emp_Sex.Enabled = false;
                    Emp_Lim.Enabled = false;
                    Emp_RDa.ReadOnly = true;
                    Emp_DDa.ReadOnly = true;
                    Emp_Key.ReadOnly = true;
                    Emp_Tel1.ReadOnly = true;
                    Emp_Tel2.ReadOnly = true;
                    Emp_Oper.ReadOnly = true;
                    Emp_Mark.ReadOnly = true;
                    
                    Next_Emp.Enabled = false;
                    Last_Emp.Enabled = false;
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "select top(1) emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info where emp_Name = '"+ Session["emp_Oper"] +"' order by emp_Id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader emp_info = empinfo.ExecuteReader();

                    while (emp_info.Read())
                    {
                        Session["count"] = emp_info["emp_Id"].ToString();
                        Emp_Id.Text = emp_info["emp_Id"].ToString();
                        Session["number"] = emp_info["emp_No"].ToString();
                        Emp_No.Text = emp_info["emp_No"].ToString();
                        Emp_Name.Text = emp_info["emp_Name"].ToString();
                        Emp_Sex.SelectedValue = emp_info["emp_Sex"].ToString();
                        Emp_Lim.SelectedValue = emp_info["emp_Limited"].ToString();

                        Emp_Key.Text = emp_info["emp_Key"].ToString();
                        Emp_Tel1.Text = emp_info["emp_telephon1"].ToString();
                        Emp_Tel2.Text = emp_info["emp_telephon2"].ToString();
                        Emp_Oper.Text = emp_info["emp_Operater"].ToString();
                        Emp_Mark.Text = emp_info["emp_Remark"].ToString();

                        if (emp_info["emp_Register_State"].ToString() == "True")
                        {
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_RDa.ForeColor = System.Drawing.Color.Black;
                            Emp_DDa.Text = null;
                        }
                        else
                        {
                            Emp_RDa.ForeColor = System.Drawing.Color.Red;
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                        }
                    }
                    conn.Close();
                }
            }

        }
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage12.Text = DateTime.Now.ToString();

        }

        protected void ButtonP13_Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("firstpage.aspx");
        }

        protected void Next_Click(object sender, EventArgs e)
        {

        }

        protected void Last_Click(object sender, EventArgs e)
        {
           
        }

        protected void Alt_Click(object sender, EventArgs e)
        {
            Ent_Emp.Enabled = true;
            Can_Emp.Enabled = true;
            Random r = new Random();

            Emp_Key.ReadOnly = false;
            Emp_Key.Enabled = true;
            Emp_Tel1.ReadOnly = false;
            Emp_Tel1.Enabled = true;
            Emp_Tel2.ReadOnly = false;
            Emp_Tel2.Enabled = true;
            Emp_Mark.ReadOnly = false;
            Emp_Mark.Enabled = true;

            
        }

       
        protected void Ent_Click(object sender, EventArgs e)
        {
            
                if ((Emp_Key.Text.Length >= 6)&(Emp_Key.Text.Length <= 10))
                {

                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "update employee_info set emp_Key = '" + Emp_Key.Text + "',emp_telephon1 = '" + Emp_Tel1.Text + "',emp_telephon2 = '" + Emp_Tel2.Text + "', emp_Remark ='" + Emp_Mark.Text + "' where Emp_Name ='" + Session["emp_Oper"] + "'";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    empinfo.ExecuteNonQuery();
                    conn.Close();
                    Emp_Key.ReadOnly = true;
                    Emp_Tel1.ReadOnly = true;
                    Emp_Tel2.ReadOnly = true;
                    Emp_Mark.ReadOnly = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('输入密码少于6位或大于10位');location='Page133.aspx'</script>", false);

                }
                Ent_Emp.Enabled = false;
                Can_Emp.Enabled = false;
        }

        protected void Can_Click(object sender, EventArgs e)
        {
            
                Emp_Key.ReadOnly = true;
                Emp_Tel1.ReadOnly = true;
                Emp_Tel2.ReadOnly = true;
                Emp_Mark.ReadOnly = true;
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfo = "select top(1) emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info where emp_Name = '" + Session["emp_Oper"] + "' order by emp_Id desc";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                conn.Open();
                SqlDataReader emp_info = empinfo.ExecuteReader();

                while (emp_info.Read())
                {
                    Session["count"] = emp_info["emp_Id"].ToString();
                    Emp_Id.Text = emp_info["emp_Id"].ToString();
                    Session["number"] = emp_info["emp_No"].ToString();
                    Emp_No.Text = emp_info["emp_No"].ToString();
                    Emp_Name.Text = emp_info["emp_Name"].ToString();
                    Emp_Sex.SelectedValue = emp_info["emp_Sex"].ToString();
                    Emp_Lim.SelectedValue = emp_info["emp_Limited"].ToString();
                    Emp_Key.Text = emp_info["emp_Key"].ToString();
                    Emp_Tel1.Text = emp_info["emp_telephon1"].ToString();
                    Emp_Tel2.Text = emp_info["emp_telephon2"].ToString();
                    Emp_Oper.Text = emp_info["emp_Operater"].ToString();
                    Emp_Mark.Text = emp_info["emp_Remark"].ToString();
                    if (emp_info["emp_Register_State"].ToString() == "True")
                    {
                        Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                        Emp_RDa.ForeColor = System.Drawing.Color.Black;
                        Emp_DDa.Text = null;
                        
                    }
                    else
                    {
                        Emp_RDa.ForeColor = System.Drawing.Color.Red;
                        Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                        Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                    }
                }
                conn.Close();

                Ent_Emp.Enabled = false;
                Can_Emp.Enabled = false;
                
            
           
        }

    }
}
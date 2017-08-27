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
    public partial class Page131 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Joglog"].ToString() == "Into Page131")|(Session["Joglog"].ToString() == "Come from Page131-3"))
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
                    Session["command"] = 0;
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = null;
                    if (Session["Joglog"].ToString() == "Into Page131")
                    {
                        Sqlempinfo = "select top(1) emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info order by emp_Id desc";
                    }
                    if (Session["Joglog"].ToString() == "Come from Page131-3")
                    {
                        Sqlempinfo = "select emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info where emp_No = '" + Session["Emp_No"] + "' order by emp_Id desc";
                    }
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
                        Emp_Name.Text = emp_info["emp_Name"].ToString() ;
                        Emp_Sex.SelectedValue = emp_info["emp_Sex"].ToString();
                        Emp_Lim.SelectedValue = emp_info["emp_Limited"].ToString();
                        
                        Emp_Key.Text = emp_info["emp_Key"].ToString();
                        Emp_Tel1.Text = emp_info["emp_telephon1"].ToString();
                        Emp_Tel2.Text = emp_info["emp_telephon2"].ToString();
                        Emp_Oper.Text = emp_info["emp_Operater"].ToString();
                        Emp_Mark.Text = emp_info["emp_Remark"].ToString();
                        
                        if(emp_info["emp_Register_State"].ToString() == "True")
                        {
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_RDa.ForeColor = System.Drawing.Color.Black;
                            Emp_DDa.Text = null;
                            Del_Emp.Enabled = true;
                        }
                        else 
                        {
                            Emp_RDa.ForeColor = System.Drawing.Color.Red;
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                            Del_Emp.Enabled = false;
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
 
        protected void ButtonP131_Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("firstpage.aspx");
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            
            //if (Convert.ToInt32(Emp_Id.Text) < Convert.ToInt32(Session["count"].ToString()))
            {
                int temp_Id = 000000;
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String SqlempinfoIndex = "select emp_Id from employee_info order by emp_Id ";
                SqlConnection connIndex = new SqlConnection(sqlconnection);
                SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
                while (emp_infoIndex.Read())
                {
                    if (Convert.ToInt32(emp_infoIndex["emp_Id"].ToString()) > Convert.ToInt32(Emp_Id.Text))
                    {
                        temp_Id = Convert.ToInt32(emp_infoIndex["emp_Id"].ToString());
                        Last_Emp.Enabled = true;
                        break;
                    }
                }
                connIndex.Close();
                if (temp_Id != 000000)
                {
                    String Sqlempinfo = "select emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Remark from employee_info where Emp_Id ='" + temp_Id + " 'order by emp_Id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader emp_info = empinfo.ExecuteReader();

                    while (emp_info.Read())
                    {

                        Emp_Id.Text = emp_info["emp_Id"].ToString();
                        Emp_No.Text = emp_info["emp_No"].ToString();
                        Emp_Name.Text = emp_info["emp_Name"].ToString();
                        Emp_Sex.Text = emp_info["emp_Sex"].ToString();
                        Emp_Lim.SelectedValue = emp_info["emp_Limited"].ToString();
                        
                        Emp_Key.Text = emp_info["emp_Key"].ToString();
                        Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                        Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                        Emp_Tel1.Text = emp_info["emp_telephon1"].ToString();
                        Emp_Tel2.Text = emp_info["emp_telephon2"].ToString();
                        Emp_Mark.Text = emp_info["emp_Remark"].ToString();
                        if (emp_info["emp_Register_State"].ToString() == "True")
                        {
                            Emp_RDa.ForeColor = System.Drawing.Color.Black;
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_DDa.Text = null;
                            Del_Emp.Enabled = true;
                        }
                        else
                        {
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_RDa.ForeColor = System.Drawing.Color.Red;
                            Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                            Del_Emp.Enabled = false;
                        }
                    }
                }
                else
                {
                    Next_Emp.Enabled = false;
                }
                
            }
            
            Session["command"] = 1;
        }

        protected void Last_Click(object sender, EventArgs e)
        {
            
            
                int temp_Id = 000000;
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String SqlempinfoIndex = "select emp_Id from employee_info order by emp_Id desc";
                SqlConnection connIndex = new SqlConnection(sqlconnection);
                SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
                while (emp_infoIndex.Read())
                {
                    if (Convert.ToInt32(emp_infoIndex["emp_Id"].ToString()) < Convert.ToInt32(Emp_Id.Text))
                    {
                        temp_Id = Convert.ToInt32(emp_infoIndex["emp_Id"].ToString());
                        Last_Emp.Enabled = true;
                        break;
                    }
                }
                connIndex.Close();
                if (temp_Id != 000000)
                {
                    String Sqlempinfo = "select  emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info where Emp_Id ='" + temp_Id + " 'order by emp_Id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader emp_info = empinfo.ExecuteReader();
                    while (emp_info.Read())
                    {

                        Emp_Id.Text = emp_info["emp_Id"].ToString();
                        Emp_No.Text = emp_info["emp_No"].ToString();
                        Emp_Name.Text = emp_info["emp_Name"].ToString();
                        Emp_Sex.SelectedValue = emp_info["emp_Sex"].ToString();
                        Emp_Lim.SelectedValue = emp_info["emp_Limited"].ToString();

                        Emp_Key.Text = emp_info["emp_Key"].ToString();
                        Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                        Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                        Emp_Tel1.Text = emp_info["emp_telephon1"].ToString();
                        Emp_Tel2.Text = emp_info["emp_telephon2"].ToString();
                        Emp_Oper.Text = emp_info["emp_Operater"].ToString();
                        Emp_Mark.Text = emp_info["emp_Remark"].ToString();
                        if (emp_info["emp_Register_State"].ToString() == "True")
                        {
                            Emp_RDa.ForeColor = System.Drawing.Color.Black;
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_DDa.Text = null;
                            Del_Emp.Enabled = true;
                        }
                        else
                        {
                            Emp_RDa.ForeColor = System.Drawing.Color.Red;
                            Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                            Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                            Del_Emp.Enabled = false;
                        }
                    }
                    Next_Emp.Enabled = true;
                }
                else
                {
                    Last_Emp.Enabled = false;
                }
            Session["command"] = 2;
        }

        protected void New_Click(object sender, EventArgs e)
        {
            if (Session["command"].ToString() == "5")
            {
                Session["Three"] = "Come from Page131-3";
                Session["Emp_No"] = Emp_No.Text.ToString();
                Session["Emp_Name"] = Emp_Name.Text.ToString();
                Session["Emp_Lim"] = Emp_Lim.SelectedValue;
                Session["Emp_Key"] = Emp_Key.Text.ToString();
                Session["Emp_Sex"] = Emp_Sex.SelectedValue;
                Session["Emp_Tel1"] = Emp_Tel1.Text.ToString();
                Session["Emp_Tel2"] = Emp_Tel2.Text.ToString();
                //Session["Emp_Oper"] = Emp_Oper.Text.ToString();
                Session["Emp_Mark"] = Emp_Mark.Text.ToString();
                Response.Redirect("Page1315.aspx");
            }
            else
            {
                Random r = new Random();

                Emp_No.Enabled = true;
                Emp_Name.ReadOnly = false;
                Emp_Name.Enabled = true;
                Emp_Sex.Enabled = true;
                Emp_Lim.Enabled = true;
                Emp_RDa.ReadOnly = false;
                Emp_DDa.ReadOnly = false;
                Emp_Key.ReadOnly = false;
                Emp_Key.Enabled = true;
                Emp_Tel1.ReadOnly = false;
                Emp_Tel1.Enabled = true;
                Emp_Tel2.ReadOnly = false;
                Emp_Tel2.Enabled = true;
                Emp_Mark.ReadOnly = false;
                Emp_Mark.Enabled = true;

                string temp_No = null;
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String SqlempinfoIndex = "select top(1) emp_Id from employee_info order by emp_Id desc";
                SqlConnection connIndex = new SqlConnection(sqlconnection);
                SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
                while (emp_infoIndex.Read())
                {

                    Session["count"] = Convert.ToInt32(emp_infoIndex["emp_Id"].ToString());

                }
                connIndex.Close();
                Emp_Id.Text = (Convert.ToInt32(Session["count"]) + 1).ToString();
                Emp_Lim.SelectedValue = "33";
                SqlempinfoIndex = "select top(1) emp_No from employee_info where emp_Limited ='" + Emp_Lim.SelectedValue + "' order by emp_Id desc";
                empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                emp_infoIndex = empinfoIndex.ExecuteReader();
                while (emp_infoIndex.Read())
                {

                    temp_No = (emp_infoIndex["emp_No"]).ToString();

                }
                connIndex.Close();
                if (temp_No == null)
                {
                    Emp_No.Text = "300000";

                }
                else
                {
                    Emp_No.Text = (Convert.ToInt32(temp_No) + 1).ToString("D6");
                }

                Emp_Key.Text = r.Next(1, 1000000).ToString();
                Emp_Sex.SelectedValue = "男";
                Emp_Name.Text = null; ;
                Emp_RDa.Text = DateTime.Now.ToString();

                Emp_Tel1.Text = "0573-";
                Emp_Tel2.Text = "0573-";
                Emp_Oper.Text = Session["emp_Oper"].ToString();
                Emp_Mark.Text = "－－此处填情况说明－－";
                Del_Emp.Text = "Enter";
                Alt_Emp.Text = "Cancel";
                Del_Emp.Enabled = true;
                Next_Emp.Enabled = false;
                Last_Emp.Enabled = false;
            }
            Session["command"] = 3;

        }

        protected void Emp_Changed(object sender, EventArgs e)
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String SqlempinfoIndex = "select top(1) emp_No from employee_info where emp_Limited ='" + Emp_Lim.SelectedValue + "' order by emp_Id desc";
            SqlConnection connIndex = new SqlConnection(sqlconnection);
            SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
            connIndex.Open();
            SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
            string temp_No = null;
            while (emp_infoIndex.Read())
            {

                temp_No = (emp_infoIndex["emp_No"]).ToString();

            }
            connIndex.Close();
            if (temp_No == null)
            {
                switch (Emp_Lim.SelectedValue)
                {
                    case "11":
                        Emp_No.Text = "100000";
                        break;
                    case "22":
                        Emp_No.Text = "200000";
                        break;
                    case "33":
                        Emp_No.Text = "300000";
                        break;
                    case "44":
                        Emp_No.Text = "400000";
                        break;
                    case "55":
                        Emp_No.Text = "500000";
                        break;
                    default:
                        break;
                }


            }
            else
            {
                Emp_No.Text = (Convert.ToInt32(temp_No) + 1).ToString("D6");
            }


        }

        protected void Del_Click(object sender, EventArgs e)
        {
            switch (Session["Command"].ToString())
            {
                case "3":
                    if ((Emp_Key.Text.Length >= 6) & (Emp_Key.Text.Length <= 10))
                    {
                        if ((Emp_Name.Text != string.Empty) & (Emp_No.Text != "000000"))
                        {

                            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                            SqlConnection conn = new SqlConnection(sqlconnection);
                            string Sqlempinfocheck = "select Emp_No from employee_info";
                            SqlCommand commcheck = new SqlCommand(Sqlempinfocheck, conn);
                            conn.Open();
                            SqlDataReader emp_info = commcheck.ExecuteReader();
                            bool tempbool = true;
                            while (emp_info.Read())
                            {
                                if (emp_info["Emp_No"].ToString() == Emp_No.Text)
                                {
                                    tempbool = false;
                                    break;
                                }
                            }
                            conn.Close();
                            if (tempbool)
                            {
                                Session["Three"] = "Come from Page131-1";
                                Session["Emp_No"] = Emp_No.Text.ToString();
                                Session["Emp_Name"] = Emp_Name.Text.ToString();
                                Session["Emp_Lim"] = Emp_Lim.SelectedValue;
                                Session["Emp_Key"] = Emp_Key.Text.ToString();
                                Session["Emp_Sex"] = Emp_Sex.SelectedValue;
                                Session["Emp_Tel1"] = Emp_Tel1.Text.ToString();
                                Session["Emp_Tex2"] = Emp_Tel2.Text.ToString();
                                //Session["Emp_Oper"] = Emp_Oper.Text.ToString();
                                Session["Emp_Mark"] = Emp_Mark.Text.ToString();
                                Response.Redirect("Page1315.aspx");
                            }
                            else
                            {
                                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('输入工号已存在');location='Page131.aspx'</script>", false);
                                Emp_No.Text = "账号已存在";
                            }
                        }
                        else
                        {
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('没有输入姓名或工号');location='Page131.aspx'</script>", false);
                            Emp_Name.Text = "输入姓名";
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('输入密码少于5位');location='Page131.aspx'</script>", false);
                        Emp_Key.Text = "密码少于6位或多于10位";
                    }
                    break;
                case "5":
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
                    String sqlconnection1 = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo1 = "select emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info where emp_Id = '" + Emp_Id.Text + "' order by emp_Id desc";
                    SqlConnection conn1 = new SqlConnection(sqlconnection1);
                    SqlCommand empinfo1 = new SqlCommand(Sqlempinfo1, conn1);
                    conn1.Open();
                    SqlDataReader emp_info1 = empinfo1.ExecuteReader();
                    while (emp_info1.Read())
                    {
                        Session["count"] = emp_info1["emp_Id"].ToString();
                        Emp_Id.Text = emp_info1["emp_Id"].ToString();
                        Session["number"] = emp_info1["emp_No"].ToString();
                        Emp_No.Text = emp_info1["emp_No"].ToString();
                        Emp_Name.Text = emp_info1["emp_Name"].ToString();
                        Emp_Sex.SelectedValue = emp_info1["emp_Sex"].ToString();
                        Emp_Lim.SelectedValue = emp_info1["emp_Limited"].ToString();
                        Emp_Key.Text = emp_info1["emp_Key"].ToString();
                        Emp_Tel1.Text = emp_info1["emp_telephon1"].ToString();
                        Emp_Tel2.Text = emp_info1["emp_telephon2"].ToString();
                        Emp_Oper.Text = emp_info1["emp_Operater"].ToString();
                        Emp_Mark.Text = emp_info1["emp_Remark"].ToString();
                        if (emp_info1["emp_Register_State"].ToString() == "True")
                        {
                            Emp_RDa.Text = emp_info1["emp_Register_Date"].ToString();
                            Emp_RDa.ForeColor = System.Drawing.Color.Black;
                            Emp_DDa.Text = null;
                            Del_Emp.Enabled = true;
                        }
                        else
                        {
                            Emp_RDa.ForeColor = System.Drawing.Color.Red;
                            Emp_RDa.Text = emp_info1["emp_Register_Date"].ToString();
                            Emp_DDa.Text = emp_info1["emp_Delete_Date"].ToString();
                            Del_Emp.Enabled = false;
                        }
                    }
                    conn1.Close();
                    Next_Emp.Enabled = true;
                    Last_Emp.Enabled = true;
                    Del_Emp.Text = "Del";
                    Alt_Emp.Text = "Alt";
                    Alt_Emp.Enabled = true;
                    break;
                default :
                    Session["Three"] = "Come from Page131-2";
                    Session["Emp_Name"] = Emp_Name.Text.ToString();
                    Response.Redirect("Page1315.aspx");
                    break;
            }
            
            
        }

        protected void Alt_Click(object sender, EventArgs e)
        {
            if (Session["Command"].ToString() == "3")
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
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfo = "select top(1) emp_Id,emp_No,emp_Name,emp_Sex,emp_Limited,emp_Key,emp_Register_Date,emp_Delete_Date,emp_Register_State,emp_telephon1,emp_telephon2,emp_Operater,emp_Remark from employee_info order by emp_Id desc";
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
                        Del_Emp.Enabled = true;
                    }
                    else
                    {
                        Emp_RDa.ForeColor = System.Drawing.Color.Red;
                        Emp_RDa.Text = emp_info["emp_Register_Date"].ToString();
                        Emp_DDa.Text = emp_info["emp_Delete_Date"].ToString();
                        Del_Emp.Enabled = false;
                    }
                }
                conn.Close();
                Next_Emp.Enabled = true;
                Last_Emp.Enabled = true;
                Del_Emp.Text = "Del";
                Alt_Emp.Text = "Alt";
            }
            else
            {
                Emp_No.Enabled = true;
                Emp_Name.ReadOnly = false;
                Emp_Name.Enabled = true;
                Emp_Sex.Enabled = true;
                Emp_Lim.Enabled = true;
                Emp_RDa.ReadOnly = false;
                Emp_DDa.ReadOnly = false;
                Emp_Key.ReadOnly = false;
                Emp_Key.Enabled = true;
                Emp_Tel1.ReadOnly = false;
                Emp_Tel1.Enabled = true;
                Emp_Tel2.ReadOnly = false;
                Emp_Tel2.Enabled = true;
                Emp_Mark.ReadOnly = false;
                Emp_Mark.Enabled = true;
                New_Emp.Text = "Ent";
                Del_Emp.Text = "Cancel";
                Next_Emp.Enabled = false;
                Last_Emp.Enabled = false;
                Alt_Emp.Enabled = false;
            }
            Session["command"] = 5;
        }

        
        
    }
}
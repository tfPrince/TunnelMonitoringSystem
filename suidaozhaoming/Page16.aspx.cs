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
    public partial class Page16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Joglog"].ToString() == "Into Page16")
            {
                
                if (Page.IsPostBack)
                {


                }
                else
                {
                   
                    //Alt_Emp.Enabled = false;
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String Sqlempinfo = "select top(1) Tunnel_No,Tunnel_Name,Tunnel_Code,Tunnel_Address,Tunnel_Weather_Address,Tunnel_Entrance_Name,Tunnel_Entrance_Label,Tunnel_Exit_Name,Tunnel_Exit_Label,Tunnel_Remark from Tunnel_Message order by Tunnel_Id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader emp_info = empinfo.ExecuteReader();
                    
                    Tunnel_Code.ReadOnly = true;
                    Tunnel_No.ReadOnly = true;
                    Tunnel_Addr.ReadOnly = true; 
                    Tunnel_Name.ReadOnly = true;
                    Tunnel_Ent_L.ReadOnly = true;
                    Tunnel_Ent_N.ReadOnly = true;
                    Tunnel_Ext_L.ReadOnly = true;
                    Tunnel_Ext_N.ReadOnly = true;
                    Tunnel_Mark.ReadOnly = true;
                    Tunnel_Weather.ReadOnly = true;
                    while (emp_info.Read())
                    {
                        //Session["count"] = emp_info["Tunnel_No"].ToString();
                        Tunnel_No.Enabled = false;
                        Tunnel_No.Text = emp_info["Tunnel_No"].ToString();
                        Tunnel_Code.Text = emp_info["Tunnel_Code"].ToString();
                        Tunnel_Name.Text = emp_info["Tunnel_Name"].ToString();

                        Tunnel_Ent_N.Text = emp_info["Tunnel_Entrance_Name"].ToString();
                        Tunnel_Ent_L.Text = emp_info["Tunnel_Entrance_Label"].ToString();
                        Tunnel_Ext_N.Text = emp_info["Tunnel_Exit_Name"].ToString();
                        Tunnel_Ext_L.Text = emp_info["Tunnel_Exit_Label"].ToString();
                        Tunnel_Addr.Text = emp_info["Tunnel_Address"].ToString();
                        Tunnel_Weather.Text = emp_info["Tunnel_Weather_Address"].ToString();
                        Tunnel_Mark.Text = emp_info["Tunnel_ReMark"].ToString();

                       
                    }
                    conn.Close();
                }
            }

        }
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage16.Text = DateTime.Now.ToString();

        }

        protected void ButtonP16_Exit_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("command");
            Session["IntoCode"] = "Welcome Into Firstpage";
            Response.Redirect("firstpage.aspx");
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            
            {
                int temp_No = 000000;
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String SqlempinfoIndex = "select Tunnel_No from  Tunnel_Message order by Tunnel_Id ";
                SqlConnection connIndex = new SqlConnection(sqlconnection);
                SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
                while (emp_infoIndex.Read())
                {
                    if (Convert.ToInt32(emp_infoIndex["Tunnel_No"].ToString()) > Convert.ToInt32(Tunnel_No.Text))
                    {
                        temp_No = Convert.ToInt32(emp_infoIndex["Tunnel_No"].ToString());
                        Last_Emp.Enabled = true;
                        break;
                    }
                }
                connIndex.Close();
                if (temp_No != 000000)
                {
                    String Sqlempinfo = "select top(1) Tunnel_No,Tunnel_Name,Tunnel_Code,Tunnel_Address,Tunnel_Weather_Address,Tunnel_Entrance_Name,Tunnel_Entrance_Label,Tunnel_Exit_Name,Tunnel_Exit_Label,Tunnel_Remark from Tunnel_Message where Tunnel_No ='" + temp_No + " ' order by Tunnel_Id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader emp_info = empinfo.ExecuteReader();

                     while (emp_info.Read())
                    {
                        //Session["count"] = emp_info["Tunnel_No"].ToString();
                        Tunnel_No.Text = emp_info["Tunnel_No"].ToString();
                        Tunnel_Code.Text = emp_info["Tunnel_Code"].ToString();
                        Tunnel_Name.Text = emp_info["Tunnel_Name"].ToString();

                        Tunnel_Ent_N.Text = emp_info["Tunnel_Entrance_Name"].ToString();
                        Tunnel_Ent_L.Text = emp_info["Tunnel_Entrance_Label"].ToString();
                        Tunnel_Ext_N.Text = emp_info["Tunnel_Exit_Name"].ToString();
                        Tunnel_Ext_L.Text = emp_info["Tunnel_Exit_Label"].ToString();
                        Tunnel_Addr.Text = emp_info["Tunnel_Address"].ToString();
                        Tunnel_Weather.Text = emp_info["Tunnel_Weather_Address"].ToString();
                        Tunnel_Mark.Text = emp_info["Tunnel_ReMark"].ToString();

                       
                    }
                     Next_Emp.Enabled = true;
                }
                else
                {
                    Next_Emp.Enabled = false;
                }

            }

        }

        protected void Last_Click(object sender, EventArgs e)
        {

            int temp_No = 000000;
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String SqlempinfoIndex = "select Tunnel_No from  Tunnel_Message order by Tunnel_Id desc";
            SqlConnection connIndex = new SqlConnection(sqlconnection);
            SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
            connIndex.Open();
            SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
            while (emp_infoIndex.Read())
            {
                if (Convert.ToInt32(emp_infoIndex["Tunnel_No"].ToString()) < Convert.ToInt32(Tunnel_No.Text))
                {
                    temp_No = Convert.ToInt32(emp_infoIndex["Tunnel_No"].ToString());
                    Last_Emp.Enabled = true;
                    break;
                }
            }
            connIndex.Close();
            if (temp_No != 000000)
            {
                String Sqlempinfo = "select top(1) Tunnel_No,Tunnel_Name,Tunnel_Code,Tunnel_Address,Tunnel_Weather_Address,Tunnel_Entrance_Name,Tunnel_Entrance_Label,Tunnel_Exit_Name,Tunnel_Exit_Label,Tunnel_Remark from Tunnel_Message where Tunnel_No ='" + temp_No + " ' order by Tunnel_Id desc";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand empinfo = new SqlCommand(Sqlempinfo, conn);
                conn.Open();
                SqlDataReader emp_info = empinfo.ExecuteReader();
                 while (emp_info.Read())
                    {
                        //Session["count"] = emp_info["Tunnel_No"].ToString();
                        Tunnel_No.Text = emp_info["Tunnel_No"].ToString();
                        Tunnel_Code.Text = emp_info["Tunnel_Code"].ToString();
                        Tunnel_Name.Text = emp_info["Tunnel_Name"].ToString();

                        Tunnel_Ent_N.Text = emp_info["Tunnel_Entrance_Name"].ToString();
                        Tunnel_Ent_L.Text = emp_info["Tunnel_Entrance_Label"].ToString();
                        Tunnel_Ext_N.Text = emp_info["Tunnel_Exit_Name"].ToString();
                        Tunnel_Ext_L.Text = emp_info["Tunnel_Exit_Label"].ToString();
                        Tunnel_Addr.Text = emp_info["Tunnel_Address"].ToString();
                        Tunnel_Weather.Text = emp_info["Tunnel_Weather_Address"].ToString();
                        Tunnel_Mark.Text = emp_info["Tunnel_ReMark"].ToString();

                       
                    }
                 
                Next_Emp.Enabled = true;
            }
            else
            {
                Last_Emp.Enabled = false;
            }
        }

        protected void New_Click(object sender, EventArgs e)
        {
            //string temp_No = null;
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String SqlempinfoIndex = "select top(1) Tunnel_No,Tunnel_Code from Tunnel_Message order by Tunnel_Id desc";
            SqlConnection connIndex = new SqlConnection(sqlconnection);
            SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
            connIndex.Open();
            SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
            while (emp_infoIndex.Read())
            {

                //Session["count"] = Convert.ToInt32(emp_infoIndex["Tunnel_No"].ToString());
                Tunnel_No.Text = (Convert.ToInt32(emp_infoIndex["Tunnel_No"]) + 1).ToString();
                Tunnel_Code.Text = (Convert.ToInt64(emp_infoIndex["Tunnel_Code"]) + 100000000000).ToString("D13");

            }
            connIndex.Close();

            Tunnel_Name.Text = "";
            Tunnel_Ent_N.Text = "";
            Tunnel_Ent_L.Text = "";
            Tunnel_Ext_N.Text = "";
            Tunnel_Ext_L.Text = "";
            Tunnel_Addr.Text = "";
            Tunnel_Weather.Text = "";
            Tunnel_Mark.Text = "";
            Tunnel_Addr.ReadOnly = false;
            Tunnel_Name.ReadOnly = false;
            Tunnel_Ent_L.ReadOnly = false;
            Tunnel_Ent_N.ReadOnly = false;
            Tunnel_Ext_L.ReadOnly = false;
            Tunnel_Ext_N.ReadOnly = false;
            Tunnel_Mark.ReadOnly = false;
            Tunnel_Weather.ReadOnly = false;
            Ent_Emp.Enabled = true;
            Alt_Emp.Enabled = false;
            Del_Emp.Enabled = false;
            Session["command"] = "3";
            
        }

        protected void Alt_Click(object sender, EventArgs e)
        {
            Tunnel_Addr.ReadOnly = false;
            Tunnel_Name.ReadOnly = false;
            Tunnel_Ent_L.ReadOnly = false;
            Tunnel_Ent_N.ReadOnly = false;
            Tunnel_Ext_L.ReadOnly = false;
            Tunnel_Ext_N.ReadOnly = false;
            Tunnel_Mark.ReadOnly = false;
            Tunnel_Weather.ReadOnly = false;
            Ent_Emp.Enabled = true;
            New_Emp.Enabled = false;
            Del_Emp.Enabled = false;
            Session["command"] = "4";
        }

        protected void Del_Click(object sender, EventArgs e)
        {
            Tunnel_Name.Text = "";
            Tunnel_Ent_N.Text = "";
            Tunnel_Ent_L.Text = "";
            Tunnel_Ext_N.Text = "";
            Tunnel_Ext_L.Text = "";
            Tunnel_Addr.Text = "";
            Tunnel_Weather.Text = "";
            Tunnel_Mark.Text = "";
            
            Ent_Emp.Enabled = true;
            New_Emp.Enabled = false;
            Alt_Emp.Enabled = false;
            
            Session["command"] = "5";
        }
       
        protected void Ent_Click(object sender, EventArgs e)
        {
            if (Session["command"].ToString() == "3")
            {
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfosert = "insert into Tunnel_Message values('" + Convert.ToInt16(Tunnel_No.Text) + "','" + Convert.ToInt16(Tunnel_No.Text) + "','" + Tunnel_Name.Text + "', '" + Tunnel_Code.Text + "','" + Tunnel_Addr.Text + "','" + Tunnel_Weather.Text + "','" + Tunnel_Ent_N.Text + "' ,'" + Tunnel_Ent_L.Text + "','" + Tunnel_Ext_N.Text + "','" + Tunnel_Ext_L.Text + "','" + true + "','" + Tunnel_Mark.Text + "')";
                //String Sqlempinfosert = "insert into Tunnel_Message values('" + Convert.ToInt16(Tunnel_No.Text) + "','" + Tunnel_Name.Text.ToString() + "', '" + Tunnel_Code.Text.ToString() + "','" + Tunnel_Addr.Text.ToString() + "','" + Tunnel_Weather.Text.ToString() + "','" + Tunnel_Ent_N.Text.ToString() + "' ,'" + Tunnel_Ent_L.Text.ToString() + "','" + Tunnel_Ext_N.Text.ToString() + "','" + Tunnel_Ext_L.Text.ToString() + "','"+ true +"','" + Tunnel_Mark.Text.ToString() + "')";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                conn.Open();
                //comminsert.ExecuteNonQuery();
                if (comminsert.ExecuteNonQuery() != 0)
                {
                    //conn.Close();
                    //Session.Contents.Remove("IntoPage131Id");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('新建数据成功')</script>", false);
                }
                else
                {
                    //conn.Close();
                    //Session.Contents.Remove("IntoPage131Id");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('操作失败')</script>", false);
                }
                conn.Close();
            }
            else
            {
                Tunnel_Addr.ReadOnly = false;
               
            }
            if (Session["command"].ToString() == "4")
            {
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfo1 = "update Tunnel_Message set Tunnel_Code = '" + Tunnel_Code.Text + "',Tunnel_Name = '" + Tunnel_Name.Text + "',Tunnel_Entrance_Name = '" + Tunnel_Ent_N.Text + "', Tunnel_Entrance_Label ='" + Tunnel_Ent_L.Text + "',Tunnel_Exit_Name = '" + Tunnel_Ext_N.Text + "', Tunnel_Exit_Label ='" + Tunnel_Ext_L.Text + "',";
                String Sqlempinfo2 = "Tunnel_Address ='" + Tunnel_Addr.Text + "',Tunnel_Weather_Address ='" + Tunnel_Weather.Text + "',Tunnel_ReMark ='"+ Tunnel_Mark.Text +"'  where Tunnel_No ='" + Convert.ToInt16(Tunnel_No.Text) + "'";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand empinfo = new SqlCommand(Sqlempinfo1 + Sqlempinfo2 , conn);
                conn.Open();
                //empinfo.ExecuteNonQuery();
                if (empinfo.ExecuteNonQuery() != 0)
                {
                    //conn.Close();
                    //Session.Contents.Remove("IntoPage131Id");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('修改数据成功')</script>", false);
                }
                else
                {
                    //conn.Close();
                    //Session.Contents.Remove("IntoPage131Id");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('操作失败')</script>", false);
                }
                conn.Close();
                
            }
            if (Session["command"].ToString() == "5")
            {
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfodel = "delete from Tunnel_Message  where (Tunnel_No = '" + Convert.ToInt16(Tunnel_No.Text) + "') and (Tunnel_Code ='" + Tunnel_Code.Text + "')";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand empinfo = new SqlCommand(Sqlempinfodel, conn);
                conn.Open();
                if (empinfo.ExecuteNonQuery() != 0)
                {
                    //conn.Close();
                    //Session.Contents.Remove("IntoPage131Id");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('删除成功')</script>", false);
                }
                else
                {
                    //conn.Close();
                    //Session.Contents.Remove("IntoPage131Id");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('删除失败')</script>", false);
                }
                conn.Close();

                //String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlempinfo = "select top(1) Tunnel_No,Tunnel_Name,Tunnel_Code,Tunnel_Address,Tunnel_Weather_Address,Tunnel_Entrance_Name,Tunnel_Entrance_Label,Tunnel_Exit_Name,Tunnel_Exit_Label,Tunnel_Remark from Tunnel_Message order by Tunnel_Id desc";
                //SqlConnection conn = new SqlConnection(sqlconnection);
                empinfo = new SqlCommand(Sqlempinfo, conn);
                conn.Open();
                SqlDataReader emp_info = empinfo.ExecuteReader();

                while (emp_info.Read())
                {
                    //Session["count"] = emp_info["Tunnel_No"].ToString();
                    //Tunnel_No.Enabled = false;
                    Tunnel_No.Text = emp_info["Tunnel_No"].ToString();
                    Tunnel_Code.Text = emp_info["Tunnel_Code"].ToString();
                    Tunnel_Name.Text = emp_info["Tunnel_Name"].ToString();

                    Tunnel_Ent_N.Text = emp_info["Tunnel_Entrance_Name"].ToString();
                    Tunnel_Ent_L.Text = emp_info["Tunnel_Entrance_Label"].ToString();
                    Tunnel_Ext_N.Text = emp_info["Tunnel_Exit_Name"].ToString();
                    Tunnel_Ext_L.Text = emp_info["Tunnel_Exit_Label"].ToString();
                    Tunnel_Addr.Text = emp_info["Tunnel_Address"].ToString();
                    Tunnel_Weather.Text = emp_info["Tunnel_Weather_Address"].ToString();
                    Tunnel_Mark.Text = emp_info["Tunnel_ReMark"].ToString();


                }
                conn.Close();
            }

            Tunnel_Addr.ReadOnly = true;
            Tunnel_Name.ReadOnly = true;
            Tunnel_Ent_L.ReadOnly = true;
            Tunnel_Ent_N.ReadOnly = true;
            Tunnel_Ext_L.ReadOnly = true;
            Tunnel_Ext_N.ReadOnly = true;
            Tunnel_Mark.ReadOnly = true;
            Tunnel_Weather.ReadOnly = true;
            Session["command"] = "6";
            Ent_Emp.Enabled = false;
            New_Emp.Enabled = true;
            Alt_Emp.Enabled = true;
            Del_Emp.Enabled = true;
        }

    

        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            //Alt_Emp.Enabled = true;
            //Session["command"] = "1";
        }
    }
}
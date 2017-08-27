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
    public partial class Page161 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Joglog"].ToString() == "Into Page161")
            {

                if (Page.IsPostBack)
                {


                }
                else
                {


                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    String Sqlempinfo = "select top(1) * from Tunnel_Info order by id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand tunnelinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader tunnel_info = tunnelinfo.ExecuteReader();

                    TextBoxId1.ReadOnly = true;
                    TextBoxId2.ReadOnly = true;
                    TextBoxId3.ReadOnly = true;
                    TextBoxId4.ReadOnly = true;
                    TextBoxId5.ReadOnly = true;
                    TextBoxId6.ReadOnly = true;
                    TextBoxId7.ReadOnly = true;
                    TextBoxId8.ReadOnly = true;
                    CheckBoxId1.Enabled = false;
                    DropDownList1.Enabled = false;

                    Ent_Info.Enabled = false;

                    while (tunnel_info.Read())
                    {
                        TextBoxId1.Text = tunnel_info["id"].ToString();
                        TextBoxId2.Text = tunnel_info["unitUID"].ToString();
                        TextBoxId3.Text = tunnel_info["unitName"].ToString();
                        TextBoxId4.Text = tunnel_info["cUID"].ToString();
                        TextBoxId5.Text = tunnel_info["tunnelCode"].ToString();
                        TextBoxId6.Text = tunnel_info["tunnelName"].ToString();
                        TextBoxId7.Text = tunnel_info["tunnelPosition"].ToString();
                        TextBoxId8.Text = tunnel_info["unitPosition"].ToString();

                        DropDownList1.SelectedValue = tunnel_info["location"].ToString();
                        CheckBoxId1.Checked = Convert.ToBoolean(tunnel_info["unitState"]);

                    }
                    conn.Close();
                }
            }
        }

        protected void GetTimer(object sender, EventArgs e)
        {
            showtimePage161.Text = DateTime.Now.ToString();
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
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                String SqlempinfoIndex = "select id from  Tunnel_Info order by id ";
                SqlConnection connIndex = new SqlConnection(sqlconnection);
                SqlCommand tunnelinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
                connIndex.Open();
                SqlDataReader tunnel_infoIndex = tunnelinfoIndex.ExecuteReader();
                while (tunnel_infoIndex.Read())
                {
                    if (Convert.ToInt32(tunnel_infoIndex["id"].ToString()) > Convert.ToInt32(TextBoxId1.Text))
                    {
                        temp_No = Convert.ToInt32(tunnel_infoIndex["id"].ToString());
                        Last_Info.Enabled = true;
                        break;
                    }
                }
                connIndex.Close();
                if (temp_No != 000000)
                {
                    String Sqlempinfo = "select top(1) * from Tunnel_Info  where id ='" + temp_No + "' order by id desc";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand tunnelinfo = new SqlCommand(Sqlempinfo, conn);
                    conn.Open();
                    SqlDataReader tunnel_info = tunnelinfo.ExecuteReader();

                    while (tunnel_info.Read())
                    {
                        TextBoxId1.Text = tunnel_info["id"].ToString();
                        TextBoxId2.Text = tunnel_info["unitUID"].ToString();
                        TextBoxId3.Text = tunnel_info["unitName"].ToString();
                        TextBoxId4.Text = tunnel_info["cUID"].ToString();
                        TextBoxId5.Text = tunnel_info["tunnelCode"].ToString();
                        TextBoxId6.Text = tunnel_info["tunnelName"].ToString();
                        TextBoxId7.Text = tunnel_info["tunnelPosition"].ToString();
                        TextBoxId8.Text = tunnel_info["unitPosition"].ToString();

                        DropDownList1.SelectedValue = tunnel_info["location"].ToString();
                        CheckBoxId1.Checked = Convert.ToBoolean(tunnel_info["unitState"]);


                    }
                    Next_Info.Enabled = true;
                }
                else
                {
                    Next_Info.Enabled = false;
                }

            }

        }

        protected void Last_Click(object sender, EventArgs e)
        {
            int temp_No = 000000;
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
            String SqlempinfoIndex = "select id from  Tunnel_Info order by id desc";
            SqlConnection connIndex = new SqlConnection(sqlconnection);
            SqlCommand empinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
            connIndex.Open();
            SqlDataReader emp_infoIndex = empinfoIndex.ExecuteReader();
            while (emp_infoIndex.Read())
            {
                if (Convert.ToInt32(emp_infoIndex["id"].ToString()) < Convert.ToInt32(TextBoxId1.Text))
                {
                    temp_No = Convert.ToInt32(emp_infoIndex["id"].ToString());
                    Last_Info.Enabled = true;
                    break;
                }
            }
            connIndex.Close();
            if (temp_No != 000000)
            {
                String Sqlempinfo = "select top(1) * from Tunnel_Info  where id ='" + temp_No + "' order by id desc";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand tunnelinfo = new SqlCommand(Sqlempinfo, conn);
                conn.Open();
                SqlDataReader tunnel_info = tunnelinfo.ExecuteReader();
                while (tunnel_info.Read())
                {
                    TextBoxId1.Text = tunnel_info["id"].ToString();
                    TextBoxId2.Text = tunnel_info["unitUID"].ToString();
                    TextBoxId3.Text = tunnel_info["unitName"].ToString();
                    TextBoxId4.Text = tunnel_info["cUID"].ToString();
                    TextBoxId5.Text = tunnel_info["tunnelCode"].ToString();
                    TextBoxId6.Text = tunnel_info["tunnelName"].ToString();
                    TextBoxId7.Text = tunnel_info["tunnelPosition"].ToString();
                    TextBoxId8.Text = tunnel_info["unitPosition"].ToString();

                    DropDownList1.SelectedValue = tunnel_info["location"].ToString();
                    CheckBoxId1.Checked = Convert.ToBoolean(tunnel_info["unitState"]);


                }

                Next_Info.Enabled = true;
            }
            else
            {
                Last_Info.Enabled = false;
            }
        }

        protected void New_Click(object sender, EventArgs e)
        {
            //string temp_No = null;
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
            String SqlempinfoIndex = "select top(1) id from Tunnel_info order by id desc";
            SqlConnection connIndex = new SqlConnection(sqlconnection);
            SqlCommand tunnelinfoIndex = new SqlCommand(SqlempinfoIndex, connIndex);
            connIndex.Open();
            SqlDataReader tunnel_infoIndex = tunnelinfoIndex.ExecuteReader();
            while (tunnel_infoIndex.Read())
            {

                TextBoxId1.Text = (Convert.ToInt32(tunnel_infoIndex["id"]) + 1).ToString();
                
            }
            connIndex.Close();

            TextBoxId1.ReadOnly = true;
            TextBoxId2.ReadOnly = false;
            TextBoxId3.ReadOnly = false;
            TextBoxId4.ReadOnly = false;
            TextBoxId5.ReadOnly = false;
            TextBoxId6.ReadOnly = false;
            TextBoxId7.ReadOnly = false;
            TextBoxId8.ReadOnly = false;
            CheckBoxId1.Enabled = true;
            DropDownList1.Enabled = true;

            TextBoxId2.Text = "000000000000";
            TextBoxId3.Text = "";
            TextBoxId4.Text = "000000000000";
            TextBoxId5.Text = "0000000000000";
            TextBoxId6.Text = "";
            TextBoxId7.Text = "";
            TextBoxId8.Text = "";

            DropDownList1.SelectedValue = "01";
            CheckBoxId1.Checked = false;
            Ent_Info.Enabled = true;
            New_Info.Enabled = false;
            Alt_Info.Enabled = false;
            Del_Info.Enabled = false;
            Session["command"] = "3";
        }

        protected void Alt_Click(object sender, EventArgs e)
        {
            TextBoxId1.ReadOnly = true;
            TextBoxId2.ReadOnly = false;
            TextBoxId3.ReadOnly = false;
            TextBoxId4.ReadOnly = false;
            TextBoxId5.ReadOnly = false;
            TextBoxId6.ReadOnly = false;
            TextBoxId7.ReadOnly = false;
            TextBoxId8.ReadOnly = false;
            CheckBoxId1.Enabled = true;
            DropDownList1.Enabled = true;

            Ent_Info.Enabled = true;
            New_Info.Enabled = false;
            Del_Info.Enabled = false;
            Alt_Info.Enabled = false;
            Session["command"] = "4";
        }

        protected void Del_Click(object sender, EventArgs e)
        {
            TextBoxId2.Text = "000000000000";
            TextBoxId3.Text = "";
            TextBoxId4.Text = "000000000000";
            TextBoxId5.Text = "0000000000000";
            TextBoxId6.Text = "";
            TextBoxId7.Text = "";
            TextBoxId8.Text = "";

            Ent_Info.Enabled = true;
            New_Info.Enabled = false;
            Alt_Info.Enabled = false;
            Del_Info.Enabled = false;
            Session["command"] = "5";
        }

        protected void Ent_Click(object sender, EventArgs e)
        {
            if (Session["command"].ToString() == "3")
            {
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                String Sqlempinfosert = "insert into Tunnel_Info values('" + (TextBoxId2.Text) + "','" + TextBoxId3.Text + "', '" + TextBoxId4.Text + "','" + DropDownList1.SelectedValue + "','" + TextBoxId5.Text + "','" + TextBoxId6.Text + "','" + TextBoxId7.Text + "' ,'" + TextBoxId8.Text + "','" + CheckBoxId1.Checked + "')";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                conn.Open();
                if (comminsert.ExecuteNonQuery() != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('新建数据成功')</script>", false);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('操作失败')</script>", false);
                }
                conn.Close();
            }
            

            if (Session["command"].ToString() == "4")
            {
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                String Sqlempinfo1 = "update Tunnel_Info set unitUID = '" + TextBoxId2.Text + "',unitName = '" + TextBoxId3.Text + "', cUID ='" + TextBoxId4.Text + "',location = '" + DropDownList1.SelectedValue + "', tunnelCode ='" + TextBoxId5.Text + "',";
                String Sqlempinfo2 = "tunnelName ='" + TextBoxId6.Text + "',tunnelPosition ='" + TextBoxId7.Text + "',unitPosition ='" + TextBoxId8.Text + "',unitState = '"+ CheckBoxId1.Checked+"'  where id ='" + Convert.ToInt16(TextBoxId1.Text) + "'";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand empinfo = new SqlCommand(Sqlempinfo1 + Sqlempinfo2, conn);
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
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                String Sqlempinfodel = "delete from Tunnel_Info  where (id = '" + Convert.ToInt16(TextBoxId1.Text) + "') ";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand empinfo = new SqlCommand(Sqlempinfodel, conn);
                conn.Open();
                if (empinfo.ExecuteNonQuery() != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('删除成功')</script>", false);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('删除失败')</script>", false);
                }
                conn.Close();

                String Sqlempinfo = "select top(1) * from Tunnel_Info order by id desc";
                SqlCommand tunnelinfo = new SqlCommand(Sqlempinfo, conn);
                conn.Open();
                SqlDataReader tunnel_info = tunnelinfo.ExecuteReader();

                while (tunnel_info.Read())
                {
                    TextBoxId1.Text = tunnel_info["id"].ToString();
                    TextBoxId2.Text = tunnel_info["unitUID"].ToString();
                    TextBoxId3.Text = tunnel_info["unitName"].ToString();
                    TextBoxId4.Text = tunnel_info["cUID"].ToString();
                    TextBoxId5.Text = tunnel_info["tunnelCode"].ToString();
                    TextBoxId6.Text = tunnel_info["tunnelName"].ToString();
                    TextBoxId7.Text = tunnel_info["tunnelPosition"].ToString();
                    TextBoxId8.Text = tunnel_info["unitPosition"].ToString();

                    DropDownList1.SelectedValue = tunnel_info["location"].ToString();
                    CheckBoxId1.Checked = Convert.ToBoolean(tunnel_info["unitState"]);



                }
                conn.Close();
            }

            TextBoxId1.ReadOnly = true;
            TextBoxId2.ReadOnly = true;
            TextBoxId3.ReadOnly = true;
            TextBoxId4.ReadOnly = true;
            TextBoxId5.ReadOnly = true;
            TextBoxId6.ReadOnly = true;
            TextBoxId7.ReadOnly = true;
            TextBoxId8.ReadOnly = true;
            CheckBoxId1.Enabled = false;
            DropDownList1.Enabled = false;
            Session["command"] = "6";
            Ent_Info.Enabled = false;
            New_Info.Enabled = true;
            Alt_Info.Enabled = true;
            Del_Info.Enabled = true;
        }
    }
}
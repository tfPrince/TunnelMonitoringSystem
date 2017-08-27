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


namespace suidaozhaoming
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["IntoCode"].ToString() == "Welcome Into Firstpage")
            {
                //Session.Contents.Remove("Joglog");

                if (Page.IsPostBack)
                {
                    // showtime.Text = DateTime.Now.ToString();             
                    getsuidaoming();
                    getwanninglight();

                }
                else
                {
                    //if (Session["emp_Limited"].ToString() == "33")
                    //{
                    //    jiaojiebanjilu.Enabled = true;
                    //}
                    //else
                    //{
                    //    jiaojiebanjilu.Enabled = false;
                    //}
                    if (Session["emp_Limited"].ToString() == "11")
                    {
                        SystemSet.Visible = true;
                        BottonText.Visible = true;
                    }
                    else
                    {
                        SystemSet.Visible = false;
                        BottonText.Visible = false;
                    }
                    showtime.Text = DateTime.Now.ToString();
                    getsuidaoming();
                    //getweather();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>window.close()</script>");
            }
        }

        public String[,] suidaoread = new String[9, 3];
        public int suidaonum;

        protected void GetTimer(object sender, EventArgs e)
        {

            showtime.Text = DateTime.Now.ToString();

        }

        protected void No1suidaodetail(object sender, EventArgs e)
        {
            if (No1suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No1suidao.Text;
                Session["suidaocode"] = suidaoread[0, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No2suidaodetail(object sender, EventArgs e)
        {
            if (No2suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No2suidao.Text;
                Session["suidaocode"] = suidaoread[1, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No3suidaodetail(object sender, EventArgs e)
        {
            if (No3suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No3suidao.Text;
                Session["suidaocode"] = suidaoread[2, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No4suidaodetail(object sender, EventArgs e)
        {
            if (No4suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No4suidao.Text;
                Session["suidaocode"] = suidaoread[3, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No5suidaodetail(object sender, EventArgs e)
        {
            if (No5suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No5suidao.Text;
                Session["suidaocode"] = suidaoread[4, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No6suidaodetail(object sender, EventArgs e)
        {
            if (No6suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No6suidao.Text;
                Session["suidaocode"] = suidaoread[5, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No7suidaodetail(object sender, EventArgs e)
        {
            if (No7suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No7suidao.Text;
                Session["suidaocode"] = suidaoread[6, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No8suidaodetail(object sender, EventArgs e)
        {
            if (No8suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No8suidao.Text;
                Session["suidaocode"] = suidaoread[7, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void No9suidaodetail(object sender, EventArgs e)
        {
            if (No9suidao.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["suidaoming"] = No9suidao.Text;
                Session["suidaocode"] = suidaoread[8, 1].ToString();
                Session["IntoCode"] = "Welcome Into Secondpage";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void Xunchajianshi_Click(object sender, EventArgs e)
        {

            if (suidaoread[0, 0].ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
            }
            else
            {
                Session["i"] = 0;
                Session["suidaoming"] = suidaoread[Convert.ToInt16(Session["i"]), 0].ToString(); ;
                Session["suidaocode"] = suidaoread[Convert.ToInt16(Session["i"]), 1].ToString();
                Session["IntoCode"] = "Come from Inspect";
                Response.Redirect("secondpage.aspx");
            }
        }

        protected void Joblog_Click(object sender, EventArgs e)
        {
            if (Session["emp_Limited"].ToString() == "33") 
            {
                Session["Joglog"] = "SH-LIGHT";
                Session["IntoPage121Code"] = "Confirm";
                Response.Redirect("Page12.aspx");

            }
            else
            {
                Session["ScriptN"] = "Joblog_Click";
                Response.Redirect("ScriptNote.aspx");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>style='font-size:40px; width:390px;float:right';alert('对不起，你没有修改系统权限！');location='Secondpage.aspx'  </script>", false);               
            }           
        }

        //protected void ButtonFir_Exit_Click(object sender, EventArgs e)
        //{
        //    Session.Contents.Remove("Joglog");
        //    Session.Contents.Remove("IntoPage121Code");
        //    //Response.Redirect("login.aspx");
        //    //Session.Contents.Abandon();

        //    //Response.End();

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>.close()</script>"); 

        //}

        protected void Employee_Click(object sender, EventArgs e)
        {
            if ((Session["Emp_Limited"].ToString() == "11") | (Session["Emp_Limited"].ToString() == "22"))
            {
                Session["Joglog"] = "Into Page131";
                Response.Redirect("Page131.aspx");
            }
            else
            {
                Session["Joglog"] = "Into Page133";
                Response.Redirect("Page133.aspx");
            }
        }

        protected void JobRecord_Click(object sender, EventArgs e)
        {
            Session["Joglog"] = "Into Page14";
            Response.Redirect("Page14.aspx");
        }

        protected void DataRecord_Click(object sender, EventArgs e)
        {
            Session["Joglog"] = "Into Page15";
            Response.Redirect("Page15.aspx");
        }

        protected void Set_Click(object sender, EventArgs e)
        {
            //Session["Joglog"] = "Into Page160";
            Response.Redirect("Page160.aspx");
        }

        public void getsuidaoming()
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlsuidaocount = "select count(1) from Tunnel_Message";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand comm = new SqlCommand(Sqlsuidaocount, conn);
            conn.Open();
            suidaonum = Convert.ToInt32(comm.ExecuteScalar().ToString());
            conn.Close();
            
            if (suidaonum <= 9)
            {
                nextpage.Visible = true;                     //false 是不显示
                nextpage.Enabled = false;
                nextpage.ImageUrl = "~/pic/GoaheadVir.png";

            }
            else
            {
                nextpage.Visible = true;                     //false 是不显示
                nextpage.Enabled = true;
                nextpage.ImageUrl = "~/pic/goahead.png";

            }

            String Sqlsudiaoinfo = "select top(9) Tunnel_name,Tunnel_code,Tunnel_Weather_Address from Tunnel_Message order by Tunnel_code asc";
            SqlCommand suidaoinfo = new SqlCommand(Sqlsudiaoinfo, conn);
            conn.Open();
            SqlDataReader suidao_info = suidaoinfo.ExecuteReader();
            for (int m = 0; m < 9; m++)
            {
                suidaoread[m, 0] = String.Empty;
                suidaoread[m, 1] = String.Empty;
                suidaoread[m, 2] = String.Empty;
            }

            int i = 0;
            while (suidao_info.Read() == true)
            {
                suidaoread[i, 0] = suidao_info["Tunnel_name"].ToString();
                suidaoread[i, 1] = suidao_info["Tunnel_code"].ToString();
                suidaoread[i, 2] = suidao_info["Tunnel_Weather_Address"].ToString();
                i++;
            }
            conn.Close();

            if (suidaoread[0, 0] != "")
            {
                No1suidao.Text = suidaoread[0, 0];
                No1warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[1, 0] != "")
            {
                No2suidao.Text = suidaoread[1, 0];
                No2warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[2, 0] != "")
            {
                No3suidao.Text = suidaoread[2, 0];
                No3warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[3, 0] != "")
            {
                No4suidao.Text = suidaoread[3, 0];
                No4warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[4, 0] != "")
            {
                No5suidao.Text = suidaoread[4, 0];
                No5warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[5, 0] != "")
            {
                No6suidao.Text = suidaoread[5, 0];
                No6warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[6, 0] != "")
            {
                No7suidao.Text = suidaoread[6, 0];
                No7warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[7, 0] != "")
            {
                No8suidao.Text = suidaoread[7, 0];
                No8warning.ImageUrl = "~/pic/normal.png";
            }
            if (suidaoread[8, 0] != "")
            {
                No9suidao.Text = suidaoread[8, 0];
                No9warning.ImageUrl = "~/pic/normal.png";
            }

        }

        protected void Nextpagedetail(object sender, EventArgs e)
        {

            Session["suidaoming"] = No9suidao.Text;
            Session["suidaocode"] = suidaoread[8, 1].ToString();
            Response.Redirect("secondpage.aspx");

        }

        public void getwanninglight()     //获得隧道报警信息
        {

            //No1warning.ImageUrl = "~/pic/normal.png";
            //No2warning.ImageUrl = "~/pic/normal.png";
            //No3warning.ImageUrl = "~/pic/normal.png";
            //No4warning.ImageUrl = "~/pic/normal.png";
            //No5warning.ImageUrl = "~/pic/normal.png";
            //No6warning.ImageUrl = "~/pic/normal.png";
            //No7warning.ImageUrl = "~/pic/normal.png";
            //No8warning.ImageUrl = "~/pic/normal.png";
            //No9warning.ImageUrl = "~/pic/normal.png";

            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
            String Sqlwarnningcount = "select count(1) from ALARM_INFO";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand comm = new SqlCommand(Sqlwarnningcount, conn);
            conn.Open();
            int num = Convert.ToInt32(comm.ExecuteScalar().ToString());
            conn.Close();
            if (num > 0)
            {
                String Sqlwarnninginfo = "select CONUID,CONFIRM from ALARM_INFO  order by DATE_TIME ";
                SqlCommand warnningget = new SqlCommand(Sqlwarnninginfo, conn);
                string[] UnitID = new string[num];
                string[] conFirm = new string[num];
                conn.Open();
                SqlDataReader suidaowarning_info = warnningget.ExecuteReader();
                int i = 0;
                while (suidaowarning_info.Read() == true)
                {
                    UnitID[i] = suidaowarning_info["CONUID"].ToString();
                    conFirm[i] = suidaowarning_info["CONFIRM"].ToString();
                    i++;
                }
                conn.Close();

                for (int j = 0; j < num; j++)
                {
                    string tcode = null;
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    String SqlTunnelDisData = "select top(1) tunnelCode from Tunnel_Info where unitUID = '" + UnitID[j] + "'";
                    SqlConnection read_conn = new SqlConnection(sqlconnection);
                    SqlCommand SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    SqlDataReader Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read())
                    {
                        tcode = Power_data["tunnelCode"].ToString();

                    }
                    read_conn.Close();
                    if (conFirm[j].ToString() == "1")
                    {
                        switch (tcode)
                        {
                            case "0100000000000":
                                No1warning.ImageUrl = "~/pic/normal.png";
                                break;
                            case "0200000000000":
                                No2warning.ImageUrl = "~/pic/normal.png";
                                break;
                            case "0300000000000":
                                No3warning.ImageUrl = "~/pic/normal.png";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (tcode)
                        {
                            case "0100000000000":
                                No1warning.ImageUrl = "~/pic/warn.png";
                                break;
                            case "0200000000000":
                                No2warning.ImageUrl = "~/pic/warn.png";
                                break;
                            case "0300000000000":
                                No3warning.ImageUrl = "~/pic/warn.png";
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
        }
    }
}
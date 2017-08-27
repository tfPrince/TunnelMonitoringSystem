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
    public partial class Page28 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {                                              //下面程序重复执行

            }
            else                                          //下面程序只在进入该网页时执行一次
            {
                showtimePage27.Text = DateTime.Now.ToString();
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    String Sqlwarnningcount = "select count(1) from ALARM_INFO ";
                    SqlConnection conn = new SqlConnection(sqlconnection);
                    SqlCommand comm = new SqlCommand(Sqlwarnningcount, conn);
                    conn.Open();
                    int num = Convert.ToInt32(comm.ExecuteScalar().ToString());
                    conn.Close();
                    if (num > 0)
                    {
                        String Sqlwarnninginfo = "select ID,TYPE,NAME,CONFIRM,INFO, CONUID from ALARM_INFO  order by DATE_TIME ";
                        SqlCommand warnningget = new SqlCommand(Sqlwarnninginfo, conn);
                        string[] ID = new string[num];
                        string[] UnitID = new string[num];
                        string[] conFirm = new string[num];
                        string[] Type = new string[num];
                        string[] Name = new string[num];
                        string[] Info = new string[num];
                        //string[] TunnelP = new string[num];
                        //string[] UnitP = new string[num];

                        conn.Open();
                        SqlDataReader suidaowarning_info = warnningget.ExecuteReader();
                        int i = 0;
                        while (suidaowarning_info.Read() == true)
                        {
                            ID[i] = suidaowarning_info["ID"].ToString();
                            Type[i] = suidaowarning_info["TYPE"].ToString();
                            Name[i] = suidaowarning_info["NAME"].ToString();
                            conFirm[i] = suidaowarning_info["CONFIRM"].ToString();
                            Info[i] = suidaowarning_info["INFO"].ToString();
                            UnitID[i] = suidaowarning_info["CONUID"].ToString();
                            //TunnelP[i] = suidaowarning_info["tunnelPosition"].ToString();
                            //UnitP[i] = suidaowarning_info["unitPosition"].ToString();
                            i++;
                        }
                        conn.Close();

                        string tcode = null;
                        string cUID = null;
                        string tPosition = null;
                        string uPosition = null;
                        sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                        String SqlTunnelDisData = "select top(1) unitUID,cUID,tunnelPosition,unitPosition  from Tunnel_Info where ((tunnelCode = '" + Session["suidaocode"].ToString() + "') and (location = '" + Session["Warm"].ToString() + "'))";
                        SqlConnection read_conn = new SqlConnection(sqlconnection);
                        SqlCommand SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                        read_conn.Open();
                        SqlDataReader Power_data = SqlTunnelData.ExecuteReader();
                        while (Power_data.Read())
                        {
                            tcode = Power_data["unitUID"].ToString();
                            cUID = Power_data["cUID"].ToString();
                            tPosition = Power_data["tunnelPosition"].ToString();
                            uPosition = Power_data["unitPosition"].ToString();
                        }
                        read_conn.Close();
                        for (int j = num - 1; j >= 0; j--)
                        {
                            if (tcode == UnitID[j].ToString())
                            {
                                TextBox1.Text = ID[j].ToString();
                                TextBox2.Text = UnitID[j].ToString();
                                TextBox3.Text = Name[j].ToString();
                                TextBox4.Text = cUID;
                                TextBox5.Text = Session["suidaocode"].ToString();
                                TextBox6.Text = Session["suidaoming"].ToString() + "隧道";
                                TextBox7.Text = tPosition;
                                TextBox8.Text = uPosition;
                                if (conFirm[j].ToString() == "1")
                                {
                                    TextBox9.Text = "恢复";
                                }
                                else
                                {
                                    TextBox9.Text = "故障";
                                }
                                TextBox10.Text = Type[j].ToString();

                                break;
                            }
                            TextBox1.Text = "00000";
                            TextBox2.Text = "没有故障信息";
                            TextBox4.Text = "";
                            TextBox5.Text = Session["suidaocode"].ToString();
                            TextBox6.Text = Session["suidaoming"].ToString() + "隧道";
                            TextBox7.Text = "隧道位址";
                            TextBox8.Text = "安装位置";
                            TextBox9.Text = "";
                            TextBox10.Text = "";
                        }
                        
                    }
            }
        }
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage27.Text = DateTime.Now.ToString();

        }

        protected void ButtonP27_Exit_Click(object sender, EventArgs e)
        {

            Session.Contents.Remove("Warm"); 
            Session["IntoCode"] = "Welcome Into Secondpage";
            Response.Redirect("Secondpage.aspx");
        }
        protected void Next_Click(object sender, EventArgs e)
        {
        }

        protected void Last_Click(object sender, EventArgs e)
        {
        }

    }
}
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
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace suidaozhaoming
{
    public partial class Secondpage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {                                              //下面程序重复执行
                
                getTunnelDisData();
                
            }
            else                                          //下面程序只在进入该网页时执行一次
            {
                Button_EnergyH.Text = "00.00度";
                Button_EnergyDay.Text = "000000.00";
                //switch (Session["IntoCode"].ToString())
                //{
                //    case "Welcome Into Secondpage":
                //        Page.Title = Session["suidaoming"].ToString() + "隧道照明监控系统";
                //        LabelSec_Title.Text = Session["suidaoming"].ToString() + "隧道监控系统";
                //        ShowtimeSec.Text = DateTime.Now.ToString();

                //        get_weather();
                //        get_message();
                //        break;
                //    case "Come from Inspect":
                //        Page.Title = Session["suidaoming"].ToString() + "隧道照明监控系统";
                //        LabelSec_Title.Text = Session["suidaoming"].ToString() + "隧道监控系统";
                //        ShowtimeSec.Text = DateTime.Now.ToString();

                //        get_weather();
                //        get_message();
                //        break;
                //    default:
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>window.close()</script>");
                //        break;

                //}
                Page.Title = Session["suidaoming"].ToString() + "隧道照明监控系统";
                LabelSec_Title.Text = Session["suidaoming"].ToString() + "隧道监控系统";
                ShowtimeSec.Text = DateTime.Now.ToString();

                get_weather();
                get_message();
                switch (Session["suidaocode"].ToString())
                {
                    case "0100000000000":
                        //LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        LoacationU7.Text = "右加强";
                        LoacationU6.Text = "右基照明";
                        LoacationU5.Text = "左基照明";
                        LoacationU4.Text = "左加强";
                        LoacationU3.Text = "两侧加强";
                        LoacationU2.Text = "";
                        LoacationU1.Text = "";
                        No3warnUp.Enabled = true;
                        No4warnUp.Enabled = true;
                        No5warnUp.Enabled = true;
                        No6warnUp.Enabled = true;
                        No7warnUp.Enabled = true;
                        break;
                    case "0200000000000":
                        LoacationU7.Text = "左出加强";
                        LoacationU6.Text = "左过加强";
                        LoacationU5.Text = "左基照明";
                        LoacationU4.Text = "右基照明";
                        LoacationU3.Text = "两侧加强";
                        LoacationU2.Text = "右加强";
                        LoacationU1.Text = "左入加强";
                        No1warnUp.Enabled = true;
                        No2warnUp.Enabled = true;
                        No3warnUp.Enabled = true;
                        No4warnUp.Enabled = true;
                        No5warnUp.Enabled = true;
                        No6warnUp.Enabled = true;
                        No7warnUp.Enabled = true;
                        break;
                    case "0300000000000":
                        LoacationU7.Text = "";
                        LoacationU6.Text = "";
                        LoacationU5.Text = "右侧基本";
                        LoacationU4.Text = "左加强双";
                        LoacationU3.Text = "左加强单";
                        LoacationU2.Text = "右加强双";
                        LoacationU1.Text = "右加强单";
                        No1warnUp.Enabled = true;
                        No2warnUp.Enabled = true;
                        No3warnUp.Enabled = true;
                        No4warnUp.Enabled = true;
                        No5warnUp.Enabled = true;
                        
                        break;
                    default:
                        break;
                }
                
            }
            
           
        }

        public String[,] suidaoread = new String[9, 3];
        public int suidaonum;

        protected void GetTimer(object sender, EventArgs e)
        {
            ShowtimeSec.Text = DateTime.Now.ToString();
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

        }

        private void getTunnelDisData()
        {
            switch (Session["suidaocode"].ToString())
            {
                case "0100000000000":
                    String LedUnitUid = null;
                    //昱岭关右入左出第3桩灯功率指示
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    String SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '13' and unitState = 'true' and cUID = 'CC6012070168' and tunnelCOde = '0100000000000') order by id desc";
                    SqlConnection read_led = new SqlConnection(sqlconnection);
                    SqlCommand SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    SqlDataReader Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    String SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    SqlConnection read_conn = new SqlConnection(sqlconnection);
                    SqlCommand SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    SqlDataReader Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        if (Convert.ToInt16(Power_data["ActivePower_A"]) == 0)
                        {
                            this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                            //this.LoacationU3.Text = "两侧加强";
                        }
                        else
                        {
                            this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                            //this.LoacationU3.Text = "两侧加强";
                        }
                        No3BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                       
                    }
                    read_conn.Close();
                    //昱岭关右入左出第4桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '14' and unitState = 'true' and cUID = 'CC6012070168' and tunnelCOde = '0100000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        if (Convert.ToInt16(Power_data["ActivePower_A"]) == 0)
                        {
                            this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                            //this.LoacationU4.Text = "右基照明";
                        }
                        else
                        {
                            this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                           // this.LoacationU4.Text = "右基照明";
                        }
                        No4BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();
                    //昱岭关右入左出第5桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '15' and unitState = 'true' and cUID = 'CC6012070168' and tunnelCOde = '0100000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        No5BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();
                    //昱岭关右入左出第6桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '16' and unitState = 'true' and cUID = 'CC6012070168' and tunnelCOde = '0100000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        if (Convert.ToInt16(Power_data["ActivePower_A"]) == 0)
                        {
                            this.LoacationU6.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                            //this.LoacationU6.Text = "右基照明";
                        }
                        else
                        {
                            this.LoacationU6.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        }
                        No6BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";                                                
                    }
                    read_conn.Close();
                    //昱岭关右入左出第7桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '17' and unitState = 'true' and cUID = 'CC6012070168' and tunnelCOde = '0100000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        if (Convert.ToInt16(Power_data["ActivePower_A"]) == 0)
                        {
                            this.LoacationU7.ForeColor = System.Drawing.Color.FromArgb(0xff0000);                            
                        }
                        else
                        {
                            this.LoacationU7.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);                            
                        }
                        No7BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();

                    No3warnUp.ImageUrl = "~/pic/normal.png";
                    No4warnUp.ImageUrl = "~/pic/normal.png";
                    No5warnUp.ImageUrl = "~/pic/normal.png";
                    No6warnUp.ImageUrl = "~/pic/normal.png";
                    No7warnUp.ImageUrl = "~/pic/normal.png";
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
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
                            SqlTunnelDisData = "select top(1) location from Tunnel_Info where unitUID = '" + UnitID[j] + "'";
                            read_conn = new SqlConnection(sqlconnection);
                            SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                            read_conn.Open();
                            Power_data = SqlTunnelData.ExecuteReader();
                            while (Power_data.Read())
                            {
                                tcode = Power_data["location"].ToString();

                            }
                            read_conn.Close();
                            if (conFirm[j].ToString() == "1")
                            {
                                switch (tcode)
                                {
                                    case "01":
                                        No1warnDown.ImageUrl = "~/pic/normal.png";
                                        break;
                                    case "02":
                                        No2warnDown.ImageUrl = "~/pic/normal.png";
                                        break;
                                    case "16":
                                        No6warnUp.ImageUrl = "~/pic/normal.png";
                                        break;
                                    case "17":
                                        No7warnUp.ImageUrl = "~/pic/normal.png";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (tcode)
                                {
                                    case "01":
                                        No1warnDown.ImageUrl = "~/pic/warn.png";
                                        break;
                                    case "02":
                                        No1warnDown.ImageUrl = "~/pic/warn.png";
                                        break;
                                    case "16":
                                        No6warnUp.ImageUrl = "~/pic/warn.png";
                                        break;
                                    case "17":
                                        No7warnUp.ImageUrl = "~/pic/warn.png";
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                    }
                    //洞外亮度
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    SqlTunnelDisData = "select top(1) lightlevel from LightLevel where cuid = 'CC6012070168' order by dbtime desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    SqlDataReader Lightness = SqlTunnelData.ExecuteReader();
                    while (Lightness.Read() == true)
                    {
                        ShowOutBrightLeft.ImageUrl = "~/pic/OutBright-" + Lightness["lightlevel"].ToString() + ".png";
                    }
                    read_conn.Close();
                    //车流量
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    SqlTunnelDisData = "select top(1) VDness from lightData where (tunnelCode = '0300000000000') order by dbTime desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int V = Convert.ToInt16(Power_data["VDness"].ToString());
                        TextBoxCar.Text = V.ToString("D4");       // +"辆/小时";

                    }
                    read_conn.Close();
                    //功率和电能表
                    float PP = 0;
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelDisData = "select top(1) ENERGY from AMMETER_CURRENT_DATA where UID = 'CC6012070168' and (CONVERT(varchar(2), DATE_TIME, 108) = 0) and (SUBSTRING(CONVERT(varchar(5), DATE_TIME, 108),4,2) <30)  order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        PP = Convert.ToInt32(Power_data["ENERGY"].ToString());
                    }
                    read_conn.Close();

                    SqlTunnelDisData = "select top(1) ENERGY from AMMETER_CURRENT_DATA where UID = 'CC6012070168' order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        float TP = Convert.ToInt32(Power_data["ENERGY"].ToString());
                        Button_EnergyDay.Text = (TP / 1000).ToString("F2").PadLeft(9, '0') + "度";
                        Button_EnergyH.Text = ((TP - PP) / 1000).ToString("F2") + "度";

                    }
                    read_conn.Close();
                    break;
                case "0200000000000":
                    LedUnitUid = null;
                    //右入左出第一桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '01' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        No1BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();
                    //右入左出第二桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '02' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        No2BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();
                    //右入左出第三桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '03' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        if (Convert.ToInt16(Power_data["ActivePower_A"]) == 0)
                        {
                            this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        }
                        No3BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();
                    //右入左出第四桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '04' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        if (Convert.ToInt16(Power_data["ActivePower_A"]) == 0)
                        {
                            this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        }
                        No4BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();
                    //右入左出第五桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '05' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        No5BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();

                    //右入左出第6桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '06' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        No6BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();

                    //右入左出第7桩灯功率指示
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) unitUID  from Tunnel_Info where (location = '07' and unitState = 'true' and cUID = 'CC6012071120' and tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        LedUnitUid = Led_num["unitUID"].ToString();
                    }
                    read_led.Close();
                    SqlTunnelDisData = "select top(1) ActivePower_A from TERM_INFOBACK where uid = '" + LedUnitUid + "'order by DATE_TIME desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int no = (Convert.ToInt16(Power_data["ActivePower_A"].ToString()) + 9) / 10;
                        No7BrightSecUp.ImageUrl = "~/pic/Bright-" + no.ToString() + ".png";
                    }
                    read_conn.Close();

                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    SqlTunnelDisData = "select top(1) lightlevel from LightLevel where cuid = 'CC6012071120' order by dbtime desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Lightness = SqlTunnelData.ExecuteReader();
                    while (Lightness.Read() == true)
                    {
                        ShowOutBrightRight.ImageUrl = "~/pic/OutBright-" + Lightness["lightlevel"].ToString() + ".png";
                    }
                    read_conn.Close();
                    //车流量
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    SqlTunnelDisData = "select top(1) VDness from lightData where (tunnelCode = '0300000000000') order by dbTime desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        int V = Convert.ToInt16(Power_data["VDness"].ToString());
                        TextBoxCar.Text = V.ToString("D4");       // +"辆/小时";

                    }
                    read_conn.Close();
                    //No1BrightSecUp.ImageUrl = "~/pic/Bright-" + "1" + ".png";
                    //No2BrightSecUp.ImageUrl = "~/pic/Bright-" + "1" + ".png";
                    //No7BrightSecUp.ImageUrl = "~/pic/Bright-" + "1" + ".png";

                    No1warnUp.ImageUrl = "~/pic/normal.png";
                    No2warnUp.ImageUrl = "~/pic/normal.png";
                    No3warnUp.ImageUrl = "~/pic/normal.png";
                    No4warnUp.ImageUrl = "~/pic/normal.png";
                    No5warnUp.ImageUrl = "~/pic/normal.png";
                    No6warnUp.ImageUrl = "~/pic/normal.png";
                    No7warnUp.ImageUrl = "~/pic/normal.png";
                    break;
                case "0300000000000":
                    //丁家坞隧道
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                    SqlTunnelDisData = "select top(1) VInesslevel,VDness,BrightA,BrightB,BrightC,BrightD,BrightE  from lightData where (tunnelCode = '0300000000000') order by dbTime desc";
                    read_conn = new SqlConnection(sqlconnection);
                    SqlTunnelData = new SqlCommand(SqlTunnelDisData, read_conn);
                    read_conn.Open();
                    Power_data = SqlTunnelData.ExecuteReader();
                    while (Power_data.Read() == true)
                    {
                        //右入左出第一桩灯功率指示
                        int A = (Convert.ToInt16(Power_data["BrightA"].ToString()) + 256) * 10 / 4096;
                        if (Convert.ToInt16(Power_data["BrightA"]) == 0)
                        {
                            this.LoacationU1.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU1.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        }
                        No1BrightSecUp.ImageUrl = "~/pic/Bright-" + A.ToString() + ".png";
                        //右入左出第2桩灯功率指示
                        int B = (Convert.ToInt16(Power_data["BrightB"].ToString()) + 256) * 10 / 4096;
                        if (Convert.ToInt16(Power_data["BrightB"]) == 0)
                        {
                            this.LoacationU2.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU2.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        } 
                        No2BrightSecUp.ImageUrl = "~/pic/Bright-" + B.ToString() + ".png";
                        //右入左出第3桩灯功率指示
                        int C = (Convert.ToInt16(Power_data["BrightC"].ToString()) + 256) * 10 / 4096;
                        if (Convert.ToInt16(Power_data["BrightC"]) == 0)
                        {
                            this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        }
                        No3BrightSecUp.ImageUrl = "~/pic/Bright-" + C.ToString() + ".png";
                        //右入左出第4桩灯功率指示
                        int D = (Convert.ToInt16(Power_data["BrightD"].ToString()) + 256)*10 / 4096;
                        if (Convert.ToInt16(Power_data["BrightD"]) == 0)
                        {
                            this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        } 
                        No4BrightSecUp.ImageUrl = "~/pic/Bright-" + D.ToString() + ".png";
                        //右入左出第5桩灯功率指示
                        int E = (Convert.ToInt16(Power_data["BrightE"].ToString()) + 256) * 10 / 4096;
                        if (Convert.ToInt16(Power_data["BrightE"]) == 0)
                        {
                            this.LoacationU5.ForeColor = System.Drawing.Color.FromArgb(0xff0000);
                        }
                        else
                        {
                            this.LoacationU5.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                        } 
                        No5BrightSecUp.ImageUrl = "~/pic/Bright-" + E.ToString() + ".png";
                        //洞外亮度
                        ShowOutBrightRight.ImageUrl = "~/pic/OutBright-" + Power_data["VInesslevel"].ToString() + ".png";
                        int V = Convert.ToInt16(Power_data["VDness"].ToString());
                        TextBoxCar.Text = V.ToString("D4");       // +"辆/小时";
                    
                    }
                    read_conn.Close();
                    
                    No1warnUp.ImageUrl = "~/pic/normal.png";
                    No2warnUp.ImageUrl = "~/pic/normal.png";
                    No3warnUp.ImageUrl = "~/pic/normal.png";
                    No4warnUp.ImageUrl = "~/pic/normal.png";
                    No5warnUp.ImageUrl = "~/pic/normal.png";
                    break;
                   
                default:
                    break;
            }

        }

        public void get_weather()
        {
            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlweathercount = "select count(1) from weather_info where convert(varchar(10),Weather_date,120) = convert(varchar(10),getdate(),120) and Weather_address = (select Tunnel_Weather_Address from Tunnel_Message where Tunnel_Code ='" + Session["suidaocode"].ToString()+"')";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand comm = new SqlCommand(Sqlweathercount, conn);
            conn.Open();
            int num = Convert.ToInt32(comm.ExecuteScalar().ToString());
            conn.Close();
            String Sqlweatheraddress = "select Tunnel_Weather_Address from Tunnel_Message where Tunnel_Code ='" + Session["suidaocode"].ToString() + "'";
            SqlCommand comm2 = new SqlCommand(Sqlweatheraddress, conn);
            conn.Open();
            String weather_address = comm2.ExecuteScalar().ToString();
            conn.Close();
            Session["weather_address"] = weather_address;
            if (num == 0)
            {
                try{
                WeatherWebService.WeatherWebServiceSoapClient getweather = new WeatherWebService.WeatherWebServiceSoapClient();
                string[] weather = getweather.getWeatherbyCityName(weather_address);
                ShowweatherSec.Text = weather[5].ToString();
                string[] weatherpicstrs = weather[8].Split('.');
                string weatherpicstring = "b" + weatherpicstrs[0];
                ShowweatherpicSec.ImageUrl = "~/pic_weather/" + weatherpicstring + ".gif";                   //显示天气图片
                
                String weatherinsert = "insert into weather_info values( '" + weather_address + "','" + weather[5].ToString() + "' ,'" + weatherpicstring + "','',getdate())";
                SqlCommand comm1 = new SqlCommand(weatherinsert, conn);
                conn.Open();
                comm1.ExecuteNonQuery();
                conn.Close();
                }
                catch(Exception e)
                {
                    ShowweatherSec.Text = e.ToString();
                    ShowweatherSec.Text = string.Empty;
                    ShowweatherpicSec.ImageUrl = "~/pic_weather/b.gif";      
                }
            }
            else
            {
                String Sqlweather = "select weather_value from weather_info where convert(varchar(10),weather_date,120) = convert(varchar(10),getdate(),120)and Weather_address = '" + Session["weather_address"].ToString() + "'";
                String Sqlweatherpic = "select weather_picture from weather_info where convert(varchar(10),weather_date,120) = convert(varchar(10),getdate(),120)and Weather_address = '" + Session["weather_address"].ToString() + "'";
                SqlCommand comm4 = new SqlCommand(Sqlweather, conn);
                SqlCommand comm3 = new SqlCommand(Sqlweatherpic, conn);                    
                conn.Open();
                ShowweatherSec.Text = comm4.ExecuteScalar().ToString();
                string weatherpicstring = comm3.ExecuteScalar().ToString();
                ShowweatherpicSec.ImageUrl = "~/pic_weather/" + weatherpicstring + ".gif";                     //显示天气图片
                conn.Close();
            }

        }

        public void get_message()
        {

            //Second_Tunnel_Message.Name = Session["suidaoming"].ToString();
            // string temp_code = Session["suidaocode"].ToString();

            String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
            String Sqlsudiaoinfo = "select Tunnel_Entrance_Name,Tunnel_Exit_Name,Tunnel_Entrance_Label,Tunnel_Exit_Label from Tunnel_Message where Tunnel_Code ='" + Session["suidaocode"].ToString() + "'";
            SqlConnection conn = new SqlConnection(sqlconnection);
            SqlCommand suidaoinfo = new SqlCommand(Sqlsudiaoinfo, conn);
            conn.Open();
            SqlDataReader suidao_info = suidaoinfo.ExecuteReader();
            while (suidao_info.Read() == true)
            {
                ShowTunnelDirLeft.Text = suidao_info["Tunnel_Entrance_Name"].ToString();
                ShowTunnelDirLeft1.Text = suidao_info["Tunnel_Exit_Name"].ToString();
                ShowTunnelDirRight.Text = suidao_info["Tunnel_Exit_Name"].ToString();
                ShowTunnelDirRight1.Text = suidao_info["Tunnel_Entrance_Name"].ToString();
                ShowLocationLeft.Text = suidao_info["Tunnel_Entrance_Label"].ToString();
                ShowLocationRight.Text = suidao_info["Tunnel_Exit_Label"].ToString();
            }
            conn.Close();
            ShowOutBrightRight.ImageUrl = "~/pic/OutBright-.png";
            No7BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            No6BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            No5BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            No4BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            No3BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            No2BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            No1BrightSecUp.ImageUrl = "~/pic/Bright-0.png";
            
            ShowOutBrightLeft.ImageUrl = "~/pic/OutBright-.png";
            No1BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No2BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No3BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No4BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No5BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No6BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No7BrightSecDown.ImageUrl = "~/pic/Bright-0.png";
            No1warnUp.ImageUrl = "~/pic/not.png";
            No2warnUp.ImageUrl = "~/pic/not.png";
            No3warnUp.ImageUrl = "~/pic/not.png";
            No4warnUp.ImageUrl = "~/pic/not.png";
            No5warnUp.ImageUrl = "~/pic/not.png";
            No6warnUp.ImageUrl = "~/pic/not.png";
            No7warnUp.ImageUrl = "~/pic/not.png";
            No1warnDown.ImageUrl = "~/pic/not.png";
            No2warnDown.ImageUrl = "~/pic/not.png";
            No3warnDown.ImageUrl = "~/pic/not.png";
            No4warnDown.ImageUrl = "~/pic/not.png";
            No5warnDown.ImageUrl = "~/pic/not.png";
            No6warnDown.ImageUrl = "~/pic/not.png";
            No7warnDown.ImageUrl = "~/pic/not.png";
                
        }

        protected void warnup_Click(object sender, EventArgs e)
        {

            string id = ((ImageButton)sender).ClientID.ToString();
            switch (id)
            {
                case "No1warnUp":
                    Session["Warm"] = "11";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No2warnUp":
                    Session["Warm"] = "12";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No3warnUp":
                    Session["Warm"] = "13";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No4warnUp":
                    Session["Warm"] = "14";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No5warnUp":
                    Session["Warm"] = "15";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No6warnUp":
                    Session["Warm"] = "16";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No7warnUp":
                    Session["Warm"] = "17";
                    Response.Redirect("Page28.aspx");
                    break;
                default:
                    break;
            }

        }

        protected void warndown_Click(object sender, EventArgs e)
        {

            string id = ((ImageButton)sender).ClientID.ToString();
            switch (id)
            {
                case "No1warnDown":
                    Session["Warm"] = "01";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No2warnDown":
                    Session["Warm"] = "02";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No3warnDown":
                    Session["Warm"] = "03";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No4warnDown":
                    Session["Warm"] = "04";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No5warnDown":
                    Session["Warm"] = "05";
                    Response.Redirect("Page28.aspx");
                    break;
                case "No6warnDown":
                    Session["Warm"] = "06";
                    Response.Redirect("Page28.aspx");;
                    break;
                case "No7warnDown":
                    Session["Warm"] = "07";
                    Response.Redirect("Page28.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void Button_Left_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Come from Button Left";
            Response.Redirect("Page27.aspx");
        }

        protected void Button_Right_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Come from Button Right";
            Response.Redirect("Page27.aspx");
        }

        protected void Button_Car_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Come from Button Car";
            Response.Redirect("Page29.aspx");
        }

        protected void Systemset_Click(object sender, EventArgs e)
        {
            if ((Session["emp_Limited"].ToString() == "11") | (Session["emp_Limited"].ToString() == "22"))
            {
                //Response.Redirect("122.225.60.90:81");
                string target = "http://www.lanmeng.org/";
                target = "http://122.225.60.90:81";
                //target = "http://www.baidu.com";
                //System.Diagnostics.Process.Start(target);
                Response.Redirect(target);
            }
            else
            {
                Session["ScriptN"] = "Systemset_Click";
                Response.Redirect("ScriptNote.aspx");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>style='font-size:40px; width:390px;float:right';alert('对不起，你没有修改系统权限！');location='Secondpage.aspx'  </script>", false);               
            }
            
        }

        protected void Emergency_Click(object sender, EventArgs e)
        {
            switch (Session["suidaocode"].ToString())
            {
                case "0100000000000":
                    String ControlUid = null;
                    //昱岭关集控器UID
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    String SqlTunnelLedData = "select top(1) cUID  from Tunnel_Info where (tunnelCode = '0100000000000') order by id desc";
                    SqlConnection read_led = new SqlConnection(sqlconnection);
                    SqlCommand SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    SqlDataReader Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        ControlUid = Led_num["cUID"].ToString();
                    }
                    read_led.Close();
                    if (ControlUid != null)
                    {

                        String Sqlempinfosert = "insert into operateState values('1','" + Session["emp_Oper_No"].ToString() + "', '" + DateTime.Now.ToString() + "','',' ','0100000000000' ,'昱岭关','" + ControlUid + "')";
                        SqlConnection conn = new SqlConnection(sqlconnection);
                        SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                        conn.Open();
                        if (comminsert.ExecuteNonQuery() != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('应急操作成功')</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('应急操作失败')</script>", false);
                        }
                        conn.Close();
                    }
           
                
                    break;
                case "0200000000000":
                    ControlUid = null;
                    //兔子岭集控器UID
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) cUID  from Tunnel_Info where (tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        ControlUid = Led_num["cUID"].ToString();
                    }
                    read_led.Close();
                    if (ControlUid != null)
                    {

                        String Sqlempinfosert = "insert into operateState values('1','" + Session["emp_Oper_No"].ToString() + "', '" + DateTime.Now.ToString() + "','',' ','0200000000000' ,'兔子岭','" + ControlUid + "')";
                        SqlConnection conn = new SqlConnection(sqlconnection);
                        SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                        conn.Open();
                        if (comminsert.ExecuteNonQuery() != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('应急操作成功')</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('应急操作失败')</script>", false);
                        }
                        conn.Close();
                    }
           
                    break;
                case "0300000000000":
                    break;
                default:
                    break;
            }
        }

        protected void Recover_Click(object sender, EventArgs e)
        {
            switch (Session["suidaocode"].ToString())
            {
                case "0100000000000":
                    String ControlUid = null;
                    //昱岭关集控器UID
                    String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    String SqlTunnelLedData = "select top(1) cUID  from Tunnel_Info where (tunnelCode = '0100000000000') order by id desc";
                    SqlConnection read_led = new SqlConnection(sqlconnection);
                    SqlCommand SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    SqlDataReader Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        ControlUid = Led_num["cUID"].ToString();
                    }
                    read_led.Close();
                    if (ControlUid != null)
                    {

                        String Sqlempinfosert = "insert into operateState values('0','" + Session["emp_Oper_No"].ToString() + "', '" + DateTime.Now.ToString() + "','',' ','0100000000000' ,'昱岭关','" + ControlUid + "')";
                        SqlConnection conn = new SqlConnection(sqlconnection);
                        SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                        conn.Open();
                        if (comminsert.ExecuteNonQuery() != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('恢复操作成功')</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('恢复操作失败')</script>", false);
                        }
                        conn.Close();
                    }


                    break;
                case "0200000000000":
                    ControlUid = null;
                    //兔子岭集控器UID
                    sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString4"].ToString();
                    SqlTunnelLedData = "select top(1) cUID  from Tunnel_Info where (tunnelCode = '0200000000000') order by id desc";
                    read_led = new SqlConnection(sqlconnection);
                    SqlLedData = new SqlCommand(SqlTunnelLedData, read_led);
                    read_led.Open();
                    Led_num = SqlLedData.ExecuteReader();
                    if (Led_num.Read() == true)
                    {
                        ControlUid = Led_num["cUID"].ToString();
                    }
                    read_led.Close();
                    if (ControlUid != null)
                    {

                        String Sqlempinfosert = "insert into operateState values('0','" + Session["emp_Oper_No"].ToString() + "', '" + DateTime.Now.ToString() + "','',' ','0200000000000' ,'兔子岭','" + ControlUid + "')";
                        SqlConnection conn = new SqlConnection(sqlconnection);
                        SqlCommand comminsert = new SqlCommand(Sqlempinfosert, conn);
                        conn.Open();
                        if (comminsert.ExecuteNonQuery() != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('恢复操作成功')</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('恢复操作失败')</script>", false);
                        }
                        conn.Close();
                    }

                    break;
                case "0300000000000":
                    break;
                default:
                    break;
            }
        }

        protected void Dayview_Click(object sender, EventArgs e)
        {
            Session["Joglog"] = "Into Page24";
            Response.Redirect("Page24.aspx");
        }

        protected void Moonview_Click(object sender, EventArgs e)
        {
            Session["Joglog"] = "Into Page25";
            Response.Redirect("Page25.aspx");
        }

        protected void Inspect_Click(object sender, EventArgs e)
        {
            if (Session["IntoCode"].ToString() == "Come from Inspect")
            {
                getsuidaoming();
                if ((Convert.ToInt16(Session["i"]) == 8)|(suidaoread[Convert.ToInt16(Session["i"]), 0].ToString()==""))
                {
                    Session["i"] = 0;
                }
                else
                {
                    Session["i"] = (Convert.ToInt16(Session["i"]) + 1).ToString();
                }
                if (suidaoread[Convert.ToInt16(Session["i"]), 0].ToString() == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('所选隧道数据未建！');location='firstpage.aspx'</script>", false);
                }
                else
                {
                    Button_EnergyH.Text = "00.00度";
                    Button_EnergyDay.Text = "000000.00";
                    this.LoacationU7.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    this.LoacationU6.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    this.LoacationU5.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    this.LoacationU4.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    this.LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    this.LoacationU2.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    this.LoacationU1.ForeColor = System.Drawing.Color.FromArgb(0xffffff);
                    
                    Session["suidaoming"] = suidaoread[Convert.ToInt16(Session["i"]), 0].ToString(); ;
                    Session["suidaocode"] = suidaoread[Convert.ToInt16(Session["i"]), 1].ToString();
                    Page.Title = Session["suidaoming"].ToString() + "隧道照明监控系统";
                    LabelSec_Title.Text = Session["suidaoming"].ToString() + "隧道监控系统";
                    ShowtimeSec.Text = DateTime.Now.ToString();
                    get_weather();
                    get_message();
                    switch (Session["suidaocode"].ToString())
                    {
                        case "0100000000000":
                            //LoacationU3.ForeColor = System.Drawing.Color.FromArgb(0x00ff00);
                            LoacationU7.Text = "右加强";
                            LoacationU6.Text = "右基照明";
                            LoacationU5.Text = "左基照明";
                            LoacationU4.Text = "左加强";
                            LoacationU3.Text = "两侧加强";
                            LoacationU2.Text = "";
                            LoacationU1.Text = "";
                            No3warnUp.Enabled = true;
                            No4warnUp.Enabled = true;
                            No5warnUp.Enabled = true;
                            No6warnUp.Enabled = true;
                            No7warnUp.Enabled = true;
                            break;
                        case "0200000000000":
                            LoacationU7.Text = "左出加强";
                            LoacationU6.Text = "左过加强";
                            LoacationU5.Text = "左基照明";
                            LoacationU4.Text = "右基照明";
                            LoacationU3.Text = "两侧加强";
                            LoacationU2.Text = "右加强";
                            LoacationU1.Text = "左入加强";
                            No1warnUp.Enabled = true;
                            No2warnUp.Enabled = true;
                            No3warnUp.Enabled = true;
                            No4warnUp.Enabled = true;
                            No5warnUp.Enabled = true;
                            No6warnUp.Enabled = true;
                            No7warnUp.Enabled = true;
                            break;
                        case "0300000000000":
                            LoacationU7.Text = "";
                            LoacationU6.Text = "";
                            LoacationU5.Text = "右侧基本";
                            LoacationU4.Text = "左加强双";
                            LoacationU3.Text = "左加强单";
                            LoacationU2.Text = "右加强双";
                            LoacationU1.Text = "右加强单";
                            No1warnUp.Enabled = true;
                            No2warnUp.Enabled = true;
                            No3warnUp.Enabled = true;
                            No4warnUp.Enabled = true;
                            No5warnUp.Enabled = true;

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void EnergyH_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Come from Button EnergyH";
            Response.Redirect("Energy.aspx");
        }

        protected void EnergyDay_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Come from Button EnergyDay";
            Response.Redirect("EnergyDay.aspx");
        }
        
        protected void ButtonSec_Exit_Click(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Welcome Into Firstpage";
            //Session.Contents.Remove("suidaocode");
            //Session.Contents.Remove("suidaoming");
            Response.Redirect("firstpage.aspx");
        }

        protected void SecScreen_Click(object sender, EventArgs e)
        {
           

        }
    }
}
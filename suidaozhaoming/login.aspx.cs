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
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IntoCode"] != null)
            {
                switch (Session["IntoCode"].ToString())
                {
                    case  "Come from Register_1":
                        TextBoxEmp_No.Text = Session["emp_Oper_No"].ToString();
                        Session.Contents.Remove("emp_Oper_No");
                        Session.Contents.Remove("IntoCode");
                        break;
                    case "Come from Registerpage":
                        Session.Contents.Remove("IntoCode");
                        break;
                    default:
                        break;
                }
                //if ((Session["IntoCode"].ToString() == "Come from Register_1"))
                //{
                //    TextBoxEmp_No.Text = Session["emp_Oper_No"].ToString();
                //    Session.Contents.Remove("emp_Oper_No");
                //    Session.Contents.Remove("IntoCode");
                //}
                //if(Session["IntoCode"].ToString() == "Come from Registerpage")
                //{
                //    Session.Contents.Remove("IntoCode");
                //}
            }
        }

        protected void ButtonOKdetail(object sender, EventArgs e)
        {
            
            string emp_LoginKey = string.Empty;
            bool temp = true;
            if (TextBoxEmp_No.Text != "")
            {
                String sqlconnection = ConfigurationManager.ConnectionStrings["suidaozhaomingConnectionString3"].ToString();
                String Sqlsudiaoinfo = "select emp_Key ,emp_Limited,emp_Name from employee_info where emp_No ='" + TextBoxEmp_No.Text + "'";
                SqlConnection conn = new SqlConnection(sqlconnection);
                SqlCommand suidaoinfo = new SqlCommand(Sqlsudiaoinfo, conn);
                conn.Open();
                SqlDataReader suidao_info = suidaoinfo.ExecuteReader();

                if (suidao_info.Read())
                {
                    emp_LoginKey = suidao_info["emp_Key"].ToString();
                    Session["emp_Limited"] = suidao_info["emp_Limited"].ToString();
                    Session["emp_Oper_No"] = TextBoxEmp_No.Text.ToString();
                    Session["emp_Oper"] = suidao_info["emp_Name"].ToString();
                    temp = false;
                }
                
                conn.Close();
            }
            
            if (temp)               //用户账户不存在
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('管理员不存在！');location='login.aspx'</script>", false);
                Session["IntoCode"] = "Welcome Into Registerpage";
                //Session["Emp_No"] = TextBoxEmp_No.Text.ToString();
                Response.Redirect("RegisterPage.aspx");
            }
            else
            {
                if (TextBoxKey.Text == emp_LoginKey)
                {
                    Session["IntoCode"] = "Welcome Into Firstpage";
                    //Session["Emp_No"] = TextBoxEmp_No.Text.ToString();
                    Response.Redirect("firstpage.aspx");
                }
                else                                                           //密码错误
                {
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "<script>alert('密码错误！');location='login.aspx'</script>", false);
                    Session["IntoCode"] = "Come from login";
                    //Session["Emp_No"] = TextBoxEmp_No.Text.ToString();
                    Response.Redirect("Register_1.aspx");

                }
            }
        }
    }
}
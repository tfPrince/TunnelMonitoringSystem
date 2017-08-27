using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suidaozhaoming
{
    public partial class Register_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // if (Session["IntoCode"] != null)
               // {
                if (Session["IntoCode"].ToString() == "Come from Registerpage")
                {
                    TextBox1.Text = "欢迎光临！";
                    TextBox2.Text = "请获取账号和密码后再进入";
                    //Session.Contents.Remove("IntoCode");
                }
                else
                {
                    if (Session["IntoCode"].ToString() == "Come from login")
                    {
                        TextBox1.Text = "密码错误！";
                        TextBox2.Text = "请重新输入准确密码";
                        //Session["Emp_No_New"] = Session["Emp_No"].ToString();
                        //Session.Contents.Remove("Emp_No");
                        //Session.Contents.Remove("IntoCode");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>window.close()</script>");
                    }
                    
                }

                //}
            }
        }
        protected void ButtonOK(object sender, EventArgs e)
        {
            if (Session["IntoCode"].ToString() == "Come from login")
            {
                //Session["Emp_No"] = Session["Emp_No_New"].ToString();
                Session["IntoCode"] = "Come from Register_1";
                Response.Redirect("login.aspx");
            }
            if (Session["IntoCode"].ToString() == "Come from Registerpage")
            {
                Session.Contents.Remove("Emp_No");
                Session.Contents.Remove("IntoCode");
                Response.Write("<script type=\"text/javascript\">window.opener = null;window.open('', '_self');window.close();</script>");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suidaozhaoming
{
    public partial class Registerpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

                if (Session["IntoCode"].ToString() == "Welcome Into Registerpage")
                {
                    //Session["Emp_No_New"] = Session["Emp_No"].ToString();
                    //Session.Contents.Remove("Emp_No");
                    Session.Contents.Remove("IntoCode");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>window.close()</script>");
                }
                
            }
        }

        protected void ButtonRegister(object sender, EventArgs e)
        {
            Session["IntoCode"] = "Come from Registerpage";
            Session.Contents.Remove("Emp_No");
            Response.Redirect("Register_1.aspx");
        }

        protected void ButtonReturn(object sender, EventArgs e)
        {
            //Session["Emp_No"] = Session["Emp_No_New"].ToString();
            Session["IntoCode"] = "Come from Registerpage";
            Response.Redirect("login.aspx");
        }
    }
}
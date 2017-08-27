using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suidaozhaoming
{
    public partial class Page121 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IntoPage121Code"].ToString() == "SH-LIGHT")
            {
            }
            else
            {
                if (Session["IntoPage121Code"].ToString() == "KEY_WRONG")
                {
                    Session["IntoPage121Code"] = "Cancel";
                    Response.Redirect("Page12.aspx");
                }
            }

        }
        protected void Confirm_Click(object sender, EventArgs e)
        {

            Session["IntoPage121Code"] = "Confirm";
            Response.Redirect("Page12.aspx");
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {

            Session["IntoPage121Code"] = "Cancel";
            Response.Redirect("Page12.aspx");
        }
    }
}
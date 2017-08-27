using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suidaozhaoming
{
    public partial class Page160 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GetTimer(object sender, EventArgs e)
        {

            showtimePage16.Text = DateTime.Now.ToString();

        }
        protected void ButtonP160_Exit_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("Joglog");
            Response.Redirect("firstpage.aspx");
        }

        protected void First_Click(object sender, EventArgs e)
        {
            Session["Joglog"] = "Into Page16"; 
            Response.Redirect("Page16.aspx");
        }

        protected void Second_Click(object sender, EventArgs e)
        {
            Session["Joglog"] = "Into Page161";
            Response.Redirect("Page161.aspx");
        }
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApp
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Verified"] == null)
            {
                Response.Redirect("/Connect.aspx");
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string commandText = "SELECT * FROM books WHERE Author LIKE '" + tbAuthor.Text + "' OR Title LIKE '" + tbTitle.Text + "' OR Format LIKE '" + tbFormat.Text + "' OR Release_date LIKE '" + tbRelease.Text + "' OR Description LIKE '" + tbDescription.Text + "' OR Pages LIKE '" + tbPages.Text + "' OR ISBN LIKE '" + tbISBN.Text + "';";
            Session["searchOption"] = commandText;
            Response.Redirect("/View.aspx");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View.aspx");
        }

        protected void btSearchAnd_Click(object sender, EventArgs e)
        {
            string commandText = "SELECT * FROM books WHERE Author LIKE '" + tbAuthor.Text + "' AND Title LIKE '" + tbTitle.Text + "' AND Format LIKE '" + tbFormat.Text + "' AND Release_date LIKE '" + tbRelease.Text + "' AND Description LIKE '" + tbDescription.Text + "' AND Pages LIKE '" + tbPages.Text + "' AND ISBN LIKE '" + tbISBN.Text + "';";
            Session["searchOption"] = commandText;
            Response.Redirect("/View.aspx");
        }
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApp
{
    public partial class Connect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private MySqlConnection connect()
        {
            string myConnection = "Server=" + tbServer.Text +
                                  ";Database=" + tbDatabase.Text +
                                  ";User=" + tbUser.Text +
                                  ";Password=" + tbPassword.Text +
                                  ";";
            Session["connection"] = myConnection;
            MySqlConnection connection = new MySqlConnection(myConnection);
            try
            {
                connection.Open();
                lbStatus.Text = "Connected";
                return connection;
            }
            catch (MySqlException ex)
            {
                lbStatus.Text = ex.Message;
            }

            return null;
        }

        protected void btConnect_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = connect();
            if(connection != null)
            {
                Session["Verified"] = true;
                Response.Redirect("/login.aspx");
            }
        }
    }
}
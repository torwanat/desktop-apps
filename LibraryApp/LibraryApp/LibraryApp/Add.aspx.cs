using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApp
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Verified"] == null)
            {
                Response.Redirect("/Connect.aspx");
            }
        }

        private MySqlConnection connect()
        {
            string myConnection = Session["connection"].ToString();
            MySqlConnection connection = new MySqlConnection(myConnection);
            try
            {
                connection.Open();
                lbStatus.Text = "Connected";
                return connection;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                lbStatus.Text = ex.Message;
            }

            return null;
        }

        protected void btConnect_Click(object sender, EventArgs e)
        {
            if(tbAuthor.Text == "" || tbDescription.Text == "" || tbFormat.Text == "" || tbISBN.Text == "" || tbPages.Text == "" || tbRelease.Text == "" || tbTitle.Text == "")
            {
                lbStatus.Text = "Proszę wypełnić wszystkie pola!";
                return;
            }

            Regex validateDateRegex = new Regex("^[0-9]{1,2}\\.[0-9]{1,2}\\.[0-9]{4}$");
            Regex validateNumber = new Regex("^\\d+$");
            if (!validateDateRegex.IsMatch(tbRelease.Text) || !validateNumber.IsMatch(tbISBN.Text) || !validateNumber.IsMatch(tbPages.Text))
            {
                lbStatus.Text = "Błedny format!";
                return;
            }

            MySqlConnection conn = connect();
            if(conn == null)
            {
                return;
            }

            MySqlCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = "INSERT INTO `books`(`Author`, `Title`, `Release_date`, `ISBN`, `Format`, `Pages`, `Description`) VALUES ('" + tbAuthor.Text + "','" + tbTitle.Text + "','" + tbRelease.Text + "','" + tbISBN.Text + "','" + tbFormat.Text + "','" + tbPages.Text + "','" + tbDescription.Text + "')";
                command.ExecuteNonQuery();
                Session["searchOption"] = "SELECT * FROM books";
                Response.Redirect("/View.aspx");
            }
            catch (MySqlException ex)
            {
                lbStatus.Text = ex.Message;
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View.aspx");
        }
    }
}
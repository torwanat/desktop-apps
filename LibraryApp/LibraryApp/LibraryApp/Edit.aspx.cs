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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Verified"] == null)
            {
                Response.Redirect("/Connect.aspx");
            }
            if (!IsPostBack)
            {
                string id = (string)Session["currentId"];
                MySqlConnection conn = connect();
                if (conn == null)
                {
                    lbStatus.Text = "Wystąpił błąd podczas edytowania rekordu";
                    return;
                }
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM books WHERE id='" + id + "';";
                MySqlDataReader reader = command.ExecuteReader();

                string title, author, format, description, isbn, release;
                int pages;

                while (reader.Read())
                {
                    title = reader.GetString("Title");
                    author = reader.GetString("Author");
                    release = reader.GetString("Release_date");
                    isbn = reader.GetString("ISBN");
                    format = reader.GetString("format");
                    pages = (int)reader.GetInt32("Pages");
                    description = reader.GetString("description");

                    tbTitle.Text = title;
                    tbAuthor.Text = author;
                    tbRelease.Text = release;
                    tbISBN.Text = isbn;
                    tbFormat.Text = format;
                    tbPages.Text = pages.ToString();
                    tbDescription.Text = description;
                    break;
                }
            }


        }

        private MySqlConnection connect()
        {
            string myConnection = (string)Session["connection"];
            MySqlConnection connection = new MySqlConnection(myConnection);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            if (tbAuthor.Text == "" || tbDescription.Text == "" || tbFormat.Text == "" || tbISBN.Text == "" || tbPages.Text == "" || tbRelease.Text == "" || tbTitle.Text == "")
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
            if (conn == null)
            {
                return;
            }

            MySqlCommand command = conn.CreateCommand();
            try
            {
                string id = (string)Session["currentId"];
                command.CommandText = "UPDATE books SET Author = '" + tbAuthor.Text + "', Description = '" + tbDescription.Text + "', Format = '" + tbFormat.Text + "', ISBN = '" + tbISBN.Text + "', Pages= '" + tbPages.Text + "', Release_date = '" + tbRelease.Text + "', Title = '" + tbTitle.Text + "' WHERE Id = " + id + ";";
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
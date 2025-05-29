using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApp
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Verified"] == null)
            {
                Response.Redirect("/Connect.aspx");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns["Id"].ColumnName = "ID";
            dt.Columns.Add("Title", typeof(string));
            dt.Columns["Title"].ColumnName = "Title";
            dt.Columns.Add("Author", typeof(string));
            dt.Columns["Author"].ColumnName = "Author";
            dt.Columns.Add("Release date", typeof(string));
            dt.Columns["Release date"].ColumnName = "Release date";
            dt.Columns.Add("ISBN", typeof(string));
            dt.Columns["ISBN"].ColumnName = "ISBN";
            dt.Columns.Add("Format", typeof(string));
            dt.Columns["Format"].ColumnName = "Format";
            dt.Columns.Add("Pages", typeof(int));
            dt.Columns["Pages"].ColumnName = "Pages";
            dt.Columns.Add("Description", typeof(string));
            dt.Columns["Description"].ColumnName = "Description";

            MySqlConnection connection = connect();
            if(connection == null)
            {
                lbInfo.Text = "Wystapił błąd bazy danych!";
                return;
            }
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = (string)Session["searchOption"];

            MySqlDataReader reader = command.ExecuteReader();
            string title, author, format, description, isbn, release;
            int id, pages;

            while (reader.Read())
            {
                id = reader.GetInt32("Id");
                title = reader.GetString("Title");
                author = reader.GetString("Author");
                release =reader.GetString("Release_date");
                isbn = reader.GetString("ISBN");
                format = reader.GetString("format");
                pages = (int)reader.GetInt32("Pages");
                description = reader.GetString("description");

                DataRow row = dt.NewRow();
                row["Id"] = id;
                row["Title"] = title;
                row["Author"] = author;
                row["Release date"] = release;
                row["ISBN"] = isbn;
                row["Format"] = format;
                row["Pages"] = pages;
                row["Description"] = description;
                dt.Rows.Add(row);
            }

            gvBooks.DataSource = dt;
            gvBooks.DataBind();
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

        protected void btAddBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Add.aspx");
        }

        protected void deleteBook(object sender, CommandEventArgs e)
        {
            // e.CommandName e.CommandArgument
            string id = e.CommandArgument.ToString();
            lbInfo.Text = id;
            MySqlConnection conn = connect();
            if (conn == null)
            {
                lbInfo.Text = "Wystąpił błąd podczas usuwania rekordu";
                return;
            }
            MySqlCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = "DELETE FROM books WHERE Id='" + id + "';";
                command.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
            catch (MySqlException ex)
            {
                lbInfo.Text = ex.Message;
            }
        }

        protected void editBook(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Session["currentId"] = id;
            Response.Redirect("/Edit.aspx");
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Search.aspx");
        }

        protected void btShowAll_Click(object sender, EventArgs e)
        {
            Session["searchOption"] = "SELECT * FROM books";
            Response.Redirect(Request.RawUrl);
        }

        protected void btLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/login.aspx");
        }
    }
}
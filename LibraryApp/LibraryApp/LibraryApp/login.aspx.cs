using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApp
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Verified"] == null)
            {
                Response.Redirect("/Connect.aspx");
            }
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/register.aspx");
            /*if(tbLogin.Text == "" || tbLogin.Text == "" || tbEmail.Text == "")
            {
                lbInfo.Text = "Proszę wypełnić wszystkie pola!";
                return;
            }
            MySqlConnection conn = connect();
            if (conn == null)
            {
                lbInfo.Text = "Wystąpił błąd podczas rejestracji";
                return;
            }
            MySqlCommand command = conn.CreateCommand();
            string password = hash(tbPassword.Text);
            try
            {
                command.CommandText = "INSERT INTO users (Login, Password, Email) VALUES('" + tbLogin.Text + "','" + password + "','" + tbEmail.Text + "');";
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.ErrorCode.ToString() == "-2147467259")
                {
                    lbInfo.Text = "Konto o takim emailu już istnieje!";
                }
                else
                {
                    lbInfo.Text = ex.Message;
                }
            }
            Response.Redirect(Request.RawUrl);*/
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            if(tbLogin.Text == "" || tbPassword.Text == "")
            {
                lbInfo.Text = "Proszę wypełnić wszystkie pola!";
                return;
            }
            MySqlConnection conn = connect();
            if(conn == null)
            {
                lbInfo.Text = "Wystąpił błąd podczas logowania!";
                return;
            }
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM users";

            MySqlDataReader reader = command.ExecuteReader();
            string login, password;

            while (reader.Read())
            {
                login = reader.GetString("Login");
                password = reader.GetString("Password");
                if(login == tbLogin.Text)
                {
                    if(deHash(tbPassword.Text, password))
                    {
                        Session["searchOption"] = "SELECT * FROM books";
                        Response.Redirect("/View.aspx");
                    }
                    else
                    {
                        lbInfo.Text = "Błędne hasło!";
                        return;
                    }
                }
            }
            lbInfo.Text = "Błędny login lub email!";
        }

        private bool deHash(string enteredPassword, string savedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }

        private string hash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
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
    }
}
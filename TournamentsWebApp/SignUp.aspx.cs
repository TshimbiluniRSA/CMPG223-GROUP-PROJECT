using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PC_Exclusive
{
    public partial class SignUp : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(conStr);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                command = new SqlCommand($"INSERT INTO  PlayersInfo(FirstName, LastName, Username, Password, Email) VALUES ('{TextBox1.Text}',{TextBox6.Text}','{TextBox5.Text}', '{TextBox2.Text}', '{TextBox3.Text}')", connection);
                adapter.InsertCommand = command;

                connection.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException error)
            {
                Label7.Text = error.Message;
            }

            Response.Redirect("HomePage.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);

            connection.Open();
            connection.Close();

            Label8.Text = "Connected Successfully";
        }
    }
}


 
    
 
 
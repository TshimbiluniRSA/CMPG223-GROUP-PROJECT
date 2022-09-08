using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PC_ExclusiveLogIn
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\Downloads\CMPG-213_223-Project\CMPG-213_223-Project\Database\TournamentsDB\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader reader;

        int currID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Id"] != null)
                {
                    currID = (int)Session["Id"];
                }
				else
				{
                    Response.Redirect("HompPage.aspx");
				}

                string OldPassword = TextBox1.Text;
                string NewPassword = TextBox2.Text;
                string ConfirmP = TextBox3.Text;
                connection = new SqlConnection(connectionStr);
                connection.Open();
                cmd = new SqlCommand("SELECT * FROM PlayersInfo WHERE Id=@cid", connection);
                cmd.Parameters.AddWithValue("@cid", currID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    reader.Read();
                    connection.Close();
                    if (NewPassword == ConfirmP)
                    {
                        connection.Open();
                        cmd = new SqlCommand("Update PlayersData set Password='" + NewPassword + "'WHERE Password='" + OldPassword + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        Label2.Text = "Password has been successfully changed";
                    }
                    else
                        Label2.Text = "Confirm password doesn't match with the new password";
                }
                else
                    Label2.Text = "Incorrect password, Enter a correct password";
            }
            catch (Exception ex)
            {
                Label2.Text = "Error " + ex.Message.ToString();
            }
        }

		protected void Button1_Click(object sender, EventArgs e)
		{
            Response.Redirect("ForgotPassword.aspx");    
		}
	}
}
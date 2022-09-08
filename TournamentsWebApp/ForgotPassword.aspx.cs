using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace PC_ExclusiveLogIn
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        string connectStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\Downloads\CMPG-213_223-Project\CMPG-213_223-Project\Database\TournamentsDB\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection;
        SqlDataReader reader;
        NetworkCredential credential;
       // SmtpClient stmp;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectStr);
            string getPass = "SELECT Password,Email FROM PlayersInfo WHERE Email =@Email";
            cmd = new SqlCommand(getPass, connection);
            cmd.Parameters.AddWithValue("@Email", TextBox1.Text);
            connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string Email = reader["Email"].ToString();
                string Password = reader["Password"].ToString();

                MailMessage mail = new MailMessage("xitsundzuxoalethea80@gmail.com", TextBox1.Text);
                mail.Subject = "Your Password!";
                mail.Body = string.Format("Hello " + Email + " your password is: " + Password);
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                credential = new NetworkCredential(Email, Password);
               // credential.UserName = "xitsundzuxoalethea@gmail.com";
               // credential.Password = "Ale0102";
                smtp.Credentials = credential;
                smtp.Send(mail);
                Label2.Text = "Your password has been sent to " + TextBox1.Text;
                Label2.ForeColor = Color.Green;
            }
            else
            {
                Label2.Text = "This email does not exist, in our database!!";
                Label2.ForeColor = Color.Red;
            }
        }
    }
}
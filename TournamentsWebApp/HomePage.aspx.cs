/* Group members
 *  - Alethea (32788444)
 *  - Aaryadev Ghosalkar (35553367)
 *  - Alwyn bernard (32033303)
 *  - Layton Wylbacht (32043996)
 */

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
    public partial class HomePage : System.Web.UI.Page
    {

        HttpCookie cookie = new HttpCookie("PlayersInfo");


        SqlConnection con;
        SqlDataReader dRead;
        SqlCommand comm;
        string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
        public int CheckInfo(string Username, string Password)
        {
            con = new SqlConnection(connectionStr);
            con.Open();
            string open_ = @"SELECT * FROM PlayersInfo";
            comm = new SqlCommand(open_, con);
            dRead = comm.ExecuteReader();
            while (dRead.Read())
            {
                string tmpName = dRead.GetValue(4).ToString();
                string tmpPass = dRead.GetValue(5).ToString();
                if (tmpName == Username && tmpPass == Password)
                {
                    Session["Id"] = dRead.GetInt32(0);
                    return 1;
                }
                else if (tmpName != Username && tmpPass == Password)
                    Label5.Text = "Incorrect Username.";
                else
                    Label6.Text = "Incorrect password.";
            }
            con.Close();
            return 0;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            if (CheckInfo(username, password) == 1)
            {
                Response.Redirect("HPplayers.aspx");
            }
            else
            {
				if (checkEmployee(username, password))
				{
                    Response.Redirect("HPemployee.aspx");
				}
				else
				{
                    Response.Redirect("SignUp.aspx");//Should redirect to Player Home page not signup;
                }
            }
               
        }

        private bool checkEmployee(string uname, string password)
		{
            con = new SqlConnection(connectionStr);
            con.Open();
            string open_ = @"SELECT Id, Username, Password FROM EmployeesInfo";
            comm = new SqlCommand(open_, con);
            dRead = comm.ExecuteReader();
			while (dRead.Read())
			{
                string currUname = dRead.GetString(1);
                string currentPassword = dRead.GetString(2);

				if (uname == currUname && password == currentPassword)
				{
                    Session["Id"] = dRead.GetInt32(0);
                    return true;
				}
			}
            con.Close();
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie request = Request.Cookies["PlayersInfo"];
            if (!IsPostBack)
            {
                if (request != null)
                    TextBox1.Text = request["Username"].ToString();
            }

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
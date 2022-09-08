using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Group_14_Project
{
    public partial class HPemployee : System.Web.UI.Page
    {
        public SqlConnection conn;
        public SqlCommand comm;
        public DataSet ds;
        public SqlDataAdapter adap;
        public string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\Downloads\CMPG-213_223-Project\CMPG-213_223-Project\Database\TournamentsDB\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(constr);
            string sql_Matches = "SELECT * FROM MatchInfo";
            string sql_EName = "SELECT FirstName, LastName FROM EmployeeInfo WHERE Username Like '%AG%'";
            string sql_EId = "SELECT Id FROM EmployeeInfo";
            conn.Open();

            //Tournaments
            ds = new DataSet();
            adap = new SqlDataAdapter();

            comm = new SqlCommand(sql_Matches, conn);
            adap.SelectCommand = comm;
            adap.Fill(ds);

           // gdvTeamScores.DataSource = ds;
          //  gdvTeamScores.DataBind();

            //Employee
          //  lblEmpName.Text = "Welcome " + sql_EName;
          //  lblEmpID.Text = "Team ID: " + sql_EId;
            
            conn.Close();
        }

        protected void btnPScores_Click(object sender, EventArgs e)
        {
            Response.Redirect(".aspx");
        }

        protected void btnAddT_Click(object sender, EventArgs e)
        {
            Response.Redirect("createTournament.aspx");
        }

        protected void btnPTeams_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateTeam.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

		protected void Button1_Click(object sender, EventArgs e)
		{
            Response.Redirect("createReport.aspx");
		}

        protected void gdvTeamScores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addDeleteGame.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("addDeletePlatform.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("addDeleteVenue.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("deleteTournament.aspx");
        }
    }
}
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
    public partial class Default : System.Web.UI.Page
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
            string sql_User = "SELECT Username FROM PlayerInfo";
            string sql_Team = "SELECT Team_ID FROM PlayerInfo";
            string sql_PId = "SELECT Id From PlayerInfo";
            string sql_LastT = "SELECT LastEnterenceDate FROM Tounament";

            conn.Open();
            
            //Matches
            ds = new DataSet();
            adap = new SqlDataAdapter();

            comm = new SqlCommand(sql_Matches, conn);
            adap.SelectCommand = comm;
            adap.Fill(ds);

          //  gdvMatches.DataSource = ds;
          //  gdvMatches.DataBind();

            //Player
        //    lblWelcome.Text = "Welcome" + sql_User;
         //   lblTeam.Text = "Team ID: " + sql_Team;
         //   lblID.Text = sql_PId;
         //   lblLast.Text = sql_LastT;
            conn.Close();
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            Response.Redirect("JoinTeam.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void gdvMatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
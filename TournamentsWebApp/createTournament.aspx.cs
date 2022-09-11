using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TournamentsWebApp
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateDropDownList(string table, string field, DropDownList list)
		{
			list.Items.Clear();
			connection.Open();
			SqlCommand cmd = new SqlCommand($"SELECT {field} FROM {table}", connection);
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				list.Items.Add(reader.GetString(0));
			}

			connection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			populateDropDownList("Game", "Name", gameUsed); // get the list of games and populate the drop down
			populateDropDownList("Platform", "Name", platformUsed); 
			populateDropDownList("VanueInfo", "VenueName", venue);
		}

		protected void btnCreateTournament_Click(object sender, EventArgs e)
		{
			int selectedGameID = gameUsed.SelectedIndex + 1; // Database ID's start at one and drop down list index is 0 based
			int selectedPlatformID = platformUsed.SelectedIndex + 1;
			int selectedVenueID = venue.SelectedIndex + 1;
			int maxParticipants = Int32.Parse(maximumParticipants.Text);  // can use parse here since UI makes sure its a valid int

			DateTime selectedDate = DateTime.Now;
			DateTime lastEnterenceDate = LastEnterenceDate.SelectedDate;

			// Column names and values string to ensure the SQL command is not super long
			const string COLS = "(StartDate, GameUsedID, PlatformID, MaximumParticipants, LastEnterenceDate, VenueID)";
			const string VALS = "(@sd, @gID, @pID, @maxP, @led, @vID)";
			connection.Open();
			{ // Just syntax stuff, helps me remember to close
				string insertCmdStr = $"INSERT INTO Tournament {COLS} VALUES {VALS}";
				SqlCommand cmd = new SqlCommand(insertCmdStr, connection);
				cmd.Parameters.AddWithValue("@sd", selectedDate);
				cmd.Parameters.AddWithValue("@gID", selectedGameID);
				cmd.Parameters.AddWithValue("@pID", selectedPlatformID);
				cmd.Parameters.AddWithValue("@maxP", maxParticipants);
				cmd.Parameters.AddWithValue("@led", lastEnterenceDate);
				cmd.Parameters.AddWithValue("@vID", selectedVenueID);

				cmd.ExecuteNonQuery();
			}
			connection.Close();

		}
	}
}
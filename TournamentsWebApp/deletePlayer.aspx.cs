using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TournamentsWebApp
{
	public partial class deletePlayer : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateListBox()
		{
			string sql = "SELECT PlayersInfo.Username, TeamsInfo.TeamName FROM PlayersInfo, TeamsInfo WHERE (PlayersInfo.Team_ID = TeamsInfo.Id)";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();

				string formattedString = "";

				while (reader.Read())
				{
					formattedString = $"{reader.GetString(0)} Plays for {reader.GetString(1)}";
					existingPlayers.Items.Add(formattedString);
				}
			}
			connection.Close();
		}

		private void removeFromDB(int id)
		{
			string sql = "DELETE FROM PlayersInfo WHERE Id = @id";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			populateListBox();
		}

		protected void removeTournament_Click(object sender, EventArgs e)
		{
			int playerToDlt = existingPlayers.SelectedIndex + 1;
			removeFromDB(playerToDlt);
		}
	}
}      
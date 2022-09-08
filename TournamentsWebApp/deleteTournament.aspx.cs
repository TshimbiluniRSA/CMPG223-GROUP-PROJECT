using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TournamentsWebApp
{
	public partial class deleteTournament : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\Downloads\CMPG-213_223-Project\CMPG-213_223-Project\Database\TournamentsDB\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateListBox()
		{
			string sql = "SELECT Tournament.Id, Tournament.StartDate, Game.Name, VanueInfo.VenueName " +
						 "FROM Tournament, Game, VanueInfo " +
						 "WHERE (Tournament.GameUsedID = Game.Id) AND (Tournament.VenueID = VanueInfo.Id)";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();

				string formattedString = "";

				while (reader.Read())
				{
					formattedString = $"{reader.GetInt32(0)} {reader.GetDateTime(1).ToString()} - {reader.GetString(2)} tournament, held at {reader.GetString(3)}";
					existingTournaments.Items.Add(formattedString);
				}
			}
			connection.Close();
		}

		private void removeFromDB(int id)
		{
			string sql = "DELETE FROM Tournament WHERE Id = @id";
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
			int tournamentToDlt = int.Parse(existingTournaments.SelectedValue.Split(' ')[0]);
			removeFromDB(tournamentToDlt);
			populateListBox();
		}
	}
}
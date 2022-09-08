using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TournamentsWebApp
{
	public partial class UpdateTeam : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\Downloads\CMPG-213_223-Project\CMPG-213_223-Project\Database\TournamentsDB\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateList(string field, string tbl, ListBox list)
		{
			list.Items.Clear();
			connection.Open();
			{
				string sql = $"SELECT {field} FROM {tbl}";
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					list.Items.Add(reader.GetString(0));
				}
			}
			connection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			populateList("Username", "PlayersInfo", SelectPlayer);
			populateList("TeamName", "TeamsInfo", SelectedTeam);
		}

		protected void update_Click(object sender, EventArgs e)
		{
			string playerUname = SelectPlayer.SelectedValue;
			int selectedTeamID = getTeamID(SelectedTeam.SelectedValue);

			connection.Open();
			{
				string sql = "UPDATE PlayersInfo SET Team_ID = @tid WHERE Username = @uname";
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@uname", playerUname);
				cmd.Parameters.AddWithValue("@tid", selectedTeamID);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		private int getTeamID(string selectedTeamName)
		{
			int res = 0;
			connection.Open();
			{
				string sql = "SELECT Id FROM TeamsInfo WHERE TeamName = @name";
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@name", selectedTeamName);
				SqlDataReader r = cmd.ExecuteReader();

				if (r.Read())
				{
					res = r.GetInt32(0);
				}
			}
			connection.Close();
			return res;
		}
	}
}
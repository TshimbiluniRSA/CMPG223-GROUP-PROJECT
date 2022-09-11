using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TournamentsWebApp
{
	public partial class addDeleteVenue : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateListBox()
		{
			existingVenues.Items.Clear();
			string sql = "SELECT * FROM VanueInfo";
			existingVenues.Items.Clear();
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					existingVenues.Items.Add($"{reader.GetInt32(0)} {reader.GetString(1)} ({reader.GetString(2)})");
				}

			}
			connection.Close();
		}

		private void insertVenue(string Name, string loc)
		{
			string sql = "INSERT INTO VanueInfo(VenueName, Location) VALUES (@name, @location)";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@name", Name);
				cmd.Parameters.AddWithValue("@location", loc);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		private void deleteVenueFromDB(int id)
		{
			string sql = "DELETE FROM VanueInfo WHERE Id = @id";
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
			existingVenues.SelectedIndex = -1;
		}

		protected void addVenue_Click(object sender, EventArgs e)
		{
			string name = venue.Text;
			if (string.IsNullOrWhiteSpace(name))
			{
				errMsg.Text = "Venue name cannot be empty";
			}

			string loc = location.Text;
			if (string.IsNullOrWhiteSpace(name))
			{
				errMsg.Text = "Venue Location cannot be empty";
			}

			insertVenue(name, loc);
			populateListBox();
		}

		protected void deleteVenue_Click(object sender, EventArgs e)
		{
			int id = -1;
			if (int.TryParse(existingVenues.SelectedValue.Split(' ')[0], out id))
			{
				deleteVenueFromDB(id);

				populateListBox();
			}
		}
	}
}
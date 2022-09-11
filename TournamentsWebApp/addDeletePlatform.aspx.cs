using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TournamentsWebApp
{
	public partial class addDeletePlatform : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateListBox()
		{
			existingPlatforms.Items.Clear();
			string sql = "SELECT Name FROM Platform";
			existingPlatforms.Items.Clear();
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					existingPlatforms.Items.Add(reader.GetString(0));
				}

			}
			connection.Close();
		}

		private void insertPlatform(string Name)
		{
			string sql = "INSERT INTO Platform(Name) VALUES (@name)";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@name", Name);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		private void deletePlatformFromDB(string name)
		{
			string sql = "DELETE FROM Platform WHERE Name = @name";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@name", name);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			populateListBox();
			//existingPlatforms.SelectedIndex = -1;
		}


		protected void addGame_Click(object sender, EventArgs e)
		{
			string name = platform.Text;
			if (string.IsNullOrWhiteSpace(name))
			{
				errMsg.Text = "Platform name cannot be empty";
			}
			insertPlatform(name);
			populateListBox();
		}

		protected void deleteGame_Click(object sender, EventArgs e)
		{
			int a = existingPlatforms.Items.Count;
			string selected = existingPlatforms.SelectedValue;
			deletePlatformFromDB(selected);
			populateListBox();
		}
	}
}
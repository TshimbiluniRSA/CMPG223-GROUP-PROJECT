using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TournamentsWebApp
{
	public partial class addDeletePlayer : System.Web.UI.Page
	{
		private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		private SqlConnection connection = new SqlConnection(connString);

		private void populateListBox()
		{
			string sql = "SELECT Name FROM Game";
			existingGames.Items.Clear();
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					existingGames.Items.Add(reader.GetString(0));
				}

			}
			connection.Close();
		}

		private void insertGame(string Name)
		{
			string sql = "INSERT INTO Game(Name) VALUES (@name)";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@name", Name);
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		private void deleteGameFromDB(string name)
		{
			string sql = "DELETE FROM Game WHERE Name = @Name";
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@Name", name);
				cmd.CommandType = CommandType.Text;
				cmd.ExecuteNonQuery();
			}
			connection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			populateListBox();
			existingGames.SelectedIndex = -1;
		}

		protected void addGame_Click(object sender, EventArgs e)
		{
			string name = game.Text;
			if (string.IsNullOrWhiteSpace(name))
			{
				errMsg.Text = "Game name cannot be empty";
			}
			insertGame(name);
			populateListBox();
		}

		protected void deleteGame_Click(object sender, EventArgs e)
		{

			for(int i = 0; i <= existingGames.Items.Count - 1; i++)
            {
                if (existingGames.Items[i].Selected)
                {
					deleteGameFromDB(existingGames.Items[i].Value.ToString());
					
				}
            }
			//string remove = existingGames.SelectedItem.Text;
			existingGames.Items.Remove(existingGames.SelectedItem);
			populateListBox();
		}
	}
}
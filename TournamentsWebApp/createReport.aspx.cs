using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TournamentsWebApp
{
	public partial class createReport : System.Web.UI.Page
	{
		private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
		SqlConnection connection = new SqlConnection(connectionString);

		private void populateDropDownList(string table, string field, DropDownList list)
		{
			connection.Open();
			SqlCommand cmd = new SqlCommand($"SELECT {field} FROM {table}", connection);
			SqlDataReader reader = cmd.ExecuteReader();

			list.Items.Add("None");

			while (reader.Read())
			{
				list.Items.Add(reader.GetString(0));
			}

			connection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			populateDropDownList("Game", "Name", game); // get the list of games and populate the drop down
			populateDropDownList("Platform", "Name", platform);
			populateDropDownList("VanueInfo", "VenueName", venue);
		}

		protected void btnGenerateReport_Click(object sender, EventArgs e)
		{
			DateTime reportStartDate = DateTime.Parse(startDate.Text); // HTML validates this is a date can just get away with parse as oppose to TryParse
			DateTime reportEndDate = DateTime.Parse(endDate.Text);

			if (!(reportEndDate > reportStartDate))
			{
				reportTitle.Text = "End date should be after start date";
				return;
			}

			if (game.SelectedValue == "None" && platform.SelectedValue == "None" && venue.SelectedValue == "None")
			{
				reportTitle.Text = "Atleast one field must be selected";
				return;
			}
			else
			{
				int selectedGameID     = getItemId(game.SelectedValue, "Game", "Name");
				int selectedPlatformID = getItemId(platform.SelectedValue, "Platform", "Name");
				int selectedVenueID    = getItemId(venue.SelectedValue, "VanueInfo", "VenueName");
				int teamsMin = int.Parse(minParticipants.Text); // HTML input validates that this is a number
				int teamsMax = int.Parse(maxParticipants.Text);

				if (teamsMin > teamsMax)
				{
					reportTitle.Text = "Minimum participants cannot be greater than maximum participants";
					return;
				}

				generateReport(reportStartDate, reportEndDate, selectedGameID, selectedPlatformID, selectedVenueID, teamsMin, teamsMax, summerizedReport.Checked);
			}



		}

		private void generateReport(DateTime reportStartDate, DateTime reportEndDate, int selectedGameID, int selectedPlatformID, int selectedVenueID, int teamsMin, int teamsMax, bool isSummerized)
		{
			if (isSummerized)
			{
				string sql = "SELECT COUNT(Tournament.Id) AS 'Number of tournaments', Game.Name, Platform.Name, VanueInfo.VenueName " +
							 "FROM Tournament, Game, Platform, VanueInfo " +
							 "WHERE (Tournament.GameUsedID = @gid) OR (Tournament.PlatformID = @pid) OR (Tournament.VenueID = @vid)" +
							 "AND (Tournament.StartDate BETWEEN @sd AND @ed)" +
							 "GROUP BY Game.Name, Platform.Name, VanueInfo.VenueName";

				IDictionary<string, object> parms = new Dictionary<string, object>()
				{
					{ "@gid", selectedGameID },
					{ "@pid", selectedPlatformID},
					{ "@vid", selectedVenueID },
					{ "@sd", reportStartDate},
					{ "@ed", reportEndDate}
				};

				runQuery(sql, parms);
			}
			else
			{
				string sql = "SELECT StartDate, LastEnterenceDate, VanueInfo.VenueName " +
							 "FROM Tournament, VanueInfo " +
							 "WHERE (Tournament.Id = VanueInfo.Id) AND (Startdate BETWEEN @sd AND @ed)" +
							 "ORDER BY StartDate ASC";

				IDictionary<string, object> parms = new Dictionary<string, object>()
				{
					{ "@sd", reportStartDate},
					{ "@ed", reportEndDate}
				};

				runQuery(sql, parms);
			}
		}

		private void runQuery(string sql, IDictionary<string, object> parms)
		{
			connection.Open();
			{
				SqlCommand cmd = new SqlCommand(sql, connection);

				if (parms.Count > 0)
				{
					foreach (var item in parms)
					{
						cmd.Parameters.AddWithValue(item.Key, item.Value);
					}
				}

				DataSet ds = new DataSet();
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(ds);

				dgvData.DataSource = ds;
				dgvData.DataBind();
			}
			connection.Close();
		}

		private int getItemId(string selectedValue, string table, string col)
		{
			int res = -1;
			connection.Open();
				SqlCommand cmd = new SqlCommand($"SELECT Id FROM {table} WHERE {col} = @value", connection);
				cmd.Parameters.AddWithValue("@value", selectedValue);

				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					res = reader.GetInt32(0);
				}
			connection.Close();

			return res; // Value does not exist
		}
	}
}
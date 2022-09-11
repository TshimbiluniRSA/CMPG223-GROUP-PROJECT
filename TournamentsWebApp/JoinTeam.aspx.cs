using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Group_14_Project
{
    public partial class JoinTeam : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tshimbiluni\source\repos\TshimbiluniRSA\CMPG223-GROUP-PROJECT\TournamentsWebApp\App_Data\TournamentsDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        DataSet ds;
        SqlDataReader theReader;

        private int currID = 0;

        public int team = 0;
        public string teamNxs = "";
        public string teamOmn = "";
        public string teamTsm = "";
        public string teamVox = "";
        public string teamCld = "";
        public string teamFnat = "";
        public string teamPan = "";
        public string teamLum = "";
        public string teamPen = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int countNxs = 0;
            int countOmn = 0;
            int countTsm = 0;
            int countVox = 0;
            int countCld = 0;
            int countFnat = 0;
            int countPan = 0;
            int countLum = 0;
            int countPen = 0;

            try
            {
				if (Session["Id"] != null)
				{
                    currID = (int)Session["Id"];
				}

                conn = new SqlConnection(conStr);
                conn.Open();
                string sql_state = "SELECT Team_ID FROM PlayersInfo";
                comm = new SqlCommand(sql_state, conn);
                theReader = comm.ExecuteReader();

                while (theReader.Read())
                {
                    if (sql_state == teamNxs)
                    {
                        countNxs = countNxs + 1;
                        if (countNxs == 5)
                        {
                            rdbNixus.Visible = false;
                        }
                        else
                        {
                            rdbNixus.Visible = true;
                        }
                    }
                    else if (sql_state == teamOmn)
                    {
                        countOmn = countOmn + 1;
                        if (countOmn == 5)
                        {
                            rdbOmen.Visible = false;
                        }
                        else
                        {
                            rdbOmen.Visible = true;
                        }
                    }
                    else if (sql_state == teamTsm)
                    {
                        countTsm = countTsm + 1;
                        if (countTsm == 5)
                        {
                            rdbTSM.Visible = false;
                        }
                        else
                        {
                            rdbTSM.Visible = true;
                        }
                    }
                    else if (sql_state == teamVox)
                    {
                        countVox = countVox + 1;
                        if (countVox == 5)
                        {
                            rdbVOX.Visible = false;
                        }
                        else
                        {
                            rdbVOX.Visible = true;
                        }
                    }
                    else if (sql_state == teamCld)
                    {
                        countCld = countCld + 1;
                        if (countCld == 5)
                        {
                            rdbCloud9.Visible = false;
                        }
                        else
                        {
                            rdbCloud9.Visible = true;
                        }
                    }
                    else if (sql_state == teamFnat)
                    {
                        countFnat = countFnat + 1;
                        if (countFnat == 5)
                        {
                            rdbFnatic.Visible = false;
                        }
                        else
                        {
                            rdbFnatic.Visible = true;
                        }
                    }
                    else if (sql_state == teamPan)
                    {
                        countPan = countPan + 1;
                        if (countPan == 5)
                        {
                            rdbPanthers.Visible = false;
                        }
                        else
                        {
                            rdbPanthers.Visible = true;
                        }
                    }
                    else if (sql_state == teamLum)
                    {
                        countLum = countLum + 1;
                        if (countLum == 5)
                        {
                            rdbLuminate.Visible = false;
                        }
                        else
                        {
                            rdbLuminate.Visible = true;
                        }
                    }
                    else if (sql_state == teamPen)
                    {
                        countPen = countPen + 1;
                        if (countPen == 5)
                        {
                            rdbPenquins.Visible = false;
                        }
                        else
                        {
                            rdbPenquins.Visible = true;
                        }
                    }
                }
                
                
                conn.Close();
            }
            catch(SqlException error)
            {
                lblError.Visible = true;
                lblError.Text = error.Message;
                conn.Close();
            }
            
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbNixus.Checked)
            {
                teamNxs = "Nixus";
            }
            else if (this.rdbOmen.Checked)
            {
                teamOmn = "Omen";
            }
            else if (this.rdbTSM.Checked)
            {
                teamTsm = "TSM";
            }
            else if (this.rdbVOX.Checked)
            {
                teamVox = "VOX";
            }
            else if (this.rdbCloud9.Checked)
            {
                teamCld = "Cloud9";
            }
            else if (this.rdbFnatic.Checked)
            {
                teamFnat = "Fnatic";
            }
            else if (this.rdbPanthers.Checked)
            {
                teamPan = "Panthers";
            }
            else if (this.rdbLuminate.Checked)
            {
                teamLum = "Luminate";
            }
            else if (this.rdbPenquins.Checked)
            {
                teamPen = "Penquins";
            }
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = "UPDATE PlayersInfo SET Team_ID = @team WHERE Id = @currID";

                if (this.rdbNixus.Checked)
                {
                    team = 1;
                }
                else if (this.rdbOmen.Checked)
                {
                    team = 2;
                }
                else if (this.rdbTSM.Checked)
                {
                    team =3;
                }
                else if (this.rdbVOX.Checked)
                {
                    team = 4;
                }
                else if (this.rdbCloud9.Checked)
                {
                    team = 5; 
                }
                else if (this.rdbFnatic.Checked)
                {
                    team = 6;
                }
                else if (this.rdbPanthers.Checked)
                {
                    team = 7;
                }
                else if (this.rdbLuminate.Checked)
                {
                    team = 8;
                }
                else if (this.rdbPenquins.Checked)
                {
                    team = 9;
                }

                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@team", team);
                comm.Parameters.AddWithValue("currID", currID);
                comm.ExecuteNonQuery();

                conn.Close();
            }
            catch(SqlException error)
            {
                lblError.Visible = true;
                lblError.Text = error.Message;
            }
        }
    }
}
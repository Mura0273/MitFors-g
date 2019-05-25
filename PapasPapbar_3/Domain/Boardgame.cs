using PapasPapbar_3.Appli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PapasPapbar_3.Domain
{
    public class Boardgame : Appli.DB
    {
        //static string myCoonestionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public string boardgameName { get; set; }
        public string playerCount { get; set; }
        public string audience { get; set; }
        public string gameTime { get; set; }
        public string distributor { get; set; }
        public string gameTag { get; set; }
        public int boardgameId { get; set; }

        //Select data from database
        public DataTable Select()
        {
            //Connection to database
            using (SqlConnection con = new SqlConnection(DB.connectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT * FROM Game:Library";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    con.Open();
                    adapter.Fill(dt);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return dt;
            }

        }

        //Method to insert to the database
        public bool Insert(Boardgame p)
        {
            

            using (SqlConnection con = new SqlConnection(DB.connectionString))
            {
                bool isSuccess = false;

                try
                {
                    //Query to insert to the database
                    string sql = "INSERT INTO Game_Library (Boardgame_Name, Player_Count, Audience, Game_Time, Distributor, GameTag) VALUES (@Boardgame_Name, @Player_Count, @Audience, @Game_Time, @Distributor, @GameTag)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //Parameter to add data
                    cmd.Parameters.AddWithValue("@Boardgame_Name, ", p.boardgameName);
                    cmd.Parameters.AddWithValue("@Player_Count, ", p.playerCount);
                    cmd.Parameters.AddWithValue("@Audience, ", p.audience);
                    cmd.Parameters.AddWithValue("@Game_Time, ", p.gameTime);
                    cmd.Parameters.AddWithValue("@Distributor, ", p.distributor);
                    cmd.Parameters.AddWithValue("@GameTag, ", p.gameTag);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return isSuccess;
            }

        }

        //Method to update the database
        public bool Update(Boardgame p)
        {
            using (SqlConnection con = new SqlConnection(DB.connectionString))
            {
                bool isSuccess = false;

                try
                {
                    string sql = "UPDATE Game_Library SET Boardgame_Name = @Boardgame_Name, Player_Count = @Player_Count, Audience = @Audience, Game_Time = @Game_Time, Distributor = @Distributor, GameTag = @GameTag WHERE Boardgame_Id = @Boardgame_Id";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@Boardgame_Name, ", p.boardgameName);
                    cmd.Parameters.AddWithValue("@Player_Count, ", p.playerCount);
                    cmd.Parameters.AddWithValue("@Audience, ", p.audience);
                    cmd.Parameters.AddWithValue("@Game_Time, ", p.gameTime);
                    cmd.Parameters.AddWithValue("@Distributor, ", p.distributor);
                    cmd.Parameters.AddWithValue("@GameTag, ", p.gameTag);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return isSuccess;
            }
        }

        //Method for deleting from database
        public bool Delete(Boardgame p)
        {
            using (SqlConnection con = new SqlConnection(DB.connectionString))
            {
                bool isSuccess = false;

                try
                {
                    string sql = "DELETE FROM Game_Library WHERE Boardgame_Id = @Boardgame_Id";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("Boardgame_Id", p.boardgameId);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return isSuccess;
            }
        }
    }
}

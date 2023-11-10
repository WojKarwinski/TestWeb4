using StripsBL.Interfaces;
using StripsBL.Model;
using System.Data.SqlClient;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public Reeks GetReeks(int id)
{
    Reeks reeks = null;
    List<Strip> strips = new List<Strip>();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        SqlCommand command = new SqlCommand(
            "SELECT R.ID AS ReeksID, R.Naam AS ReeksTitel, " +
            "S.ID AS StripID, S.Titel AS StripTitel, S.Nr " +
            "FROM Reeks R " +
            "LEFT JOIN Strip S ON R.ID = S.Reeks " +
            "WHERE R.ID = @id", connection);

        command.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            if (reeks == null)
            {
                int reeksID = (int)reader["ReeksID"];
                string reeksTitel = (string)reader["ReeksTitel"];

                reeks = reader["ReeksID"] != DBNull.Value
                    ? new Reeks(reeksID, reeksTitel)
                    : new Reeks(reeksTitel);
            }

            int? stripID = reader["StripID"] as int?;
            string stripTitel = (string)reader["StripTitel"];
            int? nr = reader["Nr"] as int?;

            if (stripID.HasValue)
            {
                strips.Add(new Strip(stripID.Value, stripTitel, nr));
            }
        }
        if (reeks != null)
        {
            reeks.Strips = strips;
        }
    }

    return reeks;
}

    }
}

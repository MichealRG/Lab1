using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lab1
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            var sql = "SELECT * FROM Region";
            var command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0]+" "+reader[1]); //albo nazwa kolumny reader["CompanyName"]
            }
            reader.Close();

        }
        public void Insert(SqlConnection connection,int id, string regionName)
        {
            var sql = $"INSERT INTO Region(RegionId, RegionDescription) VALUES (@id, '{regionName}')";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            //command.Parameters.AddWithValue("@regionName", regionName);
            int affected= command.ExecuteNonQuery();
            Console.WriteLine($"{ affected} rows insterted");
        }
        public void Drop(SqlConnection connection, int id)
        {
            var sql = " DELETE FROM Region WHERE RegionID = @id";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{ affected} row deleted");   

        }
        public void Update(SqlConnection connection, int id,int newId)
        {
            var sql = "UPDATE Region SET RegionId=@newId, RegionDescription='Bielsko-Biala' WHERE RegionId=@id";
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@newId", newId);
            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{ affected} row updated");
        }
    }
}

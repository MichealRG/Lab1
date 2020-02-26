using System;
using System.Data.SqlClient;
//prudykath@gmail.com
namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionsString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
             //to wyzej w propertiesie BD
            using var connection = new SqlConnection(connectionsString); //trzyma połączenie po twojej stonie i servera chyba ze jest using wtedy zamyka za klamrą ostatnią
            var db = new DB();
            connection.Open(); //otwiera przygotwane połączenie błąd w connections stringu sie tu objawia

            db.Drop(connection,10);
            db.Drop(connection,11);
            db.Select(connection);
            Console.WriteLine();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader[0]); //albo nazwa kolumny reader["CompanyName"]
            //}
            db.Insert(connection,10, "Bielsko");
            db.Select(connection);
            Console.WriteLine();


            //db.update
            db.Update(connection,10,11);
            db.Select(connection);
            connection.Close(); //zamyka połączenia ale using powinien zamknac

        }
    }
}

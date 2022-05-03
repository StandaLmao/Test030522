using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test
{
    class SQL_OWO
    {
        private string conn_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection;
        public SQL_OWO()
        {

        }

        public List<Shard> GetAll()
        {
            connection = new SqlConnection(conn_string);
            List<Shard> lol = new List<Shard>();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"SELECT * FROM Faktury";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                var shard = new Shard()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    datum = reader["datum"].ToString(),
                    cislo = Convert.ToInt32(reader["cislo"]),
                    odberatel = reader["odberatel"].ToString(),
                    nazev = reader["nazev"].ToString(),
                    pocet = reader["pocet"].ToString(),
                    cenaza = Convert.ToInt32(reader["cenaza"]),
                    celkcena = Convert.ToInt32(reader["celkcena"]),
                    DPH = Convert.ToInt32(reader["DPH"]),
                    cenasDPH = Convert.ToInt32(reader["cenasDPH"]),
                };
                lol.Add(shard);
            }

            return lol;
        }
    }
}

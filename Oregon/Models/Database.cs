using System;
using MySql.Data.MySqlClient;
using Oregon;

namespace Oregon.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conne = new MySqlConnection(DBConfiguration.ConnectionString);
            return conne;
        }
    }
}

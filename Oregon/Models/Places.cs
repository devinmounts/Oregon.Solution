using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Oregon.Models
{
    public class Places
    {
        private static int _id = 0;
        private string _name;
        private string _category;
        private string _opening;
        private string _closing;
        //private Location _location;
        private string _zip;


        public Places(int id, string name, string category, string opening, string closing, string zip)
        {
            _id = id;
            _name = name; 
            _category = category;
            _opening = opening;
            _closing = closing;
            _zip = zip;
        }

        public int GetId()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }

        public string GetCategory()
        {
            return _category;
        }

        public string GetOpening()
        {
            return _opening;
        }

        public string GetClosing()
        {
            return _closing;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM places;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Places> GetAll()
        {
            List<Places> allPlaces = new List<Places> { new Places("testcafe", "cafe", "7", "7", "92331") };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM places;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Name = rdr.GetString(1);
                string Category = rdr.GetString(2);
                string Opening = rdr.GetString(3);
                string Closing = rdr.GetString(4);
                string Zip = rdr.GetString(5);
                Places newPlace = new Places(Id, Name, Category, Opening, Closing, Zip);
                allPlaces.Add(newPlace);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allPlaces;
        }
    }
}
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Oregon.Models
{
    public class Places
    {
        private static int _id = 0;
        private string _name;
        private string _address;
        private string _category;
        private string _opening;
        private string _closing;
        //private Location _location;
        private string _zip;


        public Places(int id, string name, string address, string category, string opening, string closing, string zip)
        {
            _id = id;
            _name = name;
            _address = address;
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

        public string GetAddress()
        {
            return _address;
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

        public string GetZipCode()
        {
            return _zip;
        }

        public void Save() 
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `places` (`name`, `address`, `category`, `opening`, `closing`, `zip`) VALUES (@thisName, @thisAddress, @thisCategory, @thisOpening, @thisClosing, @thisZip);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@thisName";
            name.Value = this._name;
            MySqlParameter address = new MySqlParameter();
            address.ParameterName = "@thisAddress";
            address.Value = this._address;
            MySqlParameter category = new MySqlParameter();
            category.ParameterName = "@thisCategory";
            category.Value = this._category;
            MySqlParameter opening = new MySqlParameter();
            opening.ParameterName = "@thisOpening";
            opening.Value = this._opening;
            MySqlParameter closing = new MySqlParameter();
            closing.ParameterName = "@thisClosing";
            closing.Value = this._closing;
            MySqlParameter zip = new MySqlParameter();
            zip.ParameterName = "@thisZip";
            zip.Value = this._zip;
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(address);
            cmd.Parameters.Add(category);
            cmd.Parameters.Add(opening);
            cmd.Parameters.Add(closing);
            cmd.Parameters.Add(zip);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherPlace)
        {
            //bool placeEquality = false;
            //Places newPlace;

            if (!(otherPlace is Places))
            {
                return false;
            }
            else
            {
                Places newPlace = (Places)otherPlace;
                bool idEquality = (this.GetId() == newPlace.GetId());
                bool addressEquality = (this.GetAddress() == newPlace.GetAddress());
                return (idEquality && addressEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
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
            List<Places> allPlaces = new List<Places> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM places;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Name = rdr.GetString(1);
                string Address = rdr.GetString(2);
                string Category = rdr.GetString(3);
                string Opening = rdr.GetString(4);
                string Closing = rdr.GetString(5);
                string Zip = rdr.GetString(6);
                Places newPlace = new Places(Id, Name, Address, Category, Opening, Closing, Zip);
                allPlaces.Add(newPlace);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allPlaces;
        }

        public static List<Places> GetSome(string inputtedName, string inputtedZip)
        {
            List<Places> allPlaces = new List<Places> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

            if(inputtedZip == "") 
            {
                cmd.CommandText = @"SELECT * FROM places WHERE name = @thisName;";
            }
            else if (inputtedName == "")
            {
                cmd.CommandText = @"SELECT * FROM places WHERE zip = @thisZipCode;";
            }
            else
            {
                cmd.CommandText = @"SELECT * FROM places WHERE name = @thisName AND zip = @thisZipCode;";
            }

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@thisName";
            name.Value = inputtedName;
            MySqlParameter zipCode = new MySqlParameter();
            zipCode.ParameterName = "@thisZipCode";
            zipCode.Value = inputtedZip;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(zipCode);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Name = rdr.GetString(1);
                string Address = rdr.GetString(2);
                string Category = rdr.GetString(3);
                string Opening = rdr.GetString(4);
                string Closing = rdr.GetString(5);
                string Zip = rdr.GetString(6);
                Places newPlace = new Places(Id, Name, Address, Category, Opening, Closing, Zip);
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
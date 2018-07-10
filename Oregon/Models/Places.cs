using System;
using System.Collections.Generic;
namespace Oregon.Models
{
    public class Places
    {
        private static int _id = 0;
        private string _name;
        private string _category;
        private DateTime _hours = new DateTime();
        private Location _location;


        public Places(string name, string category, DateTime hours, Location location)
        {
            _id++;
            _name = name;
            _category = category;
            _hours = hours;
            _location = location;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCategory()
        {
            return _category;
        }

        public DateTime GetHours()
        {
            return _hours;
        }

        public Location GetLocation()
        {
            return _location;
        }
    }
}
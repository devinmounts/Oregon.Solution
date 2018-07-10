using System;
namespace Oregon.Models
{
    public class Location
    {
        private string _address;
        private string _state;
        private string _city;
        private string _zip;

        public Location(string address, string state, string city, string zip)
        {
            _address = address;
            _state = state;
            _city = city;
            _zip = zip;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetState()
        {
            return _state;
        }

        public string GetCity()
        {
            return _city;
        }

        public string GetZip()
        {
            return _zip;
        }
    }
}

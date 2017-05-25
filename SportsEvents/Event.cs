using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvents
{
    public class Event
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Info
        {
            get
            {
                return $"{_name} - {_price} - {_country}";
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public Event(string name, int price, string country)
        {
            _name = name;
            _price = price;
            _country = country;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.models
{
    public abstract class Electronic: Office
    {
        public Electronic(string name ,string type, string brand, string model, string date, int price, string currency ) : base(name)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Date = date;
            Price = price;
            Currency = currency;
        }

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }

    }
}

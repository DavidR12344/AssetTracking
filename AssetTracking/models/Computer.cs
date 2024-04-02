using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.models
{
    public class Computer : Electronic
    {
        public Computer(string name, string type, string brand, string model, string date, int price, string currency) : base(name, type, brand, model, date, price, currency)
        {
        }
    }
}

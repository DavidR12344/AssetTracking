using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.models
{
    public abstract class Office
    {
        public Office(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

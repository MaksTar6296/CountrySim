using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySim
{
    public class Building
    {
        public string Name;
        public int Price;
        public string Resource;
        public int Amount;
        public int Happiness;

        public Building(string name, int price, string resource,
            int amount, int happiness = 0)
        {
            Name = name;
            Price = price;
            Resource = resource;
            Amount = amount;
            Happiness = happiness;
        }
    }
}

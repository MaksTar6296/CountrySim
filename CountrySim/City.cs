using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySim
{
    public class City
    {
        public string Name;
        public string Size;
        public int Population;
        public int Happiness;
        public int Tax;
        public List<Building> Buildings = new List<Building>();

        public City(string name, string size, int population,
            int happiness, int tax)
        {
            Name = name;
            Size = size;
            Population = population;
            Happiness = happiness;
            Tax = tax;
        }

        public int Slots()
        {
            if (Size == "Small") return 12;
            if (Size == "Medium") return 20;
            return 36;
        }

        public void Build(Building building)
        {
            if (Buildings.Count < Slots())
            {
                Buildings.Add(building);
                Happiness += building.Happiness;
                if (Happiness > 100) Happiness = 100;
                if (Happiness < 0) Happiness = 0;
            }
        }
    }
}

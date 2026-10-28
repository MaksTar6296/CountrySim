using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySim
{
    public class Country
    {
        public string Name;
        public string Government;
        public double Money = 2000;
        public int Food = 100;
        public List<City> Cities = new List<City>();

        public Country(string name, string government)
        {
            Name = name;
            Government = government;
        }

        public void AddCity(City city)
        {
            Cities.Add(city);

            if (Government == "Dictatorship")
                city.Happiness = Math.Min(100, city.Happiness + 20);
        }

        public void Build(City city, Building building)
        {
            int extraSlots = 0
            if(Government == "Democracy")
            {
                extraSlots = 4;
            }
            else
            {
                extraSlots = 0;
            }

            if (Money >= building.Price &&
                city.Buildings.Count < city.Slots() + extraSlots)
            {
                Money -= building.Price;
                city.Build(building);
            }
        }

        public void Month(int month)
        {
            double taxes = 0;

            foreach (City city in Cities)
            {
                if (city.Happiness <= 0) continue;

                foreach (Building b in city.Buildings)
                {
                    if (b.Resource == "Food") Food += b.Amount;
                    if (b.Resource == "Money") Money += b.Amount;
                }
            }

            foreach (City city in Cities)
            {
                int neededFood = (int)Math.Ceiling(city.Population / 1000.0);
                bool enoughFood = Food >= neededFood;

                if (enoughFood)
                    Food -= neededFood;
                else
                    city.Happiness = Math.Max(0, city.Happiness - 10);

                if (city.Happiness > 0)
                {
                    double multiplier = Government == "Monarchy" ? 1.25 : 1;
                    taxes += city.Population / 1000.0 * 10
                        * city.Tax / 100.0 * multiplier;
                }

                if (enoughFood && city.Happiness > 0)
                    city.Population += (int)(city.Population * 0.01);

                if (city.Tax > 40) city.Happiness -= 5;
                else if (city.Tax > 20) city.Happiness -= 2;

                if (city.Happiness < 0)
                    city.Happiness = 0;

                if (city.Happiness > 100)
                    city.Happiness = 100;
            }

            Money += taxes;

            Console.WriteLine($"\nМісяць {month}");
            Console.WriteLine($"Країна: {Name}");
            Console.WriteLine($"Гроші: {Money:F2}");
            Console.WriteLine($"Їжа: {Food}");

            foreach (City city in Cities)
            {
                Console.WriteLine(
                    $"{city.Name}: населення {city.Population}, " +
                    $"щастя {city.Happiness}, будівлі {city.Buildings.Count}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySim
{
    internal class Program
    {
        static void Main()
        {
            Country country = new Country("Україна", "Democracy");

            City kyiv = new City("Київ", "Large", 50000, 80, 15);
            City lviv = new City("Львів", "Medium", 25000, 75, 12);
            City odesa = new City("Одеса", "Small", 10000, 70, 10);

            country.AddCity(kyiv);
            country.AddCity(lviv);
            country.AddCity(odesa);

            country.Build(kyiv, new Farm());
            country.Build(kyiv, new Bank());
            country.Build(kyiv, new Market());
            country.Build(kyiv, new Theatre());

            country.Build(lviv, new Farm());
            country.Build(lviv, new Museum());
            country.Build(lviv, new Market());

            country.Build(odesa, new Farm());
            country.Build(odesa, new Mine());
            country.Build(odesa, new Factory());

            for (int month = 1; month <= 12; month++)
                country.Month(month);

            Console.WriteLine("\nСимуляцію завершено!");
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace hm56
{
    class HomeWork56
    {
        static void Main(string[] args)
        {
            Box box = new Box();
            List<Stew> delayStews = new List<Stew>();
            int presentYear = 2022;

            delayStews = box.GetDelays(presentYear);
            Console.WriteLine("Просроки:");

            foreach(Stew stew in delayStews)
            {
                Console.WriteLine($"{stew.Name}, годен до {stew.ExpirationDate}");
            }
        }
    }

    class Box
    {
        private List<Stew> _stews = new List<Stew>()
        {
            new Stew("Барс(Говядина)", 2020),
            new Stew("Совок(Говядина)", 2019),
            new Stew("Главпродукт(Говядина)", 2015),
            new Stew("Гродфуд(Говядина)", 2017),
            new Stew("Барс(Свинина)", 2022),
            new Stew("Совок(Свинина)", 2018),
            new Stew("Главпродукт(Свинина)", 2005),
            new Stew("Гродфуд(Свнинина)", 2020),
        };

        public List<Stew> GetDelays(int presentYear)
        {
            var delayStews = _stews.Where(stew => stew.ExpirationDate < presentYear);
            return delayStews.ToList();
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }
        private int _shelfLife = 4;

        public Stew(string name, int yearOfProduction)
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            ExpirationDate = yearOfProduction + _shelfLife;
        }
    }
}

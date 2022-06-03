using System;
using System.Collections.Generic;
using System.Linq;

namespace hm57
{
    class HomeWork57
    {
        static void Main(string[] args)
        {
            Army army = new Army();

            army.GetNameRank();
        }
    }

    class Army
    {
        private List<Solider> _soliders = new List<Solider>()
        {
            new Solider("Владимир", "АК-47", "Сержант", 9),
            new Solider("Михаил", "АК-12", "Ст.Сержант", 12),
            new Solider("Гавс", "ВСС", "Генерал", 720),
            new Solider("Даниил", "AK-47", "Рядовой", 3),
            new Solider("Роман", "AK-74", "Мл.Сержант", 5)
        };

        public void GetNameRank()
        {
            var solidersName = _soliders.Select(solider => solider.Name).ToArray();
            var solidersRank = _soliders.Select(solider => solider.Rank).ToArray();

            for(int i = 0; i < solidersName.Length; i++)
            {
                Console.WriteLine($"{solidersName[i]}, {solidersRank[i]}");
            }
        }
    }

    class Solider
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int ServiceLife { get; private set; }

        public Solider(string name, string weapon, string rank, int serviceLife)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            ServiceLife = serviceLife;
        }
    }
}

using System;
using System.Collections.Generic;

namespace hm48
{
    class HomeWork48
    {
        static void Main(string[] args)
        {
            Eldia eldia = new Eldia();
            Paradise paradise = new Paradise();

            while(eldia.GetCorpsesCount() != eldia.GetSolidersCount() && paradise.GetCorpsesCount() != paradise.GetSolidersCount())
            {
                ShowBattleInfo();
                eldia.Attack(paradise);
                paradise.Attack(eldia);
                ShowBattleInfo();
            }

            if (eldia.GetCorpsesCount() < eldia.GetSolidersCount())
            {
                Console.WriteLine($"Победила {eldia.Country}");
            }
            else if (paradise.GetCorpsesCount() < paradise.GetSolidersCount())
            {
                Console.WriteLine($"Победил {paradise.Country}");
            }
            else
            {
                Console.WriteLine("Никто не выиграл");
            }

            void ShowBattleInfo()
            {
                Console.Clear();
                Console.WriteLine(eldia.Country);
                eldia.ShowSolidersInfo();
                Console.WriteLine();
                Console.WriteLine(paradise.Country);
                paradise.ShowSolidersInfo();
                Console.ReadLine();
            }
        }
    }

    abstract class Squad
    {
        public string Country { get; protected set; }
        protected List<Solider> Soliders = new List<Solider>();

        protected void CreateSquad(string country, int stormtrooperCount, int machineGunnerCount, int sniperCount, int rocketManCount)
        {
            Country = country;

            for(int i = 0; i < stormtrooperCount; i++)
            {
                Soliders.Add(new Stormtrooper());
            }

            for (int i = 0; i < machineGunnerCount; i++)
            {
                Soliders.Add(new MachineGunner());
            }

            for (int i = 0; i < sniperCount; i++)
            {
                Soliders.Add(new Sniper());
            }

            for (int i = 0; i < rocketManCount; i++)
            {
                Soliders.Add(new RocketMan());
            }
        }

        public Solider GetSolider()
        {
            Random random = new Random();
            int randomIndex = 0;
            bool isFind = false;

            while(isFind == false)
            {
                randomIndex = random.Next(0, Soliders.Count);

                if(Soliders[randomIndex].isDead == false)
                {
                    isFind = true;
                }
            }

            return Soliders[randomIndex];
        }

        public void Attack(Squad squad)
        {
            for (int i = 0; i < Soliders.Count; i++)
            {
                for (int j = 0; j < Soliders[i].Weapon.RadiusDefeat; j++)
                {
                    Soliders[i].Shoot(squad.GetSolider());
                }
            }
        }

        public void ShowSolidersInfo()
        {
            for(int i = 0; i < Soliders.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Soliders[i].ClassName}:");
                if (Soliders[i].isDead == false)
                {
                    Console.WriteLine($"Здоровье - {Soliders[i].Health}");
                }
                else
                {
                    Console.WriteLine("Мертв");
                }
            }
        }

        public int GetCorpsesCount()
        {
            int corpsesAmount = 0;

            foreach(Solider solider in Soliders)
            {
                if (solider.isDead == true)
                {
                    corpsesAmount++;
                }
            }

            return corpsesAmount;
        }

        public int GetSolidersCount()
        {
            return Soliders.Count;
        }
    }

    class Eldia : Squad
    {
        public Eldia()
        {
            CreateSquad("Эльдия", 30, 10, 5, 5);
        }
    }

    class Paradise : Squad
    {
        public Paradise()
        {
            CreateSquad("Парадиз", 25, 5, 10, 10);
        }
    }

    abstract class Solider
    {
        public string ClassName { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }
        public Weapon Weapon { get; private set; }
        public bool isDead { get; private set; } = false;

        protected void CreateSolider(string className, int armor, Weapon weapon)
        {
            Random random = new Random();
            int minHealth = 75;
            int maxHealth = 151;

            ClassName = className;
            Health = random.Next(minHealth, maxHealth);
            Armor = armor;
            Weapon = weapon;
        }

        public void Shoot(Solider solider)
        {
            int percentageConvert = 200;

            if (Health > 0)
            {
                float ExtinguishedDamage = (float)Weapon.Damage * (float)(solider.Armor / percentageConvert);
                solider.Health -= (int)Weapon.Damage - (int)ExtinguishedDamage;
            }
            else
            {
                isDead = true;
            }
        }
    }

    class Stormtrooper : Solider
    {
        public Stormtrooper()
        {
            CreateSolider("Штурмовик", 50, new AutoRifle());
        }
    }

    class MachineGunner : Solider
    {
        public MachineGunner()
        {
            CreateSolider("Пулеметчик", 100, new MachineGun());
        }
    }

    class Sniper : Solider
    {
        public Sniper()
        {
            CreateSolider("Снайпер", 10, new SniperRifle());
        }
    }

    class RocketMan : Solider
    {
        public RocketMan()
        {
            CreateSolider("Ракетометчик", 50, new RocketLauncher());
        }
    }

    abstract class Weapon
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int RadiusDefeat { get; protected set; }

        protected void SetWeapon(string name, int damage, int radiusDefeat)
        {
            Name = name;
            Damage = damage;
            RadiusDefeat = radiusDefeat;
        }
    }

    class AutoRifle : Weapon
    {
        public AutoRifle()
        {
            SetWeapon("AK-47", 50, 1);
        }
    }

    class MachineGun : Weapon
    {
        public MachineGun()
        {
            SetWeapon("РПК", 35, 3);
        }
    }

    class SniperRifle : Weapon
    {
        public SniperRifle()
        {
            SetWeapon("Barrett M82", 150, 1);
        }
    }

    class RocketLauncher : Weapon
    {
        public RocketLauncher()
        {
            SetWeapon("RPG", 100, 5);
        }
    }
}

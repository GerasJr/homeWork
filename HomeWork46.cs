using System;
using System.Collections.Generic;

namespace hm46
{
    class HomeWork46
    {
        static void Main(string[] args)
        {
            List<Warrior> warriors = new List<Warrior>() { new Berserk(), new Healer(), new Faster(), new Assasin(), new Ghost()};
            Warrior firstWarrior;
            Warrior secondWarrior;
            
            Console.WriteLine("Выберете бойца");
            Console.WriteLine();

            for(int i = 0; i < warriors.Count; i++)
            {
                Console.WriteLine(i + 1 + ":");
                warriors[i].ShowInfo();
            }

            firstWarrior = SelectCharacter();
            secondWarrior = SelectCharacter();

            while (firstWarrior.Health > 0 && secondWarrior.Health > 0)
            {
                firstWarrior.Attack(secondWarrior);
                secondWarrior.Attack(firstWarrior);
                Console.WriteLine($"{firstWarrior.Name} - {firstWarrior.Health} hp");
                Console.WriteLine($"{secondWarrior.Name} - {secondWarrior.Health} hp");
                Console.WriteLine();
            }

            if(firstWarrior.Health > 0)
            {
                Console.WriteLine("Победитель - " + firstWarrior.Name);
            }
            else if(secondWarrior.Health > 0)
            {
                Console.WriteLine("Победитель - " + secondWarrior.Name);
            }
            else
            {
                Console.WriteLine("Ничья");
            }
        }

        private static Warrior SelectCharacter()
        {
            Warrior warrior = new Berserk();
            bool isSelect = false;

            while (isSelect == false)
            {
                isSelect = true;

                switch (Console.ReadLine())
                {
                    case "1":
                        warrior = new Berserk();
                        break;
                    case "2":
                        warrior = new Healer();
                        break;
                    case "3":
                        warrior = new Faster();
                        break;
                    case "4":
                        warrior = new Assasin();
                        break;
                    case "5":
                        warrior = new Ghost();
                        break;
                    default:
                        isSelect = false;
                        break;
                }
            }

            return warrior;
        }
    }

    abstract class Warrior
    {
        protected int DefaultDamage;
        protected string AbilityInfo;
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        protected void SetSpecifications(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            DefaultDamage = damage;
        }

        public abstract void SetAbility(int warriorDamage, int warriorHealth);

        public void Attack(Warrior warrior)
        {
            SetAbility(warrior.Damage, warrior.Health);
            warrior.Health -= Damage;
            Damage = DefaultDamage;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Имя: " + Name);
            Console.WriteLine("Здоровье: " + Health);
            Console.WriteLine("Урон: " + Damage);
            Console.WriteLine(AbilityInfo);
        }
    }

    class Berserk : Warrior
    {
        private int _rage = 0;

        public Berserk()
        {
            SetSpecifications("Guts", 400, 150);
            AbilityInfo = "накапливает ярость с каждой атакой и тем увеличивает свой урон";
        }

        public override void SetAbility(int warriorDamage, int warriorHealth)
        {
            int rageBuff = 30;

            _rage += rageBuff;
            Damage += _rage;
        }
    }

    class Healer : Warrior
    {
        private int _defaultHealth;

        public Healer()
        {
            SetSpecifications("Ivan", 200, 75);
            _defaultHealth = Health;
            AbilityInfo = "С шансом в 50 процентов на каждую атаку может пополнить запас здоровья";
        }

        public override void SetAbility(int warriorDamage, int warriorHealth)
        {
            Random random = new Random();
            int percent = 101;
            int chance = 50;
            int healthBuff = 150;

            if (chance >= random.Next(0, percent) && Health < _defaultHealth)
            {
                Health += healthBuff;
                Console.WriteLine($"{Name} Излечился");
            }
        }
    }

    class Faster : Warrior
    {
        public Faster()
        {
            SetSpecifications("Levi", 200, 100);
            AbilityInfo = "С шансом в 30 процентов на каждую атаку может увернуться и нанести двойной урон";
        }

        public override void SetAbility(int warriorDamage, int warriorHealth)
        {
            Random random = new Random();
            int percent = 101;
            int chance = 30;

            if(chance >= random.Next(0, percent))
            {
                Health += warriorDamage;
                Damage *= 2;
                Console.WriteLine($"{Name} увернулся и нанес двойной урон");
            }

        }
    }

    class Assasin : Warrior
    {
        public Assasin()
        {
            SetSpecifications("Altair", 400, 0);
            AbilityInfo = "Способен убить противника c одного удара, тем не менее шанс на успешную атаку равен 10 процентам";
        }

        public override void SetAbility(int warriorDamage, int warriorHealth)
        {
            Random random = new Random();
            int percent = 101;
            int chance = 10;

            if (chance >= random.Next(0, percent))
            {
                Damage += warriorHealth;
            }
        }
    }

    class Ghost : Warrior
    {
        private int _defaultHealth;

        public Ghost()
        {
            SetSpecifications("Ghost", 10000, 20);
            _defaultHealth = Health;
            AbilityInfo = "Убить его невозможно, но может погибнуть с шансом 5 процентов во время атаки";
        }

        public override void SetAbility(int warriorDamage, int warriorHealth)
        {
            Health = _defaultHealth;

            Random random = new Random();
            int percent = 101;
            int chance = 5;

            if (chance >= random.Next(0, percent))
            {
                Health = 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace hm49
{
    class HomeWork49
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.Work(true);
        }
    }

    class Aquarium
    {
        private List<Fish> _pisces = new List<Fish>();
        private int _maxCapacity = 10;

        public void Work(bool isWork)
        {
            while (isWork)
            {
                Console.WriteLine("Что бы добавить рыбку в аквариум введите add");
                Console.WriteLine("Что бы достать введите del");
                Console.WriteLine("Для пропуска нажмите Enter");
                Console.WriteLine();
                ShowAllPisces();
                string userInput = Console.ReadLine();

                if(userInput == "add")
                {
                    if(_pisces.Count < _maxCapacity)
                    {
                        AddFish();
                    }
                    else
                    {
                        Console.WriteLine("У вас не хватает места в аквариуме");
                        Console.ReadLine();
                    }
                }
                else if(userInput == "del")
                {
                    DeleteFish();
                }

                SkipYear();
                Console.Clear();
            }
        }

        private void ShowAllPisces()
        {
            for(int i = 0; i < _pisces.Count; i++)
            {
                Console.Write($"{i + 1}: {_pisces[i].Name}. {_pisces[i].Age} годиков. ");

                if(_pisces[i].IsAlive == false)
                {
                    Console.WriteLine("Мертв(а)");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        private void AddFish()
        {
            Console.WriteLine("Дайте имя рыбке");
            _pisces.Add(new Fish(Console.ReadLine()));
        }

        private void DeleteFish()
        {
            Console.WriteLine("Введите номер рыбки которую хотите удалить");
            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out int number) && number <= _pisces.Count && number > 0)
            {
                _pisces.RemoveAt(number - 1);
            }
        }

        private void SkipYear()
        {
            foreach(Fish fish in _pisces)
            {
                fish.Growing();
            }
        }
    }

    class Fish
    {
        public string Name { get; private set; }
        public int Age { get; private set; } = -1;
        public bool IsAlive { get; private set; } = true;

        public Fish(string name)
        {
            Name = name;
        }

        public void Growing()
        {
            int maxAge = 10;

            Age++;

            if (Age >= maxAge)
            {
                IsAlive = false;
            }
        }
    }
}

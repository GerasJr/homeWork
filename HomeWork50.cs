using System;
using System.Collections.Generic;

namespace hm50
{
    class HomeWork50
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Work(true);
        }
    }

    class Zoo
    {
        private List<Aviary> _aviarys = new List<Aviary>();

        public Zoo()
        {
            _aviarys.Add(new Aviary("Dog", 10));
            _aviarys.Add(new Aviary("Tiger", 5));
            _aviarys.Add(new Aviary("Lynx", 7));
            _aviarys.Add(new Aviary("Fox", 10));
        }

        public void Work(bool isWork)
        {
            while (isWork)
            {
                Console.WriteLine($"Перед вами {_aviarys.Count} вольеров");
                Console.WriteLine($"К какому вы хотите подойти?");
                string readInput = Console.ReadLine();

                if (int.TryParse(readInput, out int number) && number <= _aviarys.Count && number > 0)
                {
                    ComeUpAviary(number - 1);
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }
        }

        private void ComeUpAviary(int index)
        {
            _aviarys[index].ShowAnimals();
            Console.WriteLine("Что бы отойти от вольера нажмите enter");
            Console.ReadLine();
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public Aviary(string animalTitle, int animalCount)
        {
            for(int i = 0; i < animalCount; i++)
            {
                switch (animalTitle)
                {
                    case "Dog":
                        _animals.Add(new Dog());
                        break;
                    case "Tiger":
                        _animals.Add(new Tiger());
                        break;
                    case "Lynx":
                        _animals.Add(new Lynx());
                        break;
                    case "Fox":
                        _animals.Add(new Fox());
                        break;
                }
            }
        }

        public void ShowAnimals()
        {
            Console.WriteLine($"Кол-во животных в вольере - {_animals.Count}");

            for(int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"{i + 1} {_animals[i].Title}: {_animals[i].Gender}");
                Console.WriteLine($"Издает звук {_animals[i].Sound}");
            }
        }
    }

    abstract class Animal
    {
        private Random _random = new Random();
        public string Title { get; protected set; }
        public string Gender { get; protected set; }
        public string Sound { get; protected set; }

        protected void CreateAnimal(string title, string sound)
        {
            bool isMale = _random.Next(2) == 0;

            if (isMale == true)
            {
                Gender = "Самец";
            }
            else
            {
                Gender = "Самка";
            }

            Title = title;
            Sound = sound;
        }
    }

    class Dog : Animal
    {
        public Dog()
        {
            CreateAnimal("Собака", "Гав гав");
        }
    }

    class Tiger : Animal
    {
        public Tiger()
        {
            CreateAnimal("Тигр", "Уррррр");
        }
    }

    class Lynx : Animal
    {
        public Lynx()
        {
            CreateAnimal("Рысь", "Кау кау");
        }
    }

    class Fox : Animal
    {
        public Fox()
        {
            CreateAnimal("Лиса", "Иааааа");
        }
    }
}

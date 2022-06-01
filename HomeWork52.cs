using System;
using System.Collections.Generic;
using System.Linq;

namespace hm52
{
    class HomeWork52
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            database.Work(true);
        }
    }

    class Database
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public void Work(bool isWork)
        {
            while (isWork)
            {
                Console.WriteLine("Добавить преступника - 1");
                Console.WriteLine("Поиск в базе данных - 2");
                Console.WriteLine("Посадить преступника - 3");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddCriminal();
                        break;
                    case "2":
                        SearchCriminals();
                        break;
                    case "3":
                        PutInJail();
                        break;
                    default:
                        Console.WriteLine("Ошибка, некорректный ввод");
                        break;
                }
            }
        }

        private void AddCriminal()
        {
            string fullName;
            int height;
            int weight;
            string nationality;

            Console.WriteLine("Введите ФИО преступника");
            fullName = Console.ReadLine();
            Console.WriteLine("Введите его рост(кг) и вес(см) через пробел");
            string[] readHeightWeight = Console.ReadLine().Split(" ");

            if(int.TryParse(readHeightWeight[0], out height) && int.TryParse(readHeightWeight[1], out weight))
            {
                Console.WriteLine("Введите национальность");
                nationality = Console.ReadLine();
                _criminals.Add(new Criminal(fullName, height, weight, nationality));
            }
            else
            {
                Console.WriteLine("Ошибка, некорректный ввод");
            }
        }

        private void PutInJail()
        {
            List<Criminal> criminals = SearchCriminals();
            Console.WriteLine("Выберете номер преступника");
            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out int number) && number >= 0 && number < criminals.Count)
            {
                criminals[number].GoToJail();
                Console.WriteLine($"Преступник {criminals[number].FullName}");
                Console.WriteLine("Посажен в тюрьму");
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        private List<Criminal> SearchCriminals()
        {
            Console.WriteLine("Введите ФИО, рост, вес, или национальность преступника");
            string userInput = Console.ReadLine();
            List<Criminal> criminals = new List<Criminal>();
            var filtredCriminals = from Criminal criminal in _criminals
                                   select criminal;

            if (int.TryParse(userInput, out int userInt))
            {
                filtredCriminals = from Criminal criminal in _criminals
                                       where criminal.Height == userInt || criminal.Weight == userInt && criminal.IsPrisoner == false
                                       select criminal;
            }
            else
            {
                filtredCriminals = from Criminal criminal in _criminals
                                       where criminal.FullName.ToLower().StartsWith(userInput.ToLower()) ||
                                             criminal.Nationality.ToLower().StartsWith(userInput.ToLower()) && criminal.IsPrisoner == false
                                       select criminal;
            }

            foreach (Criminal criminal in filtredCriminals)
            {
                criminals.Add(criminal);
            }

            for(int i = 0; i < criminals.Count; i++)
            {
                Console.Write($"{i}: ");
                ShowCriminalInfo(criminals[i]);
                Console.WriteLine();
            }

            return criminals;
        }

        private void ShowCriminalInfo(Criminal criminal)
        {
            Console.WriteLine(criminal.FullName);
            Console.WriteLine($"Рост - {criminal.Height}");
            Console.WriteLine($"Вес - {criminal.Weight}");
            Console.WriteLine($"Национальность - {criminal.Nationality}");
        }
    }

    class Criminal
    {
        public string FullName { get; private set; }
        public bool IsPrisoner { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string fullName, int height, int weight, string nationality)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsPrisoner = false;
        }

        public void GoToJail()
        {
            IsPrisoner = true;
        }
    }
}

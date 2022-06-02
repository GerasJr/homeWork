using System;
using System.Collections.Generic;
using System.Linq;

namespace hm54
{
    class HomeWork54
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            database.Work(true);
        }
    }

    class Database
    {
        private List<Patient> _patients = new List<Patient>()
        {
            new Patient("Листроп Мариус Лукас-Антонио", 27, "Эпилепсия"),
            new Patient("Кононова Алёна Львовна", 55, "Амнезия"),
            new Patient("Гусева Мария Дмитриевна", 67, "Истощение"),
            new Patient("Петров Тимофей Никитич", 32, "Экзема"),
            new Patient("Филиппов Марк Артурович", 40, "Малярия"),
            new Patient("Климов Иван Владимирович", 53, "Цистит"),
            new Patient("Степанов Владимир Сергеевич", 24, "Бессонница"),
            new Patient("Агапов Михаил Викторович", 29, "Бессонница"),
            new Patient("Шилова Асия Тимофеевна", 67, "Эпилепсия"),
            new Patient("Смирнов Демид Никитич", 49, "Истощение"),
        };

        public void Work(bool isWork)
        {
            while (isWork)
            {
                Console.WriteLine("1 - Сортировка больных по фио");
                Console.WriteLine("2 - Сортировка больных по возрасту");
                Console.WriteLine("3 - Вывести больных с определенным заболеванием");

                switch (Console.ReadLine())
                {
                    case "1":
                        SortByFullName();
                        break;
                    case "2":
                        SortByAge();
                        break;
                    case "3":
                        OutPutByDisease();
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }

                Console.WriteLine("Что бы продолжить нажмите enter");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void SortByFullName()
        {
            Console.WriteLine("Введите ФИО");
            string userInput = Console.ReadLine().ToLower();
            var sortPatients = _patients.OrderByDescending(patient => patient.FullName.ToLower().StartsWith(userInput));
            OutPutPatients(sortPatients.ToList());
        }

        private void SortByAge()
        {
            Console.WriteLine("Вывести по возрастанию - inc");
            Console.WriteLine("По убыванию - des");
            string userInput = Console.ReadLine();
            var sortPatients = from Patient patient in _patients
                               select patient;

            if (userInput == "inc")
            {
                sortPatients = _patients.OrderBy(patient => patient.Age);
            }
            else if (userInput == "des")
            {
                sortPatients = _patients.OrderByDescending(patient => patient.Age);
            }
            else
            {
                Console.WriteLine("Ошибка");
                return;
            }

            OutPutPatients(sortPatients.ToList());
        }

        private void OutPutByDisease()
        {
            Console.WriteLine("Введите заболевание");
            string userInput = Console.ReadLine().ToLower();
            var filtredPatients = _patients.Where(patient => patient.Disease.ToLower().StartsWith(userInput));
            OutPutPatients(filtredPatients.ToList());
        }

        private void OutPutPatients(List<Patient> patients)
        {
            foreach(Patient patient in patients)
            {
                Console.WriteLine(patient.FullName);
                Console.WriteLine($"Возраст - {patient.Age}");
                Console.WriteLine($"Диагноз - {patient.Disease}");
                Console.WriteLine();
            }
        }
    }

    class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }
    }
}

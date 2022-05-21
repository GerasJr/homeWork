using System;
using System.Collections.Generic;

namespace hm45
{
    class HomeWork45
    {
        static void Main(string[] args)
        {
            ControlRoom controlRoom = new ControlRoom();
            controlRoom.Work(true);
        }
    }

    class ControlRoom
    {
        private List<Train> _trains = new List<Train>();
        private List<string> _cities = new List<string>();

        public ControlRoom()
        {
            _cities.Add("Москва");
            _cities.Add("Бийск");
            _cities.Add("Барнаул");
            _cities.Add("Нижний Новгород");
            _cities.Add("Калининград");
            _cities.Add("Уфа");
            _cities.Add("Нижний Тагил");
            _cities.Add("Волгоград");
        }

        public void Work(bool isWork)
        {
            while (isWork)
            {
                ShowAllTrains();
                Console.WriteLine("Выберете направление поездов");
                Console.WriteLine("Сперва откуда стартует, после до куда едет");
                Console.WriteLine();

                for(int i = 0; i < _cities.Count; i++)
                {
                    Console.WriteLine($"{i}: {_cities[i]}");
                }

                string startPosition = ReadCity(_cities.Count);
                Console.WriteLine("Стартовый город - " + startPosition);
                string endPosition = ReadCity(_cities.Count, startPosition);
                Console.WriteLine("Конечный город - " + endPosition);
                Console.WriteLine();
                Random random = new Random();
                int minPassangers = 100;
                int maxPassangers = 500;
                int passengers = random.Next(minPassangers, maxPassangers);
                Console.WriteLine($"Кол-во купленных билетов на этот рейс - {passengers}");
                _trains.Add(new Train(passengers, _trains.Count, startPosition, endPosition));
                Console.Write("Для него готов поезд типа ");
                _trains[_trains.Count - 1].ShowInfo();
                Console.WriteLine("Для отправки нажмите enter");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private string ReadCity(int citiesCount, string startCity = "")
        {
            string city = "";
            bool isReturn = false;

            while(isReturn == false)
            {
                string readInput = Console.ReadLine();

                if (int.TryParse(readInput, out int cityNumber) && cityNumber < citiesCount && startCity != _cities[cityNumber])
                {
                    city = _cities[cityNumber];
                    isReturn = true;
                }
                else
                {
                    Console.WriteLine("Ошибка, попробуйте еще раз");
                }
            }

            return city;
        }

        private void ShowAllTrains()
        {
            int xPosition = 0;
            int yPosition = 25;
            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine("Все рейсы:");
            foreach(Train train in _trains)
            {
                train.ShowInfo();
                Console.WriteLine();
            }
            Console.SetCursorPosition(default, default);
        }
    }

    class Train
    {
        private Dictionary<string, int> _typeCapacity = new Dictionary<string, int>();
        private string[] _vanTypes = new string[] { "Плацкарт", "Купе", "СВ" };
        private List<Van> _vans = new List<Van>();
        private int _number;
        private string _startCity;
        private string _endCity;

        public Train(int passengers, int number, string start, string end)
        {
            int vans;
            Random random = new Random();

            _typeCapacity.Add(_vanTypes[0], 54);
            _typeCapacity.Add(_vanTypes[1], 36);
            _typeCapacity.Add(_vanTypes[2], 19);
            _number = number;
            _startCity = start;
            _endCity = end;
            string type = _vanTypes[random.Next(0, _vanTypes.Length)];

            vans = passengers / _typeCapacity[type];

            if(passengers % _typeCapacity[type] != 0)
            {
                vans++;
            }

            for (int i = 0; i < vans; i++)
            {
                _vans.Add(new Van(type, _typeCapacity[type]));
            }
        }

        public void ShowInfo()
        {
            int totalCapality = _vans.Count * _vans[0].Capacity;
            Console.WriteLine($"*{_vans[0].Type}* c общей вместимостью в {totalCapality} человек");
            Console.WriteLine($"Кол-во вагонов: {_vans.Count}");
            Console.WriteLine($"Номер поезда: {_number}");
            Console.WriteLine($"Направление: {_startCity} - {_endCity}");
        }
    }

    class Van
    {
        public string Type { get; private set;}
        public int Capacity { get; private set;}

        public Van(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }
    }
}

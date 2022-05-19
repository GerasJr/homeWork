using System;
using System.Collections.Generic;

namespace hm41
{
    class HomeWork41
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            Database database = new Database();

            database.Work(isWork);
        }
    }

    class Database
    {
        private int _minUnicueNumber = 0;
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void Work(bool isWork)
        {
            Console.WriteLine("1 - Добавить игрока");
            Console.WriteLine("2 - Забанить игрока");
            Console.WriteLine("3 - Разбанить игрока");
            Console.WriteLine("4 - Удалить игрока");
            Console.WriteLine("5 - Показать всех игроков");

            while (isWork)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddPlayer();
                        break;
                    case "2":
                        BanPlayer();
                        break;
                    case "3":
                        UnbanPlayer();
                        break;
                    case "4":
                        DeletePlayer();
                        break;
                    case "5":
                        ShowAllPlayersInfo();
                        break;
                }
            }
        }

        public void AddPlayer()
        {
            Console.WriteLine("Введите имя игрока");
            string name = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока");
            int level = Convert.ToInt32(Console.ReadLine());
            Player player = new Player(_minUnicueNumber, name, level);
            _players.Add(_minUnicueNumber, player);
            _minUnicueNumber++;
            Console.WriteLine("Игрок успешно добавлен");
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока которого хотите забанить");
            int unicueNumber = Convert.ToInt32(Console.ReadLine());

            if (_players.ContainsKey(unicueNumber))
            {
                _players[unicueNumber].Ban();
            }

            Console.WriteLine("Игрок успешно забанен");
        }

        public void UnbanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока которого хотите разбанить");
            int unicueNumber = Convert.ToInt32(Console.ReadLine());

            if (_players.ContainsKey(unicueNumber))
            {
                _players[unicueNumber].Unban();
            }

            Console.WriteLine("Игрок успешно разбанен");
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока которого хотите удалить");
            int unicueNumber = Convert.ToInt32(Console.ReadLine());

            if (_players.ContainsKey(unicueNumber))
            {
                _players.Remove(unicueNumber);
            }

            Console.WriteLine("Игрок успешно удален");
        }

        public void ShowAllPlayersInfo()
        {
            foreach(var player in _players)
            {
                Console.WriteLine("Номер - " + player.Value._unicueNumber);
                Console.WriteLine("Ник - " + player.Value._name);
                Console.WriteLine("Уровень - " + player.Value._level);
                Console.WriteLine("Забанен - " + player.Value._isBan);
                Console.WriteLine();
            }
        }
    }

    class Player
    {
        public int _unicueNumber { get; private set; }
        public string _name { get; private set; }
        public int _level { get; private set; }
        public bool _isBan { get; private set; }

        public Player(int unicueNumber, string name, int level)
        {
            _unicueNumber = unicueNumber;
            _name = name;
            _level = level;
            _isBan = false;
        }

        public void Ban()
        {
            _isBan = true;
        }

        public void Unban()
        {
            _isBan = false;
        }
    }
}

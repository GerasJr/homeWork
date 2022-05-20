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

        private void AddPlayer()
        {
            Console.WriteLine("Введите имя игрока");
            string name = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока");
            string readLevel = Console.ReadLine();

            if(int.TryParse(readLevel, out int level))
            {
                Player player = new Player(_minUnicueNumber, name, level);
                _players.Add(_minUnicueNumber, player);
                _minUnicueNumber++;
                Console.WriteLine("Игрок успешно добавлен");
            }
            else
            {
                Console.WriteLine("Некорректный ввод уровня");
            }
        }

        private void BanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока которого хотите забанить");
            int unicueNumber = Convert.ToInt32(Console.ReadLine());

            if (_players.ContainsKey(unicueNumber))
            {
                _players[unicueNumber].Ban();
            }

            Console.WriteLine("Игрок успешно забанен");
        }

        private void UnbanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока которого хотите разбанить");
            int unicueNumber = Convert.ToInt32(Console.ReadLine());

            if (_players.ContainsKey(unicueNumber))
            {
                _players[unicueNumber].Unban();
            }

            Console.WriteLine("Игрок успешно разбанен");
        }

        private void DeletePlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока которого хотите удалить");
            int unicueNumber = Convert.ToInt32(Console.ReadLine());

            if (_players.ContainsKey(unicueNumber))
            {
                _players.Remove(unicueNumber);
            }

            Console.WriteLine("Игрок успешно удален");
        }

        private void ShowAllPlayersInfo()
        {
            foreach(var player in _players)
            {
                Console.WriteLine("Номер - " + player.Value.UnicueNumber);
                Console.WriteLine("Ник - " + player.Value.Name);
                Console.WriteLine("Уровень - " + player.Value.Level);
                Console.WriteLine("Забанен - " + player.Value.IsBan);
                Console.WriteLine();
            }
        }
    }

    class Player
    {
        public int UnicueNumber { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBan { get; private set; }

        public Player(int unicueNumber, string name, int level)
        {
            UnicueNumber = unicueNumber;
            Name = name;
            Level = level;
            IsBan = false;
        }

        public void Ban()
        {
            IsBan = true;
        }

        public void Unban()
        {
            IsBan = false;
        }
    }
}

using System;
using System.Collections.Generic;

namespace hm41
{
    class HomeWork41
    {
        static void Main(string[] args)
        {
        }
    }

    class Database
    {
        private Dictionary<int, Player> players = new Dictionary<int, Player>();
        private int _minUnicueNumber = 0;

        public void AddPlayer(string name, int level)
        {
            Player player = new Player(_minUnicueNumber, name, level);
            players.Add(_minUnicueNumber, player);
            _minUnicueNumber++;
        }

        public void BanPlayer(int unicueNumber)
        {
            if (players.ContainsKey(unicueNumber))
            {
                players[unicueNumber].IsBan = true;
            }
        }

        public void UnbanPlayer(int unicueNumber)
        {
            if (players.ContainsKey(unicueNumber))
            {
                players[unicueNumber].IsBan = false;
            }
        }

        public void DelitePlayer(int unicueNumber)
        {
            if (players.ContainsKey(unicueNumber))
            {
                players.Remove(unicueNumber);
            }
        }
    }

    class Player
    {
        private int _unicueNumber;
        private string _name;
        private int _level;
        public bool IsBan;


        public Player(int unicueNumber, string name, int level)
        {
            _name = name;
            _level = level;
            IsBan = false;
        }
    }
}

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
        private int _minUnicueNumber = 0;
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void AddPlayer(string name, int level)
        {
            Player player = new Player(_minUnicueNumber, name, level);
            _players.Add(_minUnicueNumber, player);
            _minUnicueNumber++;
        }

        public void BanPlayer(int unicueNumber)
        {
            if (_players.ContainsKey(unicueNumber))
            {
                _players[unicueNumber].Ban();
            }
        }

        public void UnbanPlayer(int unicueNumber)
        {
            if (_players.ContainsKey(unicueNumber))
            {
                _players[unicueNumber].Unban();
            }
        }

        public void DelitePlayer(int unicueNumber)
        {
            if (_players.ContainsKey(unicueNumber))
            {
                _players.Remove(unicueNumber);
            }
        }
    }

    class Player
    {
        private int _unicueNumber;
        private string _name;
        private int _level;
        private bool _isBan;

        public Player(int unicueNumber, string name, int level)
        {
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

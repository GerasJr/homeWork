using System;
using System.Collections.Generic;
using System.Linq;

namespace hm55
{
    class HomeWork55
    {
        static void Main(string[] args)
        {
            Nominator nominator = new Nominator();

            nominator.OutPutPlayers(nominator.NominationByLevel());
            nominator.OutPutPlayers(nominator.NominationByForce());
        }
    }

    class Nominator
    {
        private List<Player> _players = new List<Player>()
        {
            new Player("TERRORISTKA", 15, 35),
            new Player("Lemon4ik", 4, 2),
            new Player("3JIou_4uTeP", 54, 55),
            new Player("CAXAP", 76, 67),
            new Player("molo4ko", 43, 22),
            new Player("АУФ ПАЦАн", 1, 23),
            new Player("Pycckuu M9CHuk", 87, 77),
            new Player("Player35495604", 1, 1),
            new Player("Сын_Маминой_Подруги", 90, 86),
            new Player("Носок судьбы", 45, 29),
        };

        public List<Player> NominationByLevel()
        {
            var nominationPlayers = _players.OrderByDescending(player => player.Level).Take(3);
            return nominationPlayers.ToList();
        }

        public List<Player> NominationByForce()
        {
            var nominationPlayers = _players.OrderByDescending(player => player.Force).Take(3);
            return nominationPlayers.ToList();
        }

        public void OutPutPlayers(List<Player> players)
        {
            for(int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1} Место : {players[i].Name}");
                Console.WriteLine($"{players[i].Level} Уровень. {players[i].Force} Силы");
                Console.WriteLine();
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Force { get; private set; }

        public Player(string name, int level, int force)
        {
            Name = name;
            Level = level;
            Force = force;
        }
    }
}

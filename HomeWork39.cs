using System;

namespace hm39
{
    class HomeWork39
    {
        static void Main(string[] args)
        {
            Player player = new Player("Виталя", 100, 100, "АК-47");
            player.ShowInfo();
        }
    }

    public class Player
    {
        private string _name;
        private int _health;
        private int _armor;
        private string _weapon;

        public Player(string name, int health, int armor, string weapon)
        {
            _name = name;
            _health = health;
            _armor = armor;
            _weapon = weapon;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {_name}\nЗдоровье - {_health}\nБроня - {_armor}\nОружие - {_weapon}");
        }
    }
}

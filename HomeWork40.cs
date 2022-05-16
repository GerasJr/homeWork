using System;

namespace hm40
{
    class HomeWork40
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Renderer renderer = new Renderer();

            renderer.Render(player.PositionX, player.PositionY, player.Symbol);
        }

        public class Player
        {
            public char Symbol { get; private set; } = '@';
            public int PositionX { get; private set; } = 5;
            public int PositionY { get; private set; } = 10;
        }
        
        public class Renderer
        {
            public void Render(int positionX, int positionY, char symbol)
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.WriteLine(symbol);
            }
        }
    }
}

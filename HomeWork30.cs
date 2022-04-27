using System;

namespace hm30
{
    class HomeWork30
    {
        static void Main(string[] args)
        {
            DrawBar('#', 100f);
        }

        static void DrawBar(char symbol, float percent)
        {
            int fullGrid = 10;
            float fullness;

            fullness = percent / 10;
            Console.Write("[");

            for(int i = 0; i < fullGrid; i++)
            {
                if(i < fullness)
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write("_");
                }
            }

            Console.WriteLine("]");
        }
    }
}

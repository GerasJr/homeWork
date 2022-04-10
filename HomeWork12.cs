using System;

namespace y4yc
{
    class HomeWork12
    {
        public static void Main(string[] args)
        {
            int number;
            Random random = new Random();

            number = random.Next(0, 101);

            for(int i = number; i > 0; i--)
            {
                if(i % 3 == 0 || i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

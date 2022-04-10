using System;

namespace y4yc
{
    class HomeWork12
    {
        public static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int multiplicityFive = 5;
            int multiplicityThree = 3;
            int amount = 0;

            for(int i = randomNumber.Next(0, 101); i > 0; i--)
            {
                if(i % multiplicityThree == 0 || i % multiplicityFive == 0)
                {
                    amount += i;
                }
            }

            Console.WriteLine(amount);
        }
    }
}

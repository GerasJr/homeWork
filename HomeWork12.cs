using System;

namespace y4yc
{
    class HomeWork12
    {
        public static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int multiplicity0 = 5;
            int multiplicity1 = 3;
            int minValue = 0;
            int maxValue = 101;
            int amount = 0;

            for(int i = randomNumber.Next(minValue, maxValue); i > 0; i--)
            {
                if(i % multiplicity1 == 0 || i % multiplicity0 == 0)
                {
                    amount += i;
                }
            }

            Console.WriteLine(amount);
        }
    }
}

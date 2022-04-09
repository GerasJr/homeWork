using System;

namespace _12667
{
    class HomeWork11
    {
        static void Main(string[] args)
        {
            int number = 5;
            int finishNumber = 96;
            int numberRise = 7;

            Console.WriteLine(number);

            for(number; number != finishNumber; number += numberRise)
            {
                Console.WriteLine(number);
            }
        }
    }
}
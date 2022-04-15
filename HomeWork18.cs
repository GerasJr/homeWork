using System;

namespace hm
{
    class HomeWork18
    {
        static void Main(string[] args)
        {
            int erectedNumber = 2;
            int number;
            int minNumber = 0;
            int maxNumber = 1000;
            int raisedNumber = 0;
            int degree = 1;
            int defaultDegree = 1;
            Random randomNumber = new Random();

            number = randomNumber.Next(minNumber, maxNumber);
            
            while(number > raisedNumber)
            {
                raisedNumber = erectedNumber;
                degree++;

                for(int i = defaultDegree; i < degree; i++)
                {
                    raisedNumber *= erectedNumber;
                }
            }

            Console.WriteLine($"Число - {number}, степень - {degree}, возведенная двойка в степень {degree} = {raisedNumber}");
            Console.WriteLine($"{raisedNumber} > {number}");
        }
    }
}

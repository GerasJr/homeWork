using System;

namespace hm17
{
    class HomeWork17
    {
        static void Main(string[] args)
        {
            int numberN;
            int numbersMultiplesN;
            int minRangeN = 1;
            int maxRangeN = 27;
            int maxValue = 1000;
            int minValue = 100;
            int multiplesAmount = 0;
            Random rangeOfN = new Random();
            
            numberN = rangeOfN.Next(minRangeN, maxRangeN);
            numbersMultiplesN = numberN;

            for(int i = numberN; i <= maxValue; i++)
            {
                numbersMultiplesN += numberN;

                if(numbersMultiplesN >= minValue && numbersMultiplesN <= maxValue)
                {
                    multiplesAmount++;
                }
            }
            Console.WriteLine(multiplesAmount);
        }
    }
}

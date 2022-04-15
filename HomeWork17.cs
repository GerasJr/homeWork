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
            int maxThreeDigit = 999;
            int minThreeDigit = 100;
            Random rangeOfN = new Random();

            numberN = rangeOfN.Next(minRangeN, maxRangeN);
            numbersMultiplesN = numberN;

            for(int i = numberN; i <= maxThreeDigit; i++)
            {
                numbersMultiplesN += numberN;

                if(numbersMultiplesN >= minThreeDigit && numbersMultiplesN <= maxThreeDigit)
                {
                    Console.WriteLine(numbersMultiplesN);
                }
            }
        }
    }
}

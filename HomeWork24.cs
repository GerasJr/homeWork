using System;

namespace hm24
{
    class HomeWork24
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];
            int[] tempNumbers = new int[0];
            bool isCalculation = true;
            string userInput;
            int amount = 0;

            while (isCalculation)
            {
                userInput = Console.ReadLine();

                if(userInput != "sum" && userInput != "exit")
                {
                    tempNumbers = new int[numbers.Length + 1];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    tempNumbers[tempNumbers.Length - 1] = Convert.ToInt32(userInput);
                    numbers = tempNumbers;
                }
                else if(userInput == "sum")
                {
                    for(int i = 0; i < numbers.Length; i++)
                    {
                        amount += numbers[i];
                    }

                    Console.WriteLine(amount);
                    isCalculation = false;
                }
                else if(userInput == "exit")
                {
                    isCalculation = false;
                }
            }
        }
    }
}

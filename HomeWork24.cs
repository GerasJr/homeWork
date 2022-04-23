using System;

namespace hm24
{
    class HomeWork24
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];
            bool isWork = true;
            string userInput;

            while (isWork)
            {
                userInput = Console.ReadLine();

                if(userInput == "sum")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        sum += numbers[i];
                    }

                    Console.WriteLine(sum);
                    isWork = false;
                }
                else if(userInput == "exit")
                {
                    isWork = false;
                }
                else
                {
                    int[] tempNumbers = new int[numbers.Length + 1];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    tempNumbers[tempNumbers.Length - 1] = Convert.ToInt32(userInput);
                    numbers = tempNumbers;
                }
            }
        }
    }
}

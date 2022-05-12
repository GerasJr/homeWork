using System;
using System.Collections.Generic;

namespace hm36
{
    class HomeWork36
    {
        static void Main(string[] args)
        {
            string userInput = "";
            bool isWork = true;
            List<int> numbers = new List<int>();

            Console.WriteLine("Вводите числа через Enter");
            Console.WriteLine("Что бы посчитать сумму всех чисел введите sum");
            Console.WriteLine("Для выхода из программы введите exit");

            while (isWork == true)
            {
                userInput = Console.ReadLine();

                if(userInput == "sum")
                {
                    int sum = 0;

                    foreach(var number in numbers)
                    {
                        sum += number;
                    }

                    Console.WriteLine(sum);
                    numbers.Clear();
                }
                else if(userInput == "exit")
                {
                    isWork = false;
                }
                else
                {
                    if(int.TryParse(userInput, out int number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Число или команда некорректны");
                    }
                }
            }
        }
    }
}

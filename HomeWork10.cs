using System;

namespace HomeWork_10
{
    class HomeWork10
    {
        static void Main(string[] args)
        {
            int cycleNumber = 0;
            string stopWord = "exit";
            string userInput;

            while (userInput != stopWord)
            {
                ++cycleNumber;
                Console.WriteLine($"Цикл - {cycleNumber}, что бы остановить цикл введите *{stopWord}*");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("Цикл завершен");
        }
    }
}

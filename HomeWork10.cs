using System;

namespace HomeWork_10
{
    class HomeWork10
    {
        static void Main(string[] args)
        {
            int cycleNumber = 0;
            string stopWord = "0";

            while (stopWord != "exit")
            {
                ++cycleNumber;
                Console.WriteLine($"Цикл - {cycleNumber}, что бы остановить цикл введите *exit*");
                stopWord = Console.ReadLine();
            }
            Console.WriteLine("Цикл завершен");
        }
    }
}

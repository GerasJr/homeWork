using System;

namespace _2222
{
    class HomeWork14
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            string command;
            int minValue = 0;
            int maxValue = 1000000000;

            Console.WriteLine("Добро пожаловать в консоль");
            Console.WriteLine("Для получения списка всех команд введите help");
            Console.WriteLine("Для завершения работы консоли введите break");

            while (isWorking)
            {
                command = Console.ReadLine();

                if(command == "help")
                {
                    Console.WriteLine("consoleClear - Очистка консоли");
                    Console.WriteLine("createCycle - Создать цикл");
                    Console.WriteLine($"randomNumber - Создать случайное целое число (от {minValue} до {maxValue})");
                    Console.WriteLine("fckYou - Послать консоль куда подальше");
                    Console.WriteLine("help - Список всех команд");
                    Console.WriteLine("break - Завершить работу консоли");
                }
                else if(command == "consoleClear")
                {
                    Console.Clear();
                }
                else if(command == "createCycle")
                {
                    string userMassage;
                    int userAmount;

                    Console.WriteLine("Введите сообщение которое хотите вывести");
                    userMassage = Console.ReadLine();
                    Console.WriteLine("Введите сколько раз вы хотите вывести сообщение");
                    userAmount = Convert.ToInt32(Console.ReadLine());

                    for(int i = 0; i < userAmount; i++)
                    {
                        Console.WriteLine(userMassage);
                    }
                }
                else if(command == "randomNumber")
                {
                    int number;
                    Random random = new Random();
                    number = random.Next(minValue, maxValue);
                    Console.WriteLine(number);
                }
                else if(command == "fckYou" || command == "fuckYou")
                {
                    int consolePunishment = 100000;

                    for (int i = 0; i < consolePunishment; i++)
                    {
                        Console.WriteLine("Сам иди");
                    }
                }
                else if(command == "break")
                {
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Такой команды нет ^_^");
                }
            }
        }
    }
}

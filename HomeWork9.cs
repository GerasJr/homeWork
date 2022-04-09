using System;

namespace cycle
{
    class HomeWork9
    {
        static void Main(string[] args)
        {
            string userMassage;
            int cycleCount;

            Console.Write("Введите сообщение которое хотите вывести: ");
            userMassage = Console.ReadLine();
            Console.Write("Введите сколько хотите вывести сообщений: ");
            cycleCount = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < cycleCount; i++)
            {
                Console.WriteLine(userMassage);
            }
        }
    }
}

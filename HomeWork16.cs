using System;

namespace ea_dz
{
    class HomeWork16
    {
        static void Main(string[] args)
        {
            string password = "Купил мужик шляпу а она ему как раз";
            string userInput = "";
            int trys = 3;

            Console.WriteLine("Введите пароль");

            while (trys > 0 && userInput != password)
            {
                Console.WriteLine("У вас " + trys + " попытки(ка)");
                userInput = Console.ReadLine();

                if(userInput == password)
                {
                    Console.WriteLine("Купил вторую а она ему как два");
                }
                else
                {
                    Console.WriteLine("Пароль не правильный");
                    trys--;
                }
            }
        }
    }
}

using System;

namespace еааа
{
    class HomeWork15
    {
        static void Main(string[] args)
        {
            string userName;
            char userSymbol;
            int additionalSymbols = 2;
            string userSymblols;

            Console.WriteLine("Введите ваше имя");
            userName = Console.ReadLine();
            Console.WriteLine("Введите символ");
            userSymbol = Convert.ToChar(Console.ReadLine());
            userSymblols = new string(userSymbol, userName.Length + additionalSymbols);
            Console.WriteLine(userSymblols);
            Console.WriteLine(userSymbol + userName + userSymbol);
            Console.WriteLine(userSymblols);
        }
    }
}

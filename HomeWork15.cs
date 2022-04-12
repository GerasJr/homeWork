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

            Console.WriteLine("Введите ваше имя");
            userName = Console.ReadLine();
            Console.WriteLine("Введите символ");
            userSymbol = Convert.ToChar(Console.ReadLine());
            
            for(int i = 0; i < userName.Length + additionalSymbols; i++)
            {
                Console.Write(userSymbol);
            }

            Console.WriteLine("\n" + userSymbol + userName + userSymbol);

            for (int i = 0; i < userName.Length + additionalSymbols; i++)
            {
                Console.Write(userSymbol);
            }
        }
    }
}

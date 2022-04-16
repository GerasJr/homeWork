using System;

namespace hm19
{
    class HomeWork19
    {
        static void Main(string[] args)
        {
            string userText;
            int bracketsToClose = 0;
            int leftMaxBrackets = 0;
            int rightMaxBrackets = 0;
            int maxDeep = 0;

            Console.WriteLine("Введите скобочки:");
            userText = Console.ReadLine();

            foreach(var symbol in userText)
            {
                if(symbol == '(')
                {
                    bracketsToClose++;
                    leftMaxBrackets++;

                    if(maxDeep <= leftMaxBrackets)
                    {
                        maxDeep = leftMaxBrackets;
                        rightMaxBrackets = 0;
                    }
                }

                if(symbol == ')')
                {
                    if(bracketsToClose > 0)
                    {
                        bracketsToClose--;
                    }

                    rightMaxBrackets++;

                    if(maxDeep <= rightMaxBrackets)
                    {
                        maxDeep = rightMaxBrackets;
                        leftMaxBrackets = 0;
                    }
                }
            }

            if(bracketsToClose == 0)
            {
                Console.Write("Строка корректна, ");
            }
            else
            {
                Console.Write("Строка не корректна, ");
            }

            Console.Write($"максимальная глубина скобок - {maxDeep}");
        }
    }
}

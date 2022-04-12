using System;

namespace ConsoleApp2
{
    class HomeWork13
    {
        static void Main(string[] args)
        {
            float rub = 10000;
            float usd = 500;
            float eur = 500;
            float usdToRub = 79.16f;
            float rubToUsd = 0.012f;
            float usdToEur = 0.91f;
            float eurToUsd = 1.09f;
            float eurToRub = 85.98f;
            float rubToEur = 0.011f;
            float convertAmount;
            int userInput;
            bool isTrade = true;

            Console.WriteLine("Добро пожаловать в конвертер валют.");

            while (isTrade)
            {
                Console.WriteLine($"У вас на балансе {rub} рублей, {usd} долларов, и {eur} евро");
                Console.WriteLine("Выберете вид конвертации:");
                Console.WriteLine("1 - Доллар в рубль, 2 - Доллар в евро");
                Console.WriteLine("3 - Евро в рубль 4 - Евро в доллар");
                Console.WriteLine("5 - Рубль в доллар, 6 - Рубль в евро");
                Console.WriteLine("7 - Выйти из конвертера");
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Выберете сумму конвертации (Той валюты которая конвертируется)");
                convertAmount = Convert.ToSingle(Console.ReadLine());

                switch (userInput)
                {
                    case 1:

                        if (usd < convertAmount)
                        {
                            Console.WriteLine("У вас нету столько долларов");
                            break;
                        }

                        rub = rub + usdToRub * convertAmount;
                        usd -= convertAmount;
                        break;
                    case 2:

                        if (usd < convertAmount)
                        {
                            Console.WriteLine("У вас нету столько долларов");
                            break;
                        }

                        eur = eur + usdToEur * convertAmount;
                        usd -= convertAmount;
                        break;
                    case 3:

                        if(eur < convertAmount)
                        {
                            Console.WriteLine("У вас нету столько евро");
                            break;
                        }

                        rub = rub + eurToRub * convertAmount;
                        eur -= convertAmount;
                        break;
                    case 4:

                        if (eur < convertAmount)
                        {
                            Console.WriteLine("У вас нету столько евро");
                            break;
                        }

                        usd = usd + eurToUsd * convertAmount;
                        eur -= convertAmount;
                        break;
                    case 5:

                        if(rub < convertAmount)
                        {
                            Console.WriteLine("У вас нету столько рублей");
                            break;
                        }

                        usd = usd + rubToUsd * convertAmount;
                        rub -= convertAmount;
                        break;
                    case 6:

                        if (rub < convertAmount)
                        {
                            Console.WriteLine("У вас нету столько рублей");
                            break;
                        }

                        eur = eur + rubToEur * convertAmount;
                        rub -= convertAmount;
                        break;
                    case 7:
                        Console.WriteLine("Вы вышли из конвертера");
                        isTrade = false;
                        break;
                }
            }
        }
    }
}

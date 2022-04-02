using System;

namespace magaz
{
    class HomeWork7
    {
        public static void Main(string[] args)
        {
            int gold = 5000;
            int crystals = 5;
            int buyRate = 150;
            int saleRate = 140;
            int confirmationButton = 0;

            Console.WriteLine("Здесь вы можете купить или продать кристалы за золотые монеты.");

            while (true)
            {
                Console.WriteLine("У вас " + gold + " золота и " + crystals + " кристалов.");
                Console.WriteLine("Курс покупки - " + buyRate + ", продажи - " + saleRate);
                Console.WriteLine("Что бы купить кристалы введите 1");
                Console.WriteLine("Что бы продать введите 2");
                confirmationButton = Convert.ToInt32(Console.ReadLine());

                if (confirmationButton == 1)
                {
                    Console.WriteLine("Введите число кристалов которое вы хотите приобрести");
                    int buyCount = Convert.ToInt32(Console.ReadLine());
                    int price = buyCount * buyRate;
                    Console.WriteLine("Вы хотите купить " + buyCount + " кристалов");
                    Console.WriteLine("Это будет стоить " + price + " золотых монет");
                    Console.WriteLine("Для подтверждения введите 1");
                    Console.WriteLine("Для отказа введите 2");
                    confirmationButton = Convert.ToInt32(Console.ReadLine());

                    if (confirmationButton == 1 && gold >= price)
                    {
                        gold = gold - price;
                        crystals = crystals + buyCount;
                        Return();
                    }
                    else
                    {
                        Console.WriteLine("У вас нет столько золота");
                        Return();
                    }
                    if (confirmationButton == 2)
                    {
                        Return();
                    }
                }
                if (confirmationButton == 2)
                {
                    Console.WriteLine("Введите число кристалов которое вы хотите продать");
                    int saleCount = Convert.ToInt32(Console.ReadLine());
                    int profitCount = saleCount * saleRate;
                    Console.WriteLine("Вы хотите продать " + saleCount + " кристалов");
                    Console.WriteLine("Вы получите " + profitCount + " золотых монет");
                    Console.WriteLine("Для подтверждения введите 1");
                    Console.WriteLine("Для отказа введите 2");
                    confirmationButton = Convert.ToInt32(Console.ReadLine());

                    if(confirmationButton == 1 && crystals >= saleCount)
                    {
                        crystals = crystals - saleCount;
                        gold = gold + profitCount;
                        Return();
                    }
                    else
                    {
                        Console.WriteLine("У вас нет столько кристалов");
                        Return();
                    }
                }
            }

            void Return()
            {
                confirmationButton = 0;
            }
        }
    }   
}

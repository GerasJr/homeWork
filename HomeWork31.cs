using System;

namespace hm31
{
    class HomeWork31
    {
        static void Main(string[] args)
        {
            ReadInt();
        }

        static int ReadInt()
        {
            bool isSuccess = false;
            int result = 0;

            while (isSuccess == false)
            {
                Console.WriteLine("Введите число которое хотите сконвертировать");
                string userInput = Console.ReadLine();
                isSuccess = int.TryParse(userInput, out result);

                if(isSuccess == false)
                {
                    Console.WriteLine("Конвертация не удалась");
                }
            }

            Console.WriteLine($"Вы удачно сконвертировали число в int ({result})");
            return result;
        }
    }
}

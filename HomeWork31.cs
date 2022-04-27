using System;

namespace hm31
{
    class HomeWork31
    {
        static void Main(string[] args)
        {
            Conversion();
        }

        static int Conversion()
        {
            bool success = false;
            int result = 0;

            while (success == false)
            {
                Console.WriteLine("Введите число которое хотите сконвертировать");
                string number = Console.ReadLine();
                success = int.TryParse(number, out result);

                if(success == false)
                {
                    Console.WriteLine("Конвертация не удалась");
                }
            }

            Console.WriteLine($"Вы удачно сконвертировали число в int ({result})");
            return result;
        }
    }
}

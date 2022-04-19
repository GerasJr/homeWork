using System;

namespace hm21
{
    class HomeWork21
    {
        static void Main(string[] args)
        {
            int[,] array = { {5, 75, 18, 3}, {83, 2, 4, 34 } };
            int secondPostAmount = 0;
            int firstPostMultiply = 1;
            
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            for(int i = 0; i < array.GetLength(1); i++)
            {
                secondPostAmount += array[1, i];
            }

            Console.WriteLine("Сумма второго столбца: " + secondPostAmount);

            for(int i = 0; i < array.GetLength(1); i++)
            {
                firstPostMultiply *= array[0, i];
            }

            Console.WriteLine("Произведение первого столбца: " + firstPostMultiply);
        }
    }
}

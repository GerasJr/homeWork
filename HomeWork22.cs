using System;

namespace hm22
{
    class HomeWork22
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            int largestArray = 0;
            Random random = new Random();
            int minValue = 0;
            int maxValue = 101;

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minValue, maxValue);
                    Console.Write(array[i, j] + ", ");

                    if(array[i, j] > largestArray)
                    {
                        largestArray = array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\n{largestArray}\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i, j] == largestArray)
                    {
                        array[i, j] = 0;
                    }

                    Console.Write(array[i, j] + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}

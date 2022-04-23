using System;

namespace hm26
{
    class HomeWork26
    {
        static void Main(string[] args)
        {
            int[] array = new int[15];

            for(int i = 0; i < array.Length; i++)
            {
                Random random = new Random();
                int minValue = 0;
                int maxValue = 100;
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for(int i = 0; i < array.Length; i++)
            {
                int variableSwapper;

                for (int j = 0; j < array.Length - 1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        variableSwapper = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = variableSwapper;
                    }
                }
            }

            foreach(int number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}

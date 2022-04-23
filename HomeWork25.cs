using System;

namespace hm25
{
    class HomeWork25
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            int repeatNumber = 0;
            int repeatAmount = 0;
            int largestRepeat = 0;
            int largestNumberRepeat = 0;
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                int minValue = 0;
                int maxValue = 10;
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    repeatNumber = array[i];
                    repeatAmount++;

                    if (largestRepeat < repeatAmount)
                    {
                        largestRepeat = repeatAmount;
                        largestNumberRepeat = repeatNumber;
                    }
                }
                else
                {
                    repeatAmount = 0;
                }
            }

            Console.WriteLine($"Самый длинный подмассив из одинаковых чисел - {largestNumberRepeat}, кол-во повторений - {largestRepeat}");
        }
    }
}

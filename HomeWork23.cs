using System;

namespace hm_23
{
    class HomeWork23
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            int previousElement;
            int nextElement;
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, array.Length);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Локальные максимумы:");

            for(int i = 1; i < array.Length - 1; i++)
            {
                previousElement = array[i - 1];
                nextElement = array[i + 1];

                if(previousElement < array[i] && array[i] > nextElement)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}

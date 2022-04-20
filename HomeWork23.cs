using System;

namespace hm_23
{
    class HomeWork23
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            int leftElement;
            int rightElement;
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, array.Length);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Локальные максимумы:");

            for(int i = 0; i < array.Length; i++)
            {
                if(i == 0 || i == array.Length - 1)
                {
                    continue;
                }

                leftElement = array[i - 1];
                rightElement = array[i + 1];

                if(leftElement < array[i] && rightElement < array[i])
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}

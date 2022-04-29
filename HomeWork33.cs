using System;

namespace hm33
{
    class HomeWork33
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            Shuffle(array);

            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                int randomIndex = random.Next(0, array.Length);
                int tempNumber;

                tempNumber = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = tempNumber;
            }
        }
    }
}

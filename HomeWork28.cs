using System;

namespace hm28
{
    class HomeWork28
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            int userInput;

            Console.WriteLine("Введите кол-во позиций.");
            userInput = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < userInput; i++)
            {
                int transferVariable = array[0];

                for(int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = transferVariable;
            }

            foreach(int number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}

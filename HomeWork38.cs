using System;
using System.Collections.Generic;

namespace hm38
{
    class HomeWork38
    {
        static void Main(string[] args)
        {
            string[] firstArray = new string[] {"1", "2", "4", "5"};
            string[] secondArray = new string[] { "3", "2", "2", "6", "1"};
            List<string> list = new List<string>();

            EntryWithoutRepeat(list, firstArray);
            EntryWithoutRepeat(list, secondArray);

            foreach (var index in list)
            {
                Console.Write(index + " ");
            }
        }

        static void EntryWithoutRepeat(List<string> list, string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool isRepeat = false;

                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] == array[i])
                    {
                        isRepeat = true;
                    }
                }

                if (isRepeat == false)
                {
                    list.Add(array[i]);
                }
            }
        }
    }
}

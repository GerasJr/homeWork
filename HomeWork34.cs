using System;
using System.Collections.Generic;

namespace hm34
{
    class HomeWork34
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            bool isWorking = true;

            dictionary.Add("Сталкер", "Человек, обладающий знанием территорий или сооружений");
            dictionary.Add("Человек", "Представитель млекопитающих рода Homo отряда приматов, в узком смысле — вида Homo sapiens");
            dictionary.Add("Нелюдь", "Плохой, дурной человек ");
            dictionary.Add("Программист", "Разработчик программного обеспечения");
            dictionary.Add("Юрист", "Специалист по правоведению, юридическим наукам");

            while (isWorking)
            {
                Console.WriteLine("Введите слово:");
                string userInput = Console.ReadLine();

                if (dictionary.ContainsKey(userInput))
                {
                    Console.WriteLine(dictionary[userInput] + "\n");
                }
                else
                {
                    Console.WriteLine("Такого слова нет(\n");
                }
            }
        }
    }
}

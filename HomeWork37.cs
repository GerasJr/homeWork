using System;
using System.Collections.Generic;

namespace hm37
{
    class HomeWork37
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            bool isWork = true;

            Console.WriteLine("1 - Добавить досье");
            Console.WriteLine("2 - Вывести все досье");
            Console.WriteLine("3 - Удалить досье");
            Console.WriteLine("4 - Выход");

            while (isWork)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите ФИО, потом через Enter должность");
                        dossiers.Add(Console.ReadLine(), Console.ReadLine());
                        Console.WriteLine("Досье успешно добавлено");
                        break;
                    case "2":
                        foreach(var dossier in dossiers)
                        {
                            Console.WriteLine(dossier.Key + " - " + dossier.Value);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите ФИО досье которого хотите удалить");
                        string userInput = Console.ReadLine();

                        if (dossiers.ContainsKey(userInput))
                        {
                            dossiers.Remove(userInput);
                            Console.WriteLine("Досье успешно удалено");
                        }
                        else
                        {
                            Console.WriteLine("Такого досье не найдено");
                        }
                        break;
                    case "4":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Некорректная команда");
                        break;
                }
            }
        }
    }
}

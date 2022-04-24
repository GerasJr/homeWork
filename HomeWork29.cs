using System;

namespace hm29
{
    class HomeWork29
    {
        static void Main(string[] args)
        {
            string[] fullName = new string[0];
            string[] post = new string[0];
            bool isWork = true;

            Console.WriteLine("1 - Добавить досье");
            Console.WriteLine("2 - Вывести все досье");
            Console.WriteLine("3 - Удалить досье");
            Console.WriteLine("4 - Поиск досье по фамилии");
            Console.WriteLine("5 - Выход");

            while (isWork)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        AddDossier(ref fullName, ref post);
                        break;
                    case "2":
                        ConclusionDossier(fullName, post);
                        break;
                    case "3":
                        DeleteDossier(ref fullName, ref post);
                        break;
                    case "4":
                        FindDossier(fullName, post);
                        break;
                    case "5":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullName, ref string[] post)
        {
            DossierArrayAdd(ref fullName, "Введите ФИО");
            DossierArrayAdd(ref post, "Введите должность");
            Console.WriteLine("Досье успешно добавлено.");
        }

        static void DossierArrayAdd(ref string[] array, string WriteLine)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            Console.WriteLine(WriteLine);
            tempArray[tempArray.Length - 1] = Console.ReadLine();
            array = tempArray;
        }

        static void ConclusionDossier(string[] fullName, string[] post)
        {
            Console.WriteLine("Все досье:");

            for(int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {fullName[i]} - {post[i]}");
            }
        }

        static void DeleteDossier(ref string[] fullName, ref string[] post)
        {
            Console.WriteLine("Введите номер досье которого хотите удалить");
            int numberToDelete = Convert.ToInt32(Console.ReadLine()) - 1;

            if(numberToDelete < fullName.Length)
            {
                DossierArrayDelete(ref fullName, numberToDelete);
                DossierArrayDelete(ref post, numberToDelete);
                Console.WriteLine($"Досье под номером {numberToDelete + 1} удалено.");
            }
            else
            {
                Console.WriteLine("Такого досье не найдено");
            }
        }

        static void DossierArrayDelete(ref string[] array, int numberToDelete)
        {
            string[] tempArray = new string[array.Length - 1];

            for(int i = 0; i < array.Length - 1; i++)
            {
                if(i < numberToDelete)
                {
                    tempArray[i] = array[i];
                }
                else
                {
                    tempArray[i] = array[i + 1];
                }
            }

            array = tempArray;
        }

        static void FindDossier(string[] fullName, string[] post)
        {
            string findSurname;
            bool isFind = false;

            Console.WriteLine("Введите Фамилию:");
            findSurname = Console.ReadLine();

            for(int i = 0; i < fullName.Length; i++)
            {
                string[] arrayFullName = fullName[i].Split(' ');

                foreach(string name in arrayFullName)
                {
                    if (name == findSurname)
                    {
                        Console.WriteLine($"Найдено досье под номером {i + 1}: {fullName[i]} - {post[i]}");
                        isFind = true;
                    }
                }
            }

            if(isFind == false)
            {
                Console.WriteLine("Таких досье не найдено");
            }
        }
    }
}

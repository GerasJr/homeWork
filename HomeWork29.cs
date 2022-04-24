using System;

namespace hm29
{
    class HomeWork29
    {
        static void Main(string[] args)
        {
            string[] surname = new string[0];
            string[] post = new string[0];
            bool isWork = true;

            Console.WriteLine("1 - Добавить досье");
            Console.WriteLine("2 - Вывести все досье");
            Console.WriteLine("3 - Удалить досье");
            Console.WriteLine("4 - Поиск досье по фамилии");
            Console.WriteLine("5 - Выход");

            while (isWork)
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddDossier(ref surname, ref post);
                        break;
                    case 2:
                        ConclusionDossier(surname, post);
                        break;
                    case 3:
                        DeliteDossier(ref surname, ref post);
                        break;
                    case 4:
                        FindDossier(surname, post);
                        break;
                    case 5:
                        isWork = false;
                        break;
                }
            }
        }

        static void AddDossier(ref string[] surname, ref string[] post)
        {
            string[] tempSurname = new string[surname.Length + 1];
            string[] tempPost = new string[post.Length + 1];

            for(int i = 0; i < surname.Length; i++)
            {
                tempSurname[i] = surname[i];
                tempPost[i] = post[i];
            }

            Console.WriteLine("Введите фамилию");
            tempSurname[tempSurname.Length - 1] = Console.ReadLine();
            Console.WriteLine("Введите должность:");
            tempPost[tempPost.Length - 1] = Console.ReadLine();
            surname = tempSurname;
            post = tempPost;
            Console.WriteLine("Досье успешно добавлено.");
        }

        static void ConclusionDossier(string[] surname, string[] post)
        {
            Console.WriteLine("Все досье:");

            for(int i = 0; i < surname.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {surname[i]} - {post[i]}");
            }
        }

        static void DeliteDossier(ref string[] surname, ref string[] post)
        {
            string[] tempSurname = new string[surname.Length - 1];
            string[] tempPost = new string[post.Length - 1];

            Console.WriteLine("Введите номер досье которого хотите удалить");
            int numberToDelite = Convert.ToInt32(Console.ReadLine()) - 1;

            if(numberToDelite < surname.Length)
            {
                for (int i = 0; i < surname.Length - 1; i++)
                {
                    if(i < numberToDelite)
                    {
                        tempSurname[i] = surname[i];
                        tempPost[i] = post[i];
                    }
                    else
                    {
                        tempSurname[i] = surname[i + 1];
                        tempPost[i] = post[i + 1];
                    }
                }

                Console.WriteLine($"Досье под номером {numberToDelite + 1} ({surname[numberToDelite]} - {post[numberToDelite]}) удалено.");
                surname = tempSurname;
                post = tempPost;
            }
            else
            {
                Console.WriteLine("Такого досье не найдено");
            }
        }

        static void FindDossier(string[] surname, string[] post)
        {
            string findSurname;
            bool isFind = true;

            Console.WriteLine("Введите Фамилию:");
            findSurname = Console.ReadLine();

            for(int i = 0; i < surname.Length; i++)
            {
                if(surname[i] == findSurname)
                {
                    Console.WriteLine($"Найдено досье под номером {i + 1}: {surname[i]} - {post[i]}");
                    isFind = true;
                    break;
                }
            }

            if(!isFind)
            {

            }
        }
    }
}

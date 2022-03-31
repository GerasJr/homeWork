using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class HomeWork3
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            int maxBabyAge = 5;
            string home;

            Console.WriteLine("Как вас зовут?");
            name = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Где вы живете?");
            home = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Вы " + name + ".");

            if(age == 1)
            {
                Console.WriteLine("Вам " + age + " год, и вы живете " + home);
            }
            else if(age > 1 && age < maxBabyAge)
            {
                Console.WriteLine("Вам " + age + " года, и вы живете " + home);
            }
            else
            {
                Console.WriteLine("Вам " + age + " лет, и вы живете " + home);
            }
        }
    }
}

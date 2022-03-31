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
            int years;
            string place;

            Console.WriteLine("Как вас зовут?");
            name = Console.ReadLine();

            Console.WriteLine("Сколько вам лет?");
            years = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Где вы живете?");
            place = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Вы " + name + ".");
            if(years == 1)
            {
                Console.WriteLine("Вам " + years + " год, и вы живете " + place);
            }
            else if(years > 1 && years < 5)
            {
                Console.WriteLine("Вам " + years + " года, и вы живете " + place);
            }
            else
            {
                Console.WriteLine("Вам " + years + " лет, и вы живете " + place);
            }
        }
    }
}

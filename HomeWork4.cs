using System;

namespace HomeWork4
{
    class HomeWork4
    {
        static void Main(string[] args)
        {
            string name = "Василев";
            string secondName = "Ваня";

            Console.WriteLine("Имя: " + name + " Фамилия: " + secondName);
            var nameChange = name;
            name = secondName;
            secondName = nameChange;
            Console.WriteLine("Имя: " + name + " Фамилия: " + secondName);
        }
    }
}

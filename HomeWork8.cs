using System;

namespace учусь
{
    class HomeWork8
    {
        static void Main(string[] args)
        {
            int grannys;
            int receptionTime = 10;
            int minutesToWait;
            int hoursToWait;
            int minutesInHour = 60;

            Console.WriteLine("Введите кол-во старушек");
            grannys = Convert.ToInt32(Console.ReadLine());
            minutesToWait = grannys * receptionTime;
            hoursToWait = minutesToWait / minutesInHour;
            minutesToWait = minutesToWait - hoursToWait * minutesInHour;
            Console.WriteLine("Вам нужно ждать " + hoursToWait + " час(а/ов) и " + minutesToWait + " минут.");
        }
    }
}

using System;
using System.Collections.Generic;

namespace hm35
{
    class HomeWork35
    {
        static void Main(string[] args)
        {
            Queue<int> clients = new Queue<int>();
            int score = 0;

            clients.Enqueue(567);
            clients.Enqueue(1045);
            clients.Enqueue(24);
            clients.Enqueue(322);
            clients.Enqueue(2459);
            clients.Enqueue(99);

            while (clients.Count > 0)
            {
                Console.WriteLine("Следующий клиент с покупкой на сумму - " + clients.Peek());
                Console.WriteLine("Что бы обслужить клиента нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                score += clients.Dequeue();
                Console.WriteLine("Ваш счет составляет - " + score);
            }

            Console.WriteLine("Вы обслужили всех клиентов");
        }
    }
}

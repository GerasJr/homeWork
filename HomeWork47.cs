﻿using System;
using System.Collections.Generic;

namespace hm47
{
    class HomeWork47
    {
        static void Main(string[] args)
        {
            CashDesk cashDesk = new CashDesk();

            cashDesk.Work();
        }
    }

    class CashDesk
    {
        private Queue<Client> _clients = new Queue<Client>();
        private int _clientsAmount = 10;

        public CashDesk()
        {
            for(int i = 0; i < _clientsAmount; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        public void Work()
        {
            Console.WriteLine("Нажимайте Enter что бы обслужить клиента");

            while (_clients.Count > 0)
            {
                Console.ReadLine();

                if (_clients.Peek().CalculateProducts() < _clients.Peek().Money)
                {
                    Console.WriteLine("Клиент обслужен");
                    Console.WriteLine($"Он купил товары на сумму в {_clients.Peek().CalculateProducts()} рублей (При себе имел {_clients.Peek().Money} рублей)");
                    _clients.Dequeue();
                    Console.WriteLine($"Осталось {_clients.Count} клиентов");
                }
                else
                {
                    Console.WriteLine("Не хватает денег на оплату");
                    Console.WriteLine($"Стоимость всех товаров {_clients.Peek().CalculateProducts()}");
                    _clients.Peek().DeleteProduct();
                }

                Console.WriteLine();
            }

            Console.WriteLine("Все клиенты успешно обслужены");
        }
    }

    class Client
    {
        private List<int> _products = new List<int>(); // Каждый продукт хранит в себе их int стоимость.
        public int Money { get; private set; }

        public Client()
        {
            Random random = new Random();
            int minMoney = 3000;
            int maxMoney = 15000;
            int maxCost = 5000;
            int maxProducts = 15;

            Money = random.Next(minMoney, maxMoney);

            for(int i = 0; i < random.Next(0, maxProducts); i++)
            {
                _products.Add(random.Next(0, maxCost));
            }
        }

        public int CalculateProducts()
        {
            int productsCost = 0;

            foreach(int product in _products)
            {
                productsCost += product;
            }

            return productsCost;
        }

        public void DeleteProduct()
        {
            Random random = new Random();

            _products.RemoveAt(random.Next(0, _products.Count));
        }
    }
}

using System;
using System.Collections.Generic;

namespace hm44
{
    class HomeWork44
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Trade(true);
        }
    }

    class Player
    {
        private Seller _seller = new Seller();
        private List<Product> _products = new List<Product>();
        private int _money = 1000;

        public void Trade(bool isTrade)
        {
            Console.WriteLine("Выберете товар который хотите купить");
            Console.WriteLine("Показать товары - show");
            Console.WriteLine("Посмотреть свои вещи - myInv");

            while (isTrade)
            {
                Console.WriteLine("Ваши деньги - " + _money);
                Console.WriteLine();
                string readInput = Console.ReadLine();

                if (int.TryParse(readInput, out int productIndex))
                {
                    _products.Add(_seller.SellProduct(productIndex, ref _money));
                }
                else if(readInput == "show")
                {
                    _seller.ShowAllProducts();
                }
                else if(readInput == "myInv")
                {
                    foreach(Product product in _products)
                    {
                        Console.WriteLine(product.Name);
                    }

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }
    }

    class Seller
    {
        private List<Product> _products = new List<Product>();

        public Seller()
        {
            _products.Add(new Product("Молоко 1л.", 120));
            _products.Add(new Product("Хлеб нарезной", 50));
            _products.Add(new Product("Coca-Cola 2л.", 160));
            _products.Add(new Product("Chapman Red", 190));
            _products.Add(new Product("Сахар белый", 100));
        }

        public Product SellProduct(int productIndex, ref int playerMoney)
        {
            if (productIndex < _products.Count)
            {
                if (playerMoney > _products[productIndex].Cost)
                {
                    Product productForSale = _products[productIndex];
                    playerMoney -= _products[productIndex].Cost;
                    _products.RemoveAt(productIndex);
                    return productForSale;
                }
                else
                {
                    Console.WriteLine("Вы не можете себе это позволить");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                return null;
            }
        }

        public void ShowAllProducts()
        {
            for(int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i}: {_products[i].Name} - {_products[i].Cost} рублей");
            }
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }

}

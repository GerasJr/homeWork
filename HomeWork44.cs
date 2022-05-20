using System;
using System.Collections.Generic;

namespace hm44
{
    class HomeWork44
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine();
            magazine.Trade(true);
        }
    }

    class Magazine
    {
        private Seller _seller = new Seller();
        private Player _player = new Player();

        public void Trade(bool isTrade)
        {
            Console.WriteLine("Выберете товар который хотите купить");
            Console.WriteLine("Показать товары - show");
            Console.WriteLine("Посмотреть свои вещи - myInv");

            while (isTrade)
            {
                Console.WriteLine("Ваши деньги - " + _player.Money);
                Console.WriteLine();
                string readInput = Console.ReadLine();

                if (int.TryParse(readInput, out int productIndex))
                {
                    if(productIndex < _seller.OutputAllProducts() && _player.Money > _seller.ShowProductCost(productIndex))
                    {
                        _player.TakeProduct(_seller.SellProduct(productIndex));
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else if (readInput == "show")
                {
                    _seller.ShowAllProducts();
                }
                else if (readInput == "myInv")
                {
                    _player.ShowInventory();
                }
                else
                {
                    Console.WriteLine("Некорректый ввод");
                }
            }
        }
    }

    class Player
    {
        private List<Product> _products = new List<Product>();
        public int Money { get; private set; } = 1000;

        public void TakeProduct(Product product)
        {
            Money -= product.Cost;
            _products.Add(product);
        }

        public void ShowInventory()
        {
            foreach(Product product in _products)
            {
                Console.WriteLine(product.Name);
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

        public Product SellProduct(int productIndex)
        {
            Product productForSale = _products[productIndex];
            _products.RemoveAt(productIndex);
            return productForSale;
        }

        public int ShowProductCost(int productIndex)
        {
            return _products[productIndex].Cost;
        }

        public void ShowAllProducts()
        {
            for(int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i}: {_products[i].Name} - {_products[i].Cost} рублей");
            }
        }

        public int OutputAllProducts()
        {
            return _products.Count;
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

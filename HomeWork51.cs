using System;
using System.Collections.Generic;

namespace hm51
{
    class HomeWork51
    {
        static void Main(string[] args)
        {
            AutoRepairShop autoRepairShop = new AutoRepairShop();

            autoRepairShop.Work(true);
        }
    }

    class AutoRepairShop
    {
        private List<Detail> _details = new List<Detail>();
        private int _rateOfRepair = 2500;
        private int _fine = 5000;
        public int Money { get; private set; } = 100000;

        public void Work(bool isWork)
        {
            while (isWork)
            {
                Car car = new Car();
                int cost = car.GetRepairCost(_rateOfRepair);
                bool isServiced = false;
                Console.WriteLine("К вам пригнали новую машину.");

                while(isServiced == false)
                {
                    car.ShowAllDetails();
                    Console.WriteLine($"Общая плата за починку - {cost}");
                    Console.WriteLine("Что бы принять заказ введите accept, для отказа reject");
                    Console.WriteLine("Для покупки/продажи деталей введите shop");
                    string userInput = Console.ReadLine();

                    if (userInput == "accept")
                    {
                        RepairCar(car);

                        if (car.GetCorrectInstallation())
                        {
                            Console.WriteLine("Вы успешно завершили заказ");
                            Console.WriteLine($"Ваша плата - {cost}");
                            Money += cost;
                        }
                        else
                        {
                            Console.WriteLine("Вы не справились с заказом");
                            Console.WriteLine($"Вы оплатили штраф в размере {_fine}");
                            Money -= _fine;
                        }

                        isServiced = true;
                    }
                    else if (userInput == "reject")
                    {
                        Money -= _fine;
                        Console.WriteLine($"Вы отказали клиенту и выплатили штраф в размере {_fine}");
                        isServiced = true;
                    }
                    else if (userInput == "shop")
                    {
                        Store store = new Store();
                        store.Trade(this);
                    }
                }

                Console.WriteLine("Что бы продолжить введите enter");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void BuyDetail(Detail detail)
        {
            Money -= detail.Cost;
            _details.Add(detail);
        }

        public Detail SellDetail(int number)
        {
            Detail detailToSell = _details[number];
            _details.RemoveAt(number);

            if (detailToSell.IsUseful == true)
            {
                Money += detailToSell.Cost;
            }
            else
            {
                Money += detailToSell.Cost / 2;
            }

            return detailToSell;
        }

        private void RepairCar(Car car)
        {
            bool isDone = false;

            while (isDone == false)
            {
                Console.WriteLine("Автомобиль:");
                car.ShowAllDetails();
                Console.WriteLine();
                Console.WriteLine("Ваши детали на складе:");
                ShowWarehouse();
                Console.WriteLine("Что бы демонтировать деталь напишите take");
                Console.WriteLine("Что бы установить напишите set");
                Console.WriteLine("Что бы завершить ремонт введите done");
                string readInput = Console.ReadLine();

                if(readInput == "take")
                {
                    Console.WriteLine("Выберете деталь для демонтажа");
                    readInput = Console.ReadLine();

                    if (int.TryParse(readInput, out int number) && number >= 0 && number < car.GetDetailsCount())
                    {
                        _details.Add(Dismantling(car, number));
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else if(readInput == "set")
                {
                    Console.WriteLine("Выберете деталь которую хотите поставить:");
                    readInput = Console.ReadLine();

                    if(int.TryParse(readInput, out int number) && number >= 0 && number < _details.Count)
                    {
                        Setup(car, _details[number]);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else if(readInput == "done")
                {
                    isDone = true;
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }
        }
   
        public void ShowWarehouse()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                Console.WriteLine($"{i}: {_details[i].Name}");
                Console.WriteLine($"Стоимость - {_details[i].Cost}");

                if (_details[i].IsUseful == true)
                {
                    Console.WriteLine("Состояние - Исправно");
                }
                else
                {
                    Console.WriteLine("Состояние - Сломано");
                }
            }
        }

        public int GetDetailsCount()
        {
            return _details.Count;
        }

        private Detail Dismantling(Car car, int number)
        {
            Detail dismantlingDetail = car.ReplacementDetail(number);
            return dismantlingDetail;
        }

        private void Setup(Car car, Detail detail)
        {
            car.GetDetail(detail);
            _details.Remove(detail);
        }
    }

    class Car
    {
        private List<Detail> _correctDetails = new List<Detail>();
        private List<Detail> _details = new List<Detail>();
        private Random _random = new Random();

        public Car()
        {
            int maxBreakdowns = 5;

            _details.Add(new Starter());
            _details.Add(new Battery());
            _details.Add(new Crankshaft());
            _details.Add(new Pistons());
            _details.Add(new FrontLeftSuspension());
            _details.Add(new FrontRightSuspension());
            _details.Add(new BackLeftSuspension());
            _details.Add(new BackRightSuspension());
            _details.Add(new FrontLeftWheel());
            _details.Add(new FrontRightWheel());
            _details.Add(new BackLeftWheel());
            _details.Add(new BackRightWheel());
            _details.Add(new Radiator());

            foreach (Detail detail in _details)
            {
                _correctDetails.Add(detail);
            }

            BrokeDetails(_random.Next(1, maxBreakdowns));
        }

        public void ShowAllDetails()
        {
            for(int i = 0; i < _details.Count; i++)
            {
                Console.WriteLine($"{i}: {_details[i].Name}");

                if (_details[i].IsUseful == true)
                {
                    Console.WriteLine("Состояние - Исправно");
                }
                else
                {
                    Console.WriteLine("Состояние - Сломано");
                }
            }
        }

        public int GetRepairCost(int rateOfRepair)
        {
            int cost = 0;

            foreach(Detail detail in _details)
            {
                if (detail.IsUseful == false)
                {
                    cost += detail.Cost + rateOfRepair;
                }
            }

            return cost;
        }

        public bool GetCorrectInstallation()
        {
            int correctDetails = 0;

            for(int i = 0; i < _correctDetails.Count; i++)
            {
                for(int j = 0; j < _details.Count; j++)
                {
                    if (_correctDetails[i] == _details[j] && _details[j].IsUseful == true)
                    {
                        correctDetails++;
                    }
                }
            }

            if(correctDetails == _correctDetails.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Detail ReplacementDetail(int number)
        {
            Detail detailToReplace = _details[number];
            _details.RemoveAt(number);
            return detailToReplace;
        }

        public int GetDetailsCount()
        {
            return _details.Count;
        }

        public void GetDetail(Detail detail)
        {
            _details.Add(detail);
        }

        private void BrokeDetails(int count)
        {
            for(int i = 0; i < count; i++)
            {
                _details[_random.Next(0, _details.Count)].Broke();
            }
        }
    }

    class Store
    {
        private List<Detail> _details = new List<Detail>();
        public int _allDetails { get; private set; }

        public Store()
        {
            _details.Add(new Starter());
            _details.Add(new Battery());
            _details.Add(new Crankshaft());
            _details.Add(new Pistons());
            _details.Add(new FrontLeftSuspension());
            _details.Add(new FrontRightSuspension());
            _details.Add(new BackLeftSuspension());
            _details.Add(new BackRightSuspension());
            _details.Add(new FrontLeftWheel());
            _details.Add(new FrontRightWheel());
            _details.Add(new BackLeftWheel());
            _details.Add(new BackRightWheel());
            _details.Add(new Radiator());
            _allDetails = _details.Count;
        }

        public void Trade(AutoRepairShop autoRepairShop)
        {
            bool isTrade = true;

            ShowAllProducts();

            while (isTrade == true)
            {
                Console.WriteLine($"Ваши деньги - {autoRepairShop.Money}");
                Console.WriteLine("Для покупки детали введите buy, для продажи sell");
                Console.WriteLine("Закончить торговлю - exit");
                string userInput = Console.ReadLine();

                if (userInput == "buy")
                {
                    Console.WriteLine("Введите id детали которую хотите купить");
                    string readInput = Console.ReadLine();

                    if (int.TryParse(readInput, out int id) && id >= 0 && id < _allDetails && autoRepairShop.Money > ReturnById(id).Cost)
                    {
                        autoRepairShop.BuyDetail(ReturnById(id));
                        Console.WriteLine($"Вы купили деталь - {ReturnById(id).Name}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else if (userInput == "sell")
                {
                    autoRepairShop.ShowWarehouse();
                    Console.WriteLine("ВНИМАНИЕ: Если вы продаете непригодную деталь то вы получите вдвое меньше от ее стоимости");
                    Console.WriteLine("Введите номер детали которую хотите продать");
                    string readInput = Console.ReadLine();

                    if (int.TryParse(readInput, out int number) && number >= 0 && number < autoRepairShop.GetDetailsCount())
                    {
                        autoRepairShop.SellDetail(number);
                        Console.WriteLine("Вы удачно продали деталь");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else if (userInput == "exit")
                {
                    Console.WriteLine("Вы закончили торговлю");
                    isTrade = false;
                }
            }
        }

        private void ShowAllProducts()
        {
            foreach (Detail detail in _details)
            {
                Console.WriteLine($"{detail.Id}: {detail.Name}");
                Console.WriteLine($"Стоимость - {detail.Cost}");
            }
        }

        private Detail ReturnById(int id)
        {
            Detail detailToReturn = _details[0];

            foreach(Detail detail in _details)
            {
                if(detail.Id == id)
                {
                    detailToReturn = detail;
                }
            }

            return detailToReturn;
        }
    }

    abstract class Detail
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public bool IsUseful { get; private set; }

        protected void CreateDetail(int id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
            IsUseful = true;
        }

        public void Broke()
        {
            IsUseful = false;
        }

        public void Replacement()
        {
            IsUseful = true;
        }
    }

    class Starter : Detail
    {
        public Starter()
        {
            CreateDetail(0, "Стартер", 2500);
        }
    }

    class Battery : Detail
    {
        public Battery()
        {
            CreateDetail(1, "Аккумулятор", 6000);
        }
    }

    class Pistons : Detail
    {
        public Pistons()
        {
            CreateDetail(2, "Поршни", 1500);
        }
    }

    class Crankshaft : Detail
    {
        public Crankshaft()
        {
            CreateDetail(3, "Коленчатый вал", 15000);
        }
    }

    class FrontLeftSuspension : Detail
    {
        public FrontLeftSuspension()
        {
            CreateDetail(4, "Передняя левая подвеска", 25000);
        }
    }
    
    class FrontRightSuspension : Detail
    {
        public FrontRightSuspension()
        {
            CreateDetail(5, "Передняя правая подвеска", 25000);
        }
    }

    class BackLeftSuspension : Detail
    {
        public BackLeftSuspension()
        {
            CreateDetail(6, "Задняя левая подвеска", 25000);
        }
    }

    class BackRightSuspension : Detail
    {
        public BackRightSuspension()
        {
            CreateDetail(7, "Задняя правая подвеска", 25000);
        }
    }

    class FrontLeftWheel : Detail
    {
        public FrontLeftWheel()
        {
            CreateDetail(8, "Переднее левое колесо", 15000);
        }
    }

    class FrontRightWheel : Detail
    {
        public FrontRightWheel()
        {
            CreateDetail(9, "Переднее правое колесо", 15000);
        }
    }

    class BackLeftWheel : Detail
    {
        public BackLeftWheel()
        {
            CreateDetail(10, "Заднее левое колесо", 15000);
        }
    }

    class BackRightWheel : Detail
    {
        public BackRightWheel()
        {
            CreateDetail(11, "Заднее правое колесо", 15000);
        }
    }

    class Radiator : Detail
    {
        public Radiator()
        {
            CreateDetail(12, "Радиатор", 10000);
        }
    }
}

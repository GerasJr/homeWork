using System;
using System.Collections.Generic;
using System.Linq;

namespace hm58
{
    class HomeWork58
    {
        static void Main(string[] args)
        {
            FirstSquad firstSquad = new FirstSquad();
            SecondSquad secondSquad = new SecondSquad();

            ShowSquadsInfo(firstSquad, secondSquad);
            secondSquad.ReceiveSoliders(firstSquad.GiveSoliders());
            ShowSquadsInfo(firstSquad, secondSquad);

            void ShowSquadsInfo(Squad firstSquad, Squad secondSquad)
            {
                Console.WriteLine("Первый отряд");
                firstSquad.ShowAllSoliders();
                Console.WriteLine("Второй отряд");
                secondSquad.ShowAllSoliders();
            }
        }
    }

    abstract class Squad
    {
        protected List<Solider> _soliders = new List<Solider>();

        public void ReceiveSoliders(List<Solider> soliders)
        {
            foreach(Solider solider in soliders)
            {
                _soliders.Add(solider);
            }
        }

        public List<Solider> GiveSoliders()
        {
            var filtredSoliders = _soliders.Where(solider => solider.FullName.StartsWith("Б")).ToList();

            for(int i = 0; i < filtredSoliders.Count; i++)
            {
                _soliders.Remove(filtredSoliders[i]);
            }

            return filtredSoliders;
        }

        public void ShowAllSoliders()
        {
            for(int i = 0; i < _soliders.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_soliders[i].FullName}");
            }
        }
    }

    class FirstSquad : Squad
    {
        public FirstSquad()
        {
            _soliders.Add(new Solider("Жуков Денис Александрович"));
            _soliders.Add(new Solider("Быков Иван Русланович"));
            _soliders.Add(new Solider("Степанов Михаил Никитич"));
            _soliders.Add(new Solider("Максимов Максим Никитич"));
            _soliders.Add(new Solider("Бирюков Степан Львович"));
            _soliders.Add(new Solider("Баженов Руслан Борисович"));
            _soliders.Add(new Solider("Богданов Лев Сергеевич"));
        }
    }

    class SecondSquad : Squad
    {
        public SecondSquad()
        {
            _soliders.Add(new Solider("Кузнецов Илья Даниилович"));
            _soliders.Add(new Solider("Сидоров Лука Константинович"));
            _soliders.Add(new Solider("Зуев Давид Михайлович"));
            _soliders.Add(new Solider("Баранов Иван Даниилович"));
            _soliders.Add(new Solider("Никольский Роман Владимирович"));
            _soliders.Add(new Solider("Мельников Марат Германович"));

        }
    }

    class Solider
    {
        public string FullName { get; private set; }

        public Solider(string fullName)
        {
            FullName = fullName;
        }
    }
}

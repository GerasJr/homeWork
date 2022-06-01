using System;
using System.Collections.Generic;
using System.Linq;

namespace hm53
{
    class HomeWork53
    {
        static void Main(string[] args)
        {
            Arstotska arstotska = new Arstotska();

            arstotska.ShowAllPrisoners();
            Console.WriteLine();
            arstotska.Amnesty();
            arstotska.ShowAllPrisoners();
        }
    }

    class Arstotska
    {
        private List<Prisoner> _prisoners = new List<Prisoner>()
        {
         new Prisoner("Курганский Иван Иванович", "Антиправительственное"),
         new Prisoner("Петрушкин Петр Петрович", "Убийство"),
         new Prisoner ("Герасименко Виктор Вадимович", "Антиправительственное"),
         new Prisoner("Крутой Алексей Алексеевич", "Контрабанда")
        };

        public void Amnesty()
        {
            var filteredPrisoners = from Prisoner prisoner in _prisoners
                                    where prisoner.Crime == "Антиправительственное"
                                    select prisoner;

            foreach(Prisoner prisoner in filteredPrisoners.ToList())
            {
                _prisoners.Remove(prisoner);
            }
        }

        public void ShowAllPrisoners()
        {
            foreach(Prisoner prisoner in _prisoners)
            {
                Console.WriteLine($"{prisoner.FullName}");
                Console.WriteLine($"Отбывает за *{prisoner.Crime}*");
            }
        }
    }

    class Prisoner
    {
        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string name, string crime)
        {
            FullName = name;
            Crime = crime;
        }
    }
}

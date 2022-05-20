using System;
using System.Collections.Generic;

namespace hm43
{
    class HomeWork43
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.Work(true);
        }
    }

    class Library
    {
        List<Book> _books = new List<Book>();

        public void Work(bool isWork)
        {
            Console.WriteLine("1 - Добавить книгу");
            Console.WriteLine("2 - Удалить книгу");
            Console.WriteLine("3 - Показать все книги");
            Console.WriteLine("4 - Поиск книг");

            while (isWork)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        DeleteBook();
                        break;
                    case "3":
                        ShowAllBooks();
                        break;
                    case "4":
                        SearchBooks();
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Введите название книги");
            string title = Console.ReadLine();
            Console.WriteLine("Введите автора книги");
            string author = Console.ReadLine();
            Console.WriteLine("Введите год выпуска книги");
            string readYear = Console.ReadLine();

            if(int.TryParse(readYear, out int yearToRelease))
            {
                int bookNumber = _books.Count + 1;

                _books.Add(new Book(bookNumber, title, author, yearToRelease));
                Console.WriteLine("Книга успешно добавлена");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        private void DeleteBook()
        {
            Console.WriteLine("Введите номер книги которую хотите удалить");
            string readBookNumber = Console.ReadLine();

            if(int.TryParse(readBookNumber, out int bookNumber))
            {
                _books.RemoveAt(bookNumber - 1);
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        private void ShowAllBooks()
        {
            foreach(Book book in _books)
            {
                Console.WriteLine("Номер - " + book.Number);
                Console.WriteLine("Название - " + book.Title);
                Console.WriteLine("Автор - " + book.Author);
                Console.WriteLine("Год релиза - " + book.YearOfRelease);
                Console.WriteLine();
            }
        }

        private void SearchBooks()
        {
            Console.WriteLine("Выберете по какому критерию вы хотите найти книги");
            Console.WriteLine("1 - По номеру");
            Console.WriteLine("2 - По названию");
            Console.WriteLine("3 - По Автору");
            Console.WriteLine("4 - По году релиза");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    SearchForNumber();
                    break;
                case "2":
                    SearchForTitle();
                    break;
                case "3":
                    SearchForAuthor();
                    break;
                case "4":
                    SearchForYearRelease();
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    break;
            }
        }

        private void SearchForNumber()
        {
            Console.WriteLine("Введите номер книги");
            string readInput = Console.ReadLine();

            if (int.TryParse(readInput, out int userNumber))
            {
                foreach (Book book in _books)
                {
                    if (book.Number == userNumber)
                    {
                        Console.WriteLine("Номер - " + book.Number);
                        Console.WriteLine("Название - " + book.Title);
                        Console.WriteLine("Автор - " + book.Author);
                        Console.WriteLine("Год релиза - " + book.YearOfRelease);
                        Console.WriteLine();
                    }
                }
            }
        }

        private void SearchForTitle()
        {
            Console.WriteLine("Введите название книги");
            string userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Title == userInput)
                {
                    Console.WriteLine("Номер - " + book.Number);
                    Console.WriteLine("Название - " + book.Title);
                    Console.WriteLine("Автор - " + book.Author);
                    Console.WriteLine("Год релиза - " + book.YearOfRelease);
                    Console.WriteLine();
                }
            }
        }

        private void SearchForAuthor()
        {
            Console.WriteLine("Введите автора книги");
            string userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Author == userInput)
                {
                    Console.WriteLine("Номер - " + book.Number);
                    Console.WriteLine("Название - " + book.Title);
                    Console.WriteLine("Автор - " + book.Author);
                    Console.WriteLine("Год релиза - " + book.YearOfRelease);
                    Console.WriteLine();
                }
            }
        }

        private void SearchForYearRelease()
        {
            Console.WriteLine("Введите год релиза книги");
            string readInput = Console.ReadLine();

            if (int.TryParse(readInput, out int userYear))
            {
                foreach (Book book in _books)
                {
                    if (book.YearOfRelease == userYear)
                    {
                        Console.WriteLine("Номер - " + book.Number);
                        Console.WriteLine("Название - " + book.Title);
                        Console.WriteLine("Автор - " + book.Author);
                        Console.WriteLine("Год релиза - " + book.YearOfRelease);
                        Console.WriteLine();
                    }
                }
            }
        }
    }

    class Book
    {
        public int Number { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearOfRelease { get; private set; }

        public Book(int number,string title, string author, int yearOfRelease)
        {
            Number = number;
            Title = title;
            Author = author;
            YearOfRelease = yearOfRelease;
        }
    }
}

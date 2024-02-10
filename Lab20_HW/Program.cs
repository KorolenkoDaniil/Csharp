using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab20_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                //new Book(),
                //new Book(),
                //new Book(),
                //new Book(),
                //new Book(),
                //new Book("", "Агата", "Кристи", 256, "мягкая", 256),
                //new Book(),
                //new Book(),
                //new Book(),
                //new Book(),
            };


            AdToList(ref books, "", "Агата", "Кристи", 256.ToString(), "мягкая", 256.ToString());
            AdToList(ref books, "Война и мир", "Лев", "Толстой", 600.ToString(), "мягкая", 1225.ToString());
            AdToList(ref books, "Война и мир", "Лев", "Толстой", 671.ToString(), "мягкая", 671.ToString());
            AdToList(ref books, "1984", "Джордж", "Оруэлл", 328.ToString(), "твердая", 328.ToString());
            AdToList(ref books, "Гарри Поттер и философский камень", "Джоан", "Роулинг", 223.ToString(), "мягкая", 10.ToString());
            AdToList(ref books, "", "Михаил", "Булгаков", 1000.ToString(), "твердая", 384.ToString());
            AdToList(ref books, "Алиса в Стране чудес", "Льюис", "Кэрролл", 96.ToString(), "мягкая", 96.ToString());
            AdToList(ref books, "Маленький принц", "Антуан", "Де Сент-Экзюпери", 91.ToString(), "твердая", 91.ToString().ToString());
            AdToList(ref books, "Триумфальная арка", "Эрих Мария", "Ремарк", 632.ToString(), "твердая", 632.ToString());
            AdToList(ref books, "Гордость и предубеждение", "Джейн", "Остин", 1000.ToString(), "мягкая", 432.ToString());


            var newBooksList1 = (from book in books
                                 orderby book.Name, book.Price
                                 select book).ToList();

            Console.WriteLine("отсортированный список по 2 критериям");
            foreach (Book book in newBooksList1)
                Console.WriteLine(book);



            Console.WriteLine();
            Console.WriteLine();
            var newBooksList2 = books.Where(book => book.CoverType == "мягкая");

            Console.WriteLine("список книг в мягкой обложкой");
            foreach (Book book in newBooksList2)
                Console.WriteLine(book);



            Console.WriteLine();
            Console.WriteLine();
            var newBooksList3 = books.Where(book => book.CoverType == "твердая");

            Console.WriteLine("список книг в твердой обложкой");
            foreach (Book book in newBooksList3)
                Console.WriteLine(book);



            Console.WriteLine();
            Console.WriteLine();
            var newBooksList4 = books.Where(book => book.CoverType == "мягкая" && book.Price < 100);

            Console.WriteLine("список книг в мягкой обложкой со стоимостью ниже 100руб");
            foreach (Book book in newBooksList4)
                Console.WriteLine(book);


            Console.WriteLine();
            Console.WriteLine();
            int MaxNumberOfPage = books.Max(book => book.PageNumber);
            var newBooksList5 = from book in books where book.PageNumber == MaxNumberOfPage select book;

            Console.WriteLine("список книг с наибольшим количеством страниц ");
            foreach (Book book in newBooksList5)
                Console.WriteLine(book);

            Console.ReadKey();

        }


        public static void AdToList(ref List<Book> books, params string[] args)
        {
            bool create = true;
            Book newbook = null;
            try
            {
                newbook = new Book(args[0], args[1], args[2], int.Parse(args[3]), args[4], decimal.Parse(args[5]));
            }
            catch (MyException2)
            {
                create = false;
            }
            if (create) books.Add(newbook);
        } 
    }
}

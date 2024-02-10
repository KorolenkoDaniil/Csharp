using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_20_theory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Выражение from p in people проходит по всем элементам массива people и определяет каждый элемент как p.Используя переменную p мы можем проводить над ней разные операции.
            //с помощью оператора where проводится фильтрация объектов, и если объект соответствует критерию, то этот объект передается дальше.
            //Оператор orderby упорядочивает по возрастанию

            string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

            //способ 1 
            var selectedPeople1 = from p in people where p.ToUpper().StartsWith("T") orderby p select p;
            //способ 2
            var selectedPeople2 = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
            //Он состоит из цепочки методов Where и OrderBy. В качестве аргумента эти методы принимают делегат или лямбда-выражение.

            Console.WriteLine(selectedPeople1.GetType());

            foreach (string person in selectedPeople1)
                Console.WriteLine(person);

            //--------------------------------------------------
            //выбор только имен способ 1
            var people2 = new List<Person>
            {
                new Person ("Tom", 23),
                new Person ("Bob", 27),
                new Person ("Sam", 29),
                new Person ("Alice", 24)
            };

            var names = from p in people2 select p.name;


            //приведение к массиву
            string[] namesArray = names.ToArray();
            //приведение к списку
            List<string> namesList = names.Where(p => p.Length == 3).ToList();

            Console.WriteLine();
            foreach (string n in namesList)
                Console.WriteLine(n);


            //Список используемых методов расширения LINQ
            //Select: определяет проекцию выбранных значений

            //Where: определяет фильтр выборки

            //OrderBy: упорядочивает элементы по возрастанию

            //OrderByDescending: упорядочивает элементы по убыванию

            //ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию

            //ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию

            //Join: соединяет две коллекции по определенному признаку

            //Aggregate: применяет к элементам последовательности агрегатную функцию, которая сводит их к одному объекту

            //GroupBy: группирует элементы по ключу

            //ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь

            //GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу

            //Reverse: располагает элементы в обратном порядке

            //All: определяет, все ли элементы коллекции удовлятворяют определенному условию

            //Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию

            //Contains: определяет, содержит ли коллекция определенный элемент

            //Distinct: удаляет дублирующиеся элементы из коллекции

            //Except: возвращает разность двух коллекцию, то есть те элементы, которые создаются только в одной коллекции

            //Union: объединяет две однородные коллекции

            //Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях

            //Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию

            //Sum: подсчитывает сумму числовых значений в коллекции

            //Average: подсчитывает cреднее значение числовых значений в коллекции

            //Min: находит минимальное значение

            //Max: находит максимальное значение

            //Take: выбирает определенное количество элементов

            //Skip: пропускает определенное количество элементов

            //TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно

            //SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы

            //Concat: объединяет две коллекции

            //Zip: объединяет две коллекции в соответствии с определенным условием

            //First: выбирает первый элемент коллекции

            //FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию

            //Single: выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, то генерируется исключение

            //SingleOrDefault: выбирает единственный элемент коллекции. Если коллекция пуста, возвращает значение по умолчанию. Если в коллекции больше одного элемента, генерирует исключение

            //ElementAt: выбирает элемент последовательности по определенному индексу

            //ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона

            //Last: выбирает последний элемент коллекции

            //LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию




            //--------------------------------------------------
            //выбор только имен способ 2

            List<string> names3 = people2.Select(u => u.name).ToList();



            //------------------------------------------------
            //выборка из нескольких источников
            Console.WriteLine();
            Console.WriteLine();
            var courseList = new List<Course>
            {
                new Course("C#"),
                new Course("Java"),
            };

            var studentList = new List<Person>
            {
                new Person("A"),
                new Person("B"),
            };

            var students = from course in courseList
                           from student in studentList
                           select new { Person = student.name, Course = course.courseName };

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Person} {student.Course}");
            }


            //-------------------------------------------------------------------
            //фильтрация коллекций пример 1
            Console.WriteLine();
            Console.WriteLine();
            string[] people3 = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

            var selectedPeople3 = people3.Where(p => p.Length == 3);

            var selectedPeople4 = from p in people3 where p.Length == 3 select p;

            foreach (string person in selectedPeople3)
                Console.WriteLine(person);

            //-------------------------------------------------------------------
            //фильтрация коллекций пример 2
            Console.WriteLine();
            Console.WriteLine();

            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
          
            var evens1 = numbers.Where(i => i % 2 == 0 && i > 10);
            var evens2 = from i in numbers where i % 2 == 0 && i > 10 select i;



            //-------------------------------------------------------------------
            //выборка сложных объектов
            Console.WriteLine();
            Console.WriteLine();


            var people5 = new List<Person>
            {
                new Person ("Tom", 23, new List<string> {"english", "german"}),
                new Person ("Bob", 27, new List<string> {"english", "french" }),
                new Person ("Sam", 29, new List<string>  { "english", "spanish" }),
                new Person ("Alice", 24, new List<string> {"spanish", "german" })
            };

            var selectedPeople5 = from p in people5 where p.age > 25 select p;
            var selectedPeople6 = people5.Where(p => p.age > 25);

            foreach (Person person in selectedPeople6)
                Console.WriteLine($"{person.name} - {person.age} {person.PrintLanguage()}");


            //-------------------------------------------------------------------
            //выборка сложных объектов со сложным фильтром
            Console.WriteLine();
            Console.WriteLine();


            var people6 = new List<Person>
            {
                new Person ("Tom", 23, new List<string> {"english", "german"}),
                new Person ("Bob", 27, new List<string> {"english", "french" }),
                new Person ("Sam", 29, new List<string>  { "english", "spanish" }),
                new Person ("Alice", 24, new List<string> {"spanish", "german" })
            };

            var selectedPeople7 = from p in people6 
                                  from lang in p.languagesList
                                  where p.age < 28 
                                  where lang == "german"
                                  select p;
            var selectedPeople8 = people6.Where(p => p.age > 25);

            foreach (Person person in selectedPeople7)
                Console.WriteLine($"{person.name} - {person.age} {person.PrintLanguage()}");




            //-------------------------------------------------------------------
            //фильтрация по типу данных
            Console.WriteLine();
            Console.WriteLine();


            var people9 = new List<Person>
            {
                new Student("Tom"),
                new Person("Sam"),
                new Student("Bob"),
            };


            var students1 = people9.OfType<Student>();

            foreach (var student in students1)
                Console.WriteLine(student.name);



            //-------------------------------------------------------------------
            //сортировка orderby(оператор) OrderBy(метод) ао возрастанию
            Console.WriteLine();
            Console.WriteLine();

            int[] numbers1 = { 3, 12, 4, 10 };
            List<int> orderedNumbers1 = (from i in numbers1 
                                 orderby i //критерий сортировки
                                 select i).ToList();

            List<int> orderedNumbers2 = numbers1.OrderBy(n => n).ToList();

            foreach (int i in orderedNumbers1) Console.WriteLine(i);




            //-------------------------------------------------------------------
            //сортировка orderby(оператор) OrderBy(метод) ао возрастанию
            Console.WriteLine();
            Console.WriteLine();

            int[] numbers2 = { 3, 12, 4, 10 };
            List<int> orderedNumbers3 = (from i in numbers1
                                         orderby i descending //по убыванию
                                         //orderby i ascending //по возрастанию
                                         select i).ToList();

            List<int> orderedNumbers4 = numbers1.OrderByDescending(n => n).ToList(); //сортировка по убыванию

            foreach (int i in orderedNumbers3) Console.WriteLine(i);





            //-------------------------------------------------------------------
            //множественные критерии сортировкм 2 способами
            Console.WriteLine();
            Console.WriteLine();

            var people11 = new List<Person>
            {
                new Person("Tom", 37),
                new Person("Sam", 28),
                new Person("Tom", 22),
                new Person("Bob", 41),
            };

            var sortedPeople1 = from p in people11 
                               orderby p.name, p.age
                               select p;

            var sortedPeople2 = people11.OrderByDescending(p => p.name).ThenBy(p => p.age); 



            foreach (var p in sortedPeople1)
                Console.WriteLine($"{p.name} - {p.age}");









            //-------------------------------------------------------------------
            //множественные критерии сортировки c направлением 2 способами
            Console.WriteLine();
            Console.WriteLine();

            var people12 = new List<Person>
            {
                new Person("Tom", 37),
                new Person("Sam", 28),
                new Person("Tom", 22),
                new Person("Bob", 41),
            };

            var sortedPeople3 = from p in people11
                               orderby p.name,
                               p.age descending
                               select p;


            var sortedPeople4 = people11.OrderByDescending(p => p.name).ThenBy(p => p.age);

            foreach (var p in sortedPeople3)
                Console.WriteLine($"{p.name} - {p.age}");











            //-------------------------------------------------------------------
            //переопределение критерия сортировки
            Console.WriteLine();
            Console.WriteLine();

      
            string[] people13 = new[] { "Kate", "Tom", "Sam", "Mike", "Alice" };

            var sortedPeople = people13.OrderBy(p => p, new СustomStringComparer());

            foreach (var p in sortedPeople)
                Console.WriteLine(p);




            //-------------------------------------------------------------------
            //разность последовательностей
            Console.WriteLine();
            Console.WriteLine();


            string[] soft1 = { "Microsoft", "Google", "Apple" };
            string[] hard1 = { "Apple", "IBM", "Samsung" };

           
            var result1 = soft1.Except(hard1); //В данном случае из массива soft убираются все элементы, которые есть в массиве hard.
                                            //Результатом операции будут два элемента:

            foreach (string s in result1)
                Console.WriteLine(s);

            



            //-------------------------------------------------------------------
            //пересечение последовательностей
            Console.WriteLine();
            Console.WriteLine();


            string[] soft2 = { "Microsoft", "Google", "Apple" };
            string[] hard2 = { "Apple", "IBM", "Samsung" };


            var result = soft2.Intersect(hard2);
            //Для получения  общих для обоих наборов элементов,
            //применяется метод Intersect:

            foreach (string s in result)
                Console.WriteLine(s);






            //-------------------------------------------------------------------
            //удаление дубликатов
            Console.WriteLine();
            Console.WriteLine();

            string[] soft = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };

            var result2 = soft.Distinct();
            
            foreach (string s in result2)
                Console.WriteLine(s);







            //-------------------------------------------------------------------
            //обьединение коллекций без дубликатов
            Console.WriteLine();
            Console.WriteLine();

            string[] soft3 = { "Microsoft", "Google", "Apple" };
            string[] hard3 = { "Apple", "IBM", "Samsung" };

            var result3 = soft3.Union(hard3);


            Console.WriteLine( "!!!!!!!!!!!!!!!!!11111");
            foreach (string s in result3)
                Console.WriteLine(s);



            //-------------------------------------------------------------------
            //обьединение коллекций С дубликатами
            Console.WriteLine();
            Console.WriteLine();

            string[] soft4 = { "Microsoft", "Google", "Apple" };
            string[] hard4 = { "Apple", "IBM", "Samsung" };

            var result4 = soft4.Concat(hard4);

            foreach (string s in result4)
                Console.WriteLine(s);






            //-------------------------------------------------------------------
            //
            Console.WriteLine();
            Console.WriteLine();

            Person[] students2 = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
            Person[] employees1 = { new Person("Tom"), new Person("Bob"), new Person("Mike") };

































            Console.ReadKey();

        }
    }
}

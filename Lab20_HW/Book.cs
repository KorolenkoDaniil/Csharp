using System;

namespace Lab20_HW
{
    public class Book
    {
        private string _name;
        private string _authorName;
        private string _authorSurname;
        private int _pageNumber;
        private string _coverType;
        private decimal _price;
        
        public Book() { }

        public Book(string name = "книга не указана", string authorName = "имя автора не указано", string authorSurname = "фамилия автора не указана", int numberOfPages = 0, string coverType = "тип обложки не указан", decimal price = 0)
        {
            Name = name;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            PageNumber = numberOfPages;
            CoverType = coverType;
            Price = price;
        }

        public string Name
        {
            get => _name;

            set
            {
                    _name = Validator.ValidateVarchar(value, 45) ?
                        value : throw new MyException2();
            }
        }
        public string AuthorName
        {
            get => _authorName;
            set => _authorName = Validator.ValidateVarchar(value, 45) ?
                value : throw new NumberException(value);
        }

        public string AuthorSurname
        {
            get => _authorSurname;
            set => _authorSurname = Validator.ValidateVarchar(value, 45) ?
                value : throw new NumberException(value);
        }

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = Validator.ValidateNumber(value) ?
                value : throw new NumberException(value.ToString());
        }

        public string CoverType
        {
            get => _coverType;
            set => _coverType = Validator.ValidateCover(value) ?
                value : throw new NumberException(value);
        }


        public decimal Price 
        {
            get => _price;
            set => _price = Validator.ValidatePrice(value) ?
                Math.Round(value, 2) : throw new Exception("Цена книги не может быть отрицательной ");
        }

        public override string ToString()
        {
            return $"книга: {_name}   автор: {_authorName} {_authorSurname}   количество страниц {_pageNumber}   тип обложки: {_coverType}  стоимость: {_price}руб";
        }









    }
}

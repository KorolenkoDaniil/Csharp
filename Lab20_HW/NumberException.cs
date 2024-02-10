using System;

namespace Lab20_HW
{
    internal class NumberException: Exception
    {
        public NumberException(string exceptionData) : base()
        {
            if (!string.IsNullOrEmpty(exceptionData)) Console.WriteLine($"ваша ошибка в {exceptionData}");
            else Console.WriteLine("введенная строка пуста");
        }
    }
}

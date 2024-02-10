using System;

namespace Lab20_HW
{
    internal class MyException2: Exception
    {
        public MyException2() : base()
        {
            Console.WriteLine("не удалось создать объект из-за некорректных  данных");
        } 
    }
}

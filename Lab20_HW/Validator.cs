using System;

namespace Lab20_HW
{
    public static class Validator
    {
        public static bool ValidateVarchar(string value, int maxLength) 
        {

            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("1");
                return false;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("2");
                return false;
            }

            if (value.Length > maxLength)
            {
                Console.WriteLine("3");
                return false;
            }

            if (char.IsUpper(value[0]) && char.IsDigit(value[0]))
            {
                Console.WriteLine("4");
                return false;
            }


            return true;
        }


        public static bool ValidateNumber(int value)
            => (value > 0);


        public static bool ValidateCover(string value)
        {

            if (value != "мягкая" && value != "твердая")
                return false;

            return true;
        }

        public static bool ValidatePrice(decimal value)
        {
            if (value <= 0)
                return false;

            return true;
        }




    }
}

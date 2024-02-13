using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab21_1
{
    internal class Motherboard
    {
        public int id;
        public string name;
        public string mark;
        public int amountOfRAM;
        public decimal price;

        public Motherboard() { }
        public Motherboard(params string[] args) {
            Name = args[0];
            Mark = args[1];
            AmountOfRAM = int.Parse(args[2]);
            Price = decimal.Parse(args[3]);
        }

        public string Name
        {
            get => name;
            set => name = Validator.ValidateVarchar(value, 40) ? 
                value: throw new Exception("проверьте данные, которые вы ввели");
        }

        public string Mark
        {
            get => mark;
            set => mark = Validator.ValidateVarchar(value, 40) ?
                value : throw new Exception("проверьте данные, которые вы ввели");
        }
        public int AmountOfRAM
        {
            get => amountOfRAM;
            set => amountOfRAM = Validator.ValidateNumber(value) ?
                value : throw new Exception("проверьте данные, которые вы ввели");
        }
        public decimal Price
        {
            get => price;
            set => price = Validator.ValidatePrice(value) ?
                value : throw new Exception("проверьте данные, которые вы ввели");
        }
        public int ID
        {
            get => id;
            set => id = Validator.ValidateNumber(value) ?
                value : throw new Exception("проверьте данные, которые вы ввели");
        }

    }
}

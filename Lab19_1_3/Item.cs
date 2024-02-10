using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_1_3
{
    public struct Item: IComparable
    {
        public string _type;
        public double _price;
        public int _amount;
        public Item(string type, string price, string amount)
        {
            _type = type;
            _price = Math.Round(double.Parse(price), 2);
            _amount = int.Parse(amount);
        }

        public int CompareTo(object obj)
        {
            Item a = (Item)obj;
            
            if (this._amount > a._amount) return 1;
            else if (this._amount < a._amount) return -1;
            else return 0;
        }

        public override string ToString()
        {
            return $"{_type} {_price} {_amount}";
        }

    }
}

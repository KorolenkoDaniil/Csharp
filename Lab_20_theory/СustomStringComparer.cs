using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_20_theory
{
    public class СustomStringComparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xLength = x.Length;
            int yLength = y.Length;
            if (xLength < yLength) return -1;
            if (xLength > yLength) return 1;
            return 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21.LINQ
{
    internal static class SortByNames
    {
        public static List<Flower> SortbyNames(List<Flower> Greenhouse)
        {
            List<Flower> SortedGreenhouse = Greenhouse.OrderByDescending(flower => flower.Name).ToList();
            return SortedGreenhouse;
        }
    }
}

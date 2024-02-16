using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21.LINQ
{
    internal static class GroupbyOrigin
    {
        public static IGrouping<string, Flower> Groupbyorigin(List<Flower> Greenhouse)
        {
            var GroupedList = Greenhouse.GroupBy(x => x.Origin).FirstOrDefault();
            return GroupedList;
        }

    }
}

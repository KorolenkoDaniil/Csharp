using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21.LINQ
{
    internal static class Search
    {
        public static Flower SearchItem(List<Flower> GreenHouse, string parameter)
        {
            var necessaryFlower = (from flower in GreenHouse
                                   //from visualParam in flower.VisualParameters
                                   where flower.Name.ToLower() == parameter.ToLower()
                                   //flower.Soil.ToLower() == parameter.ToLower() ||
                                   //flower.Origin.ToLower() == parameter.ToLower() ||
                                   //visualParam.ToLower() == parameter.ToLower()
                                   select flower).FirstOrDefault();
            return necessaryFlower;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    internal class Flower
    {
        private int id;
        private string name;
        private string soil;
        private string origin;
        private List<string> visualParameters;
        private List<string> grovingTips;
        private string multiplying;


        private string[] soils = { "подзолистая", "грунтовая", "дерново-подзолистая" };
        private string[] multiplyingTypes = { "листьями", "черенками", "семенами" };

        public Flower() { }
        public Flower(string name, string origin, List<string> visualParameters, List<string> grovingTips, string multiplying)
        {
            Name = name;
            Soil = ChoiceClass.ChoiceOfString(soils, "выберите номер земли которая благоприятна для растения");
            Origin = origin;
            VisualParameters = visualParameters;
            GrovingTips = grovingTips;
            Multiplying = ChoiceClass.ChoiceOfString(multiplyingTypes, "выберите номер способа размножения"); ;
        }



        public override string ToString()
        {
            string visualparams = "\n";
            foreach (string p in visualParameters)
            {
                visualparams += p + "\n";
            }
            return $"{id} {name} {soil} {origin} {visualparams}";
        }


        public string Name
        {
            get => name;
            set => name = Validator.ValidateVarchar(value, 50) ?
                value : throw new Exception("проверьте данные имени, растения");
        }
        public string Soil
        {
            get => soil;
            set => soil = value;

        }
        public string Origin
        {
            get => origin;
            set => origin = Validator.ValidateVarchar(value, 50) ?
                value : throw new Exception("проверьте данные происхождения, растения");
        }



        public List<string> VisualParameters
        {
            get => visualParameters;
            set => visualParameters = value;
        }

        public List<string> GrovingTips
        {
            get => grovingTips;
            set => grovingTips = value;
        }

        public string Multiplying
        {
            get => multiplying;
            set => multiplying = value;

        }

        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}

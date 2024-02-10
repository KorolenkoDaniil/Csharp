using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19__2_
{
    public class Label: IComparable<Label>
    {
        public string _Name { get; set; }
        public DateTime _DateOfCreation { get; set; }
        public string _Path { get; set; }
        public Label() { }

        public int CompareTo(Label other)
        {
            return _Name.CompareTo(other._Name);
        }

        public override string ToString()
        {
            return $"ярлык с названием{_Name}, путем {_Path}. Дата создания {_DateOfCreation}";
        }

    }
}

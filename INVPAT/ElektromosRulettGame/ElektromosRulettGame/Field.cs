using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektromosRulettGame
{
    internal class Field: IField
    {
        public int number { get; set; }
        public string color { get; set; }
        public Field(int numbert, string colort)
        {
            number = numbert;
            color = colort;
        }
        public Field() 
        {
            number = 0;
            color = "Zöld";
        }
        /*public override string ToString()
        {
            return $"{color}, {number}";
        }*/
    }
}

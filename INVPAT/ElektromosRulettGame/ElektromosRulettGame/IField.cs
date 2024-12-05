using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektromosRulettGame
{
    internal interface IField
    {
        int getNumber();
        int setNumber(int number);
        string getColor();
        string setColor(string color);
        string toString();
    }
}

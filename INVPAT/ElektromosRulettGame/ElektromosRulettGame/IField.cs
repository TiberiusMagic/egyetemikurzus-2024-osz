using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektromosRulettGame
{
    internal interface IField
    {
        int number { get; set; }
        string color { get; set; }
        //string ToString();
    }
}

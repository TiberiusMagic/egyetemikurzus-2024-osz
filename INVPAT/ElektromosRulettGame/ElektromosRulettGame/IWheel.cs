using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektromosRulettGame
{
    internal interface IWheel
    {
        List<IField> Fields { get; }
        IField Spin();
    }
}

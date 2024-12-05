using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Reflection;

namespace ElektromosRulettGame
{
    internal class Wheel: IWheel
    {
        public List<IField> Fields { get; }
        private readonly Random _random;

        public Wheel() 
        { 
            _random = new Random();
            Fields = new List<IField>();
            Fields.Add(new Field());
            Fields.Add(new Field(32, "Piros"));
            Fields.Add(new Field(15, "Fekete"));
            Fields.Add(new Field(19, "Piros"));
            Fields.Add(new Field(4, "Fekete"));
            Fields.Add(new Field(21, "Piros"));
            Fields.Add(new Field(2, "Fekete"));
            Fields.Add(new Field(25, "Piros"));
            Fields.Add(new Field(17, "Fekete"));
            Fields.Add(new Field(34, "Piros"));
            Fields.Add(new Field(6, "Fekete"));
            Fields.Add(new Field(27, "Piros"));
            Fields.Add(new Field(13, "Fekete"));
            Fields.Add(new Field(36, "Piros"));
            Fields.Add(new Field(11, "Fekete"));
            Fields.Add(new Field(30, "Piros"));
            Fields.Add(new Field(8, "Fekete"));
            Fields.Add(new Field(23, "Piros"));
            Fields.Add(new Field(10, "Fekete"));
            Fields.Add(new Field(5, "Piros"));
            Fields.Add(new Field(24, "Fekete"));
            Fields.Add(new Field(16, "Piros"));
            Fields.Add(new Field(33, "Fekete"));
            Fields.Add(new Field(1, "Piros"));
            Fields.Add(new Field(20, "Fekete"));
            Fields.Add(new Field(14, "Piros"));
            Fields.Add(new Field(31, "Fekete"));
            Fields.Add(new Field(9, "Piros"));
            Fields.Add(new Field(22, "Fekete"));
            Fields.Add(new Field(18, "Piros"));
            Fields.Add(new Field(29, "Fekete"));
            Fields.Add(new Field(7, "Piros"));
            Fields.Add(new Field(28, "Fekete"));
            Fields.Add(new Field(12, "Piros"));
            Fields.Add(new Field(35, "Fekete"));
            Fields.Add(new Field(3, "Piros"));
            Fields.Add(new Field(26, "Fekete"));
        }

        public IField Spin()
        { 
            int winningFieldIndex = _random.Next(Fields.Count);
            return Fields[winningFieldIndex];
        }
    }
}

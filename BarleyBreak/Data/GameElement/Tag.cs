using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data.GameElement
{
    public class Tag
    {
        public Tag(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public readonly int X;

        public readonly int Y;

        public readonly int Value;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data.GameElement
{
    public class TagMemory
    {
        public readonly List<Tag> Memory;

        public TagMemory()
        {
            Memory = new List<Tag>();
        }   

        public void WriteMemory()
        {
            foreach (var m in Memory)
            {
                Console.WriteLine("Значение {0} находится в ячейке {1} {2} ", m.Value, m.X, m.Y);
            }
        }

        public void WriteStepToMemory(Tag tag)
        {
            Memory.Add(tag);
        }       
    }
}

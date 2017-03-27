using BarleyBreak.Data.GameElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data
{
    public class Game3 : Game2
    {
        private TagMemory tagMemory;

        public Game3(int n)
            : base(n)
        {
            tagMemory = new TagMemory();
        }

        public void GetTagMemory()
        {
            tagMemory.WriteMemory();
        }

        public override void Shift(int value)
        {
            var valueLocation = GetLocation(value);
            tagMemory.WriteStepToMemory(new Tag(valueLocation.X, valueLocation.Y, value));

            base.Shift(value);

            valueLocation = GetLocation(value);
            tagMemory.WriteStepToMemory(new Tag(valueLocation.X, valueLocation.Y, value));

        }

        public void Rollback()
        {
            if (tagMemory.Memory.Count - 1 != -1)
            {
                Tag last = tagMemory.Memory[tagMemory.Memory.Count - 1];
                tagMemory.Memory.RemoveAt(tagMemory.Memory.Count - 1);
                int lastvalue = last.Value;
                Shift(lastvalue);
            }
        }

        //public virtual void Shift1(int value)
        //{
        //    var valueLocation = GetLocation(value);
        //    tagMemory.WriteStepToMemory(new Tag(valueLocation.X, valueLocation.Y, value));
        //    var coordinates = GetLocation(0);
        //    var valuenull = GetValueArea(coordinates.X, coordinates.Y);
        //    ChangePositionOnArea(GameArea, coordinates, valuenull, valueLocation,value);

        //    valueLocation = GetLocation(value);
        //    tagMemory.WriteStepToMemory(new Tag(valueLocation.X, valueLocation.Y, value));
        //}

    }
}

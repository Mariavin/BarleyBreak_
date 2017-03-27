using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data
{
    class ReadingFromFile
    {
        public static int[] TextToBarleyBreak(string file)
        {
            string[] remove = file.Split(new char[] { ' ', ',', '\t', '\n' });
            int[] valuefield = new int[remove.Length];
            int n = 0;

            for (int i = 0; i < remove.Length; i++)
            {
                valuefield[i] = Convert.ToInt32(remove[n]);
                n++;
            }
            if (valuefield == null) 
                throw new Exception("Error:Array is empty!");
            return valuefield;
        }
    }
}

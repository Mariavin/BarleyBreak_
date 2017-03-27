using BarleyBreak.Data.GameElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data
{
    public static class Print
    {
        public static void PrintGameArea(Area area)
        {
            Console.WriteLine("-----GAMEAREA------");
            for (int i = 0; i < area.LengthArea; i++)
            {
                for (int j = 0; j < area.LengthArea; j++)
                {
                    Console.Write("{0,3}", area[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}

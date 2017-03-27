using BarleyBreak.Data.GameElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data
{
    public class Game2 : Game
    {
        public Game2(int n)
            : base(n)
        {
            GameArea = new Area(n);
        }

        public bool IsSuccess()
        {
            int successNumber = 1;
            for (int i = 0; i < GameArea.LengthArea; i++)
            {
                for (int j = 0; j < GameArea.LengthArea; j++)
                {
                    if ((GameArea[i, j] != successNumber)
                        && (i == GameArea.LengthArea - 1 && j == GameArea.LengthArea - 1 && GameArea[i, j] != 0))
                        return false;
                    successNumber++;
                }
            }
            return true;
        }

        public void v()
        {
            int successNumber = 1;
            for (int i = 0; i < GameArea.LengthArea; i++)
            {
                for (int j = 0; j < GameArea.LengthArea; j++)
                {
                    GameArea[i, j] = successNumber;
                    successNumber++;
                }
            }

            GameArea[GameArea.LengthArea - 1, GameArea.LengthArea - 1] = 0;
        }
    }
}

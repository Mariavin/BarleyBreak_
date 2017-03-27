using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data.GameElement
{
    public class Area
    {
        private int[,] Field { get; set; }

        private int lengthArea;

        public int LengthArea
        {
            get
            {
                return lengthArea;
            }
            set
            {
                if (value - Math.Truncate((decimal)value) == 0)
                {
                    lengthArea = value;
                }
            }
        }

        public Area(int[] n)
        {
            var N = Math.Sqrt(n.Length);
            if (N - Math.Truncate(N) == 0)
            {
                LengthArea = (int)N;
                Field = GenerateField(n);
            }           
            else throw new Exception("Error:It is impossible to form a square box!");
            IsValid(n);
        }

        public Area(int lengthArea)
        {
            var N = Math.Sqrt(lengthArea);
            if (N - Math.Truncate(N) == 0)
            {
                var randomMass = GenerateRandomValue(lengthArea);
                LengthArea = (int)N;
                Field = GenerateField(randomMass);
                SetZeroValue();

            }
            else throw new Exception("Error:It is impossible to form a square box!");
        }

        public bool IsValid(int[] n )
        {
            for (int i = 0; i < n.Length; i++)
                if (n[i] < 0)
                    throw new Exception("Error: There is a negative element on the field!");

            for (int i = 0; i < n.Length; i++)
            {
                if (i + 1 != n.Length && n[i] == n[i + 1])
                    throw new Exception("Error:There are duplicate element in the box!");
            }

            for (int i = 0; i < n.Length; i++)
            {
                if (!n.Contains(i))
                    throw new Exception("Error:The field is filled with invalid items!");
            }
            return true;
        }

        public int this[int x, int y]
        {
            get
            {
                return (GetValueArea(x, y));
            }
            set
            {
                Field[x, y] = value;
            }
        }

        private int[] GenerateRandomValue(int n)
        {
            int[] rezult = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int value = random.Next(-1, n);
                while (IsExistValue(rezult,value))
                {
                    value = random.Next(-1, n);
                }
                rezult[i] = value;
            }
            return rezult;
        }

        private bool IsExistValue(int[] m, int value)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == value)
                    return true;
            }
            return false;
        }

        private int[,] GenerateField(int[] n)
        {
            int index = 0;
            var Field = new int[(int)LengthArea, (int)LengthArea];
            for (int i = 0; i < LengthArea; i++)
            {
                for (int j = 0; j < LengthArea; j++)
                {
                    Field[i, j] = n[index];
                    index++;
                }
            }
            return Field;
        }

        private int GetValueArea(int x, int y)
        {
            return Field[x, y];
        }

        private void SetZeroValue()
        {
            for (int i = 0; i < LengthArea; i++)
            {
                for (int j = 0; j < LengthArea; j++)
                {
                    if (Field[i, j] == -1)
                        Field[i, j] = 0;
                }
            }
        }
    }
}

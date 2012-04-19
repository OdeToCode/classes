using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeLogic
{
    public class ArrayChanger
    {
        public void ChangeValues(int[] values)
        {
            for(int i = 0; i < values.Length; i++)
            {
                values[i] += 1;
            }
        }

        public void ChangeValues(ref int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] += 1;
            }
        }

        public void ChangeArray(int[] values)
        {
            values = new int[] {4, 5, 6};
        }

        public void ChangeArray(ref int[] values)
        {
            values = new int[] { 4, 5, 6 };
        }
    }
}

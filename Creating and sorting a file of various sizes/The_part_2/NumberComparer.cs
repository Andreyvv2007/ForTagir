using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_part_2
{
    internal class NumberComparer : IComparer<NameString>
    {
        public static int NumerReturn { get; private set; }

        public int Compare(NameString n1, NameString n2)
        {
            if (n1.Number > n2.Number)
            {
                NumerReturn = 1;
                return 1;
            }
            else if (n1.Number < n2.Number)
            {
                NumerReturn = -1;
                return -1;
            }
            else
            {
                NumerReturn = 0;
                return 0;
            }
        }
    }
}

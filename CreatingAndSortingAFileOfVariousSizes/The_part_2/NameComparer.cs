using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_part_2
{
    internal class NameComparer : IComparer<NameString>
    {
        public int Compare(NameString n1, NameString n2)
        {
            int cmpVal = n1.Name.CompareTo(n2.Name);
            NumberComparer comparer = new NumberComparer();

            if (cmpVal > 0)
            {
                return 1;
            }
            else if (cmpVal < 0)
            {
                return -1;
            }
            else
            {
                comparer.Compare(n1, n2);
                return NumberComparer.NumerReturn;
            }
        }
    }
}

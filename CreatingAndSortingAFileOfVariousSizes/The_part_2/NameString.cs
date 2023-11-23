using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_part_2
{
    internal class NameString
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public int IndexFile { get; private set; }

        public NameString(int number, string name)
        {
            Number = number;
            Name = name;
            IndexFile = 0;
        }

        public NameString(int number, string name, int index)
        {
            Number = number;
            Name = name;
            IndexFile = index;
        }
    }
}

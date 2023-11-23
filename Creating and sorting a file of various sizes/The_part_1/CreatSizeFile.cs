using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_part_1
{
    internal class CreatSizeFile
    {
        static int _AddValue(string txt)
        {
            Console.Write($"Enter the file size in {txt}: ");
            var _val = Convert.ToInt32(Console.ReadLine());
            return _val;
        }

        public static long CreatSizeValue()
        {
            long _sizeFile;
            string _sizeName;
            Console.WriteLine("Select the file size unit: ");
            Console.WriteLine("1 - Bytes; 2 - Kilobytes; 3 - Megabytes; 4 - Gigabytes");
            byte i = Convert.ToByte(Console.ReadLine());
            switch (i) 
            {
                case 1:
                    _sizeName = "bytes";
                    _sizeFile = _AddValue(_sizeName);
                    break;
                case 2:
                    _sizeName = "kilobytes";
                    _sizeFile = _AddValue(_sizeName) * (long)Math.Pow(2, 10);
                    break;
                case 3:
                    _sizeName = "megabytes";
                    _sizeFile = _AddValue(_sizeName) * (long)Math.Pow(2, 20);
                    break;
                case 4:
                    _sizeName = "gigabytes";
                    _sizeFile = _AddValue(_sizeName) * (long)Math.Pow(2, 30);
                    break;
                default:
                    Console.WriteLine("You haven't selected the size from the specified");
                    _sizeFile = 0;
                    break;
            }
            return _sizeFile;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace The_part_1
{
    internal class CreatText
    {
        static Random _rnd = new Random();
        static string[] line = File.ReadAllLines("EnglandDictionary.txt", Encoding.Default);
        
        public static void AddLineText(FileInfo file, long valByte)
        {
            string txt = _AddString();
            StringBuilder sb = new StringBuilder();

            using (StreamWriter sw = file.CreateText())
            {
                while (valByte > 0)
                {
                    sb.Length = 0;
                    if (_ShowBool())
                    {
                        txt = _AddString();
                    }
                    string _allLine = sb.AppendFormat(_AddNum() + txt).ToString();
                    sw.WriteLine(_allLine);
                    valByte -= (ASCIIEncoding.UTF8.GetByteCount(_allLine) + 2);
                    //Console.WriteLine("Размер файла осталось" + valByte);
                }
            }                
        }
        
        static string _AddNum() => _rnd.Next(1, 999999999).ToString() + ". ";

        static string _FineWords() => line[_rnd.Next(1, line.Length - 1)];

        static bool _ShowBool() => _rnd.Next(1, 3) % 2 == 0 ? true : false;

        static string _AddString()
        {
            StringBuilder _sb = new StringBuilder();
            byte _sizeLine = (byte)_rnd.Next(3, 10);

            for (int i = 0; i < _sizeLine; i++) 
            {
                _sb.Append(_FineWords() + " ");
            }
            return _sb.ToString();
        }
    }
}

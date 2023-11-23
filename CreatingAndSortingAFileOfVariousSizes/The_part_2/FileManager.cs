using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_part_2
{
    internal static class FileManager
    {
        public static string[] NameTempFiles { get; private set; } = _GenerateTemporaryFileNames(FileProcessor.NumberOfTemporaryFiles);

        public static void CreatTempFiles()
        {
            using (StreamReader sr = new StreamReader(FileProcessor.InputFilePath))
            {
                for (int i = 0; i < NameTempFiles.Length; i++)
                {
                    _WriteListNameStringsToFile(NameTempFiles[i], _AddListNameStringsFromInputFile(sr));
                }
            }
        }

        static void _WriteListNameStringsToFile(string fileName, List<NameString> nameStrings)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                foreach (NameString value in nameStrings)
                {
                    writer.WriteLine($"{value.Number}.{value.Name}");
                }
            }
        }

        static List<NameString> _AddListNameStringsFromInputFile(StreamReader sr)
        {
            List<NameString> _names = new List<NameString>();
            long _totalSize = 0;

            while (_totalSize < FileProcessor.SizeOfTemporaryFiles)
            {
                string[] _tempArr = SplitLineFromStreamReader(sr);

                if (_tempArr.Length == 2)
                {
                    _names.Add(new NameString(Convert.ToInt32(_tempArr[0]), _tempArr[1]));
                    _totalSize += (Encoding.UTF8.GetByteCount(_tempArr[0] + "." + _tempArr[1]) + 2);
                }
                else
                {
                    break;
                }
            }

            _names.Sort(new NameComparer());
            return _names;
        }

        public static string[] SplitLineFromStreamReader(StreamReader sr)
        {
            string _line = sr.ReadLine();
            string[] _tempArr;


            if (!CheckingValueForNull(_line))
            {
                _tempArr = _line.Split('.');
            }
            else
            {
                _tempArr = new string[0];
            }

            return _tempArr;
        }

        public static bool CheckingValueForNull(object name)
        {
            if (name == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CheckingValueForNull(string[] arr)
        {
            if (arr.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static string[] _GenerateTemporaryFileNames(long numberOfFiles)
        {
            const string _nameTempFile = "SortedTemporaryFile";
            string[] _tempFileNames = new string[numberOfFiles];

            for (int i = 0; i < numberOfFiles; i++)
            {
                _tempFileNames[i] = $"{_nameTempFile}_{i.ToString("D8")}.txt";
            }

            return _tempFileNames;
        }
    }
}

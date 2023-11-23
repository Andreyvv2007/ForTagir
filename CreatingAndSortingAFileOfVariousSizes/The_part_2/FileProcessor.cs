using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Management;
using System.Diagnostics;

namespace The_part_2
{
    internal static class FileProcessor
    {
        public static string InputFilePath { get; private set; } = "CreatAppText.txt";

        public static long SizeOfInputFile { get; private set; } = _FindOutFileSize(InputFilePath);
        public static long SizeOfFreeMemory { get; private set; } = _GetFreePhysicalMemorySize();

        public static long SizeOfTemporaryFiles { get; private set; } = SizeOfInputFile <= SizeOfFreeMemory ? SizeOfInputFile : SizeOfFreeMemory;
        public static long NumberOfTemporaryFiles { get; private set; } = _CalculateNumberOfTemporaryFiles();

        static long _FindOutFileSize(string path)

        {
            FileInfo file = new FileInfo(InputFilePath);
            long _byteSize = file.Length;
            return _byteSize;
        }

        static long _GetFreePhysicalMemorySize()
        {
            long _result;

            //PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available Bytes");
            //_result = Convert.ToInt64(ramCounter.NextValue());

            // чтобы уменьшить оперативку для тестов (и соответственно увеличить количество временных файлов)
            //  нужно закоментить предыдущие две строчки кода и раскоментить нижнюю
            _result = SizeOfInputFile / 3;

            return _result;
        }

        static long _CalculateNumberOfTemporaryFiles()
        {
            long _numberOfFiles;

            if (SizeOfTemporaryFiles >= SizeOfFreeMemory)
            {
                _numberOfFiles = SizeOfInputFile / SizeOfFreeMemory;
                
                if (_numberOfFiles == 0)
                {
                    _numberOfFiles++;
                }
            }
            else
            {
                _numberOfFiles = 1;
            }

            return _numberOfFiles;
        }
    }
}

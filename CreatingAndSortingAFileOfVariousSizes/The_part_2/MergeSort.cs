using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace The_part_2
{
    internal class MergeSort
    {
        public static string OutputFilePath { get; private set; } = $"{FileProcessor.InputFilePath}_Merged.txt";

        public static void MergeSortAndMergeDocuments()
        {
            if(FileManager.NameTempFiles.Length == 1)
            {
                File.Move(FileManager.NameTempFiles[0], OutputFilePath, true);
                return;
            }
            else
            {
                List<StreamReader> readers = new List<StreamReader>();
                List<NameString> names = new List<NameString>();
                StreamWriter writer = new StreamWriter(OutputFilePath, false);
                int count = 0;


                for (int i = 0; i < FileManager.NameTempFiles.Length; i++)
                {
                    readers.Add(new StreamReader(FileManager.NameTempFiles[i]));
                }

                while (readers.Count > 0)
                {
                    if (names.Count != 0)
                    {
                        NameString _tempName = _AddNameStringFromFileToList(readers[count], count);
                        if (!FileManager.CheckingValueForNull(_tempName))
                        {
                            names.Add(_tempName);
                        }
                        else
                        {
                            readers[count].Close();
                            readers.Remove(readers[count]);
                            File.Delete(FileManager.NameTempFiles[count]);
                        }
                    }
                    else
                    {
                        names = _CreatListNameStringsFromTempFiles(readers);
                    }

                    names.Sort(new NameComparer());

                    if (names.Count > 0)
                    {
                        count = names[0].IndexFile;
                        writer.WriteLine($"{names[0].Number}.{names[0].Name}");
                        names.Remove(names[0]);
                    }
                }

                if (File.Exists(FileManager.NameTempFiles[count]))
                {
                    File.Delete(FileManager.NameTempFiles[count]);
                }
                writer.Close();
            }
        }

        static List<NameString> _CreatListNameStringsFromTempFiles(List<StreamReader> sr)
        {
            List<NameString> _names = new List<NameString>();

            for (int i = 0; i < sr.Count; i++)
            {
                NameString _tempName = _AddNameStringFromFileToList(sr[i], i);
                if (FileManager.CheckingValueForNull(_tempName))
                {
                    sr[i].Close();
                    sr.Remove(sr[i]);
                }
                else
                {
                    _names.Add(_tempName);
                }
            }
            
            return _names;
        }

        static NameString _AddNameStringFromFileToList(StreamReader sr, int index)
        {
            NameString name;
            string[] _tempArr = FileManager.SplitLineFromStreamReader(sr);

            if (!FileManager.CheckingValueForNull(_tempArr))
            {
                name = new NameString(Convert.ToInt32(_tempArr[0]), _tempArr[1], index);
            }
            else
            {
                name = null;
            }

            return name;
        }
    }
}

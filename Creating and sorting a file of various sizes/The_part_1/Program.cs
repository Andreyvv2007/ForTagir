using System.Text;

namespace The_part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allSize = CreatSizeFile.CreatSizeValue();
            var path = "CreatAppText.txt";
            
            FileInfo text = new FileInfo(path);

            CreatText.AddLineText(text, allSize);

            Console.WriteLine("File creation completed");
            Console.ReadLine();
        }
    }
}
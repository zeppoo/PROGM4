using System.IO;

namespace FileIOOpdracht
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir1 = "D:\\Rein\\Scripts\\C#\\PROGM4\\FileIOOpdracht\\FileIOOpdracht\\leesdezefile.txt";
            string[] content = File.ReadAllLines(dir1);

            for (int i = 0; i < content.Length; i++)
            {
                Console.WriteLine(content[i]);
            }


            string[] text = { ":P", "Het werkt" };
            Directory.CreateDirectory("d:\\Rein\\Scripts\\C#\\PROGM4\\FileIOOpdracht\\FileIOOpdracht\\output");
            File.WriteAllLines("d:\\Rein\\Scripts\\C#\\PROGM4\\FileIOOpdracht\\FileIOOpdracht\\output\\mijnnieuwefile.txt", text);

            Program program = new Program();
            program.PrintAllInfo();
        }
        
        void PrintAllInfo()
        {
            string dir2 = "D:\\Rein\\Scripts\\C#\\PROGM4\\FileIOOpdracht\\FileIOOpdracht";
            string[] allDirs = Directory.GetDirectories(dir2, "*", SearchOption.AllDirectories);
            string[] allFiles = Directory.GetFiles(dir2, "*", SearchOption.AllDirectories);
            for (int i = 0; i < allDirs.Length; i++)
            {
                Console.WriteLine(allDirs[i]);
            }

            for (int i = 0; i < allFiles.Length; i++)
            {
                Console.WriteLine(allFiles[i]);
            }
        }
    }
}
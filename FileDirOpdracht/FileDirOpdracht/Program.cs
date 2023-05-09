namespace FileDirOpdracht
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"d:\Rein\Scripts\C#\PROGM4");
            FileInfo[] lol = dir.GetFiles();
            for (int i = 0; i < lol.Length; i++) 
            {
                Console.WriteLine(lol[i]);
            }
            DirectoryInfo[] directoryInfos = dir.GetDirectories();

            for (int i = 0;i < directoryInfos.Length; i++) 
            {
                Console.WriteLine(directoryInfos[i]);
            }

        }
    }
}
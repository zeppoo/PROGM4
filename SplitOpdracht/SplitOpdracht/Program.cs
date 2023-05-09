namespace SplitOpdracht
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String content = File.ReadAllText("D:\\Rein\\Scripts\\C#\\SplitOpdracht\\SplitOpdracht\\stringsplit.txt");
            string[] keyvalue = content.Split(":");
            Console.WriteLine(keyvalue[0]);
            string[] cijfersPerVak = keyvalue[1].Split(",");
            for (int i = 0; i < keyvalue.Length; i++)
            {
                Console.WriteLine(cijfersPerVak[i].Replace(" ", ""));
            }
            
        }
    }
}
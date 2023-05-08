namespace ConsoleMonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestConstructors();
        }

        static void TestConstructors()
        {
            Console.WriteLine("TestConstructors");
            ConsoleMon mon = new ConsoleMon(200, 200, "ConsoleColorMon", Element.Earth);

            Console.WriteLine(mon.energy == 200);
            Console.WriteLine(mon.name == "ConsoleColorMon");
            Console.WriteLine(mon.health == 200);
            Console.WriteLine(mon.weakness == Element.Earth);


            Skill skill = new Skill(90, 80, "FireBlade", Element.Fire);
            Console.WriteLine(skill.energyCost == 80);
            Console.WriteLine(skill.name == "FireBlade");
            Console.WriteLine(skill.damage == 90);
            Console.WriteLine(skill.element == Element.Fire);

        }
    }
}
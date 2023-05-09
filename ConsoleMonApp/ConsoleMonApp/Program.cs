namespace ConsoleMonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestConsoleMonFunctions();
            TestSkillFunctions();
            TestSkillFunctions2();
            TestFactoryFunctions();
            TestFactoryFunctions2();
            TestCopySkill();
            TestCopyConsoleMon();
        }

        static void TestConsoleMonFunctions()
        {
            Console.WriteLine("\nTestConsoleMonFunctions");
            ConsoleMon mon = new ConsoleMon();
            mon.TakeDamage(100);
            mon.DepleteEnergy(20);

            Console.WriteLine(mon.health == -100);

            Console.WriteLine(mon.energy == -20);
        }
        static void TestSkillFunctions()
        {
            Console.WriteLine("\nTestSkillFunctions");
            ConsoleMon casterMon = new ConsoleMon();
            ConsoleMon targetMon = new ConsoleMon();
            Skill skill = new Skill()
            {
                damage = 100,
                energyCost = 20,
            };
            skill.UseOn(targetMon, casterMon);

            Console.WriteLine(targetMon.health == -100);

            Console.WriteLine(casterMon.energy == -20);
        }

        static void TestSkillFunctions2()
        {
            Console.WriteLine("\nTestSkillFunctions 2");
            ConsoleMon casterMon = new ConsoleMon();
            ConsoleMon targetMon = new ConsoleMon();
            Skill skill = new Skill()
            {
                damage = 100,
                energyCost = 20,
            };
            skill.UseOn(targetMon, casterMon);

            Console.WriteLine(targetMon.health == -150);

            Console.WriteLine(casterMon.energy == -20);
        }


        static void TestFactoryFunctions()
        {
            Console.WriteLine("\nTestFactoryFunctions");
            ConsoleMonFactory factory = new ConsoleMonFactory();
            factory.Load("monsterdata.txt");
        }

        static void TestFactoryFunctions2()
        {
            Console.WriteLine("\nTestFactoryFunctions 2");
            ConsoleMonFactory factory = new ConsoleMonFactory();
            factory.Load("monsterdata.txt");
            factory.LoadJson("monsterdata.json");
        }

        static void TestCopySkill()
        {
            Console.WriteLine("\nTestCopySkill");
            ConsoleMonFactory factory = new ConsoleMonFactory();
            List<ConsoleMon> templates = factory.LoadJson("monsterdata.json");
            Skill copyFrom = templates[0].skills[0];

            Skill copy = factory.CopySkill(copyFrom);
            Console.WriteLine(copy.name == copyFrom.name);
            Console.WriteLine(copy.damage == copyFrom.damage);
            Console.WriteLine(copy.element == copyFrom.element);
            copy.name = "anders";
            Console.WriteLine(copy.name != copyFrom.name);
        }

        static void TestCopyConsoleMon()
        {
            Console.WriteLine("TestCopyConsoleMon");
            ConsoleMonFactory factory = new ConsoleMonFactory();
            List<ConsoleMon> templates = factory.LoadJson("monsterdata.json");
            ConsoleMon copyFrom = templates[0];

            ConsoleMon copy = factory.CopyConsoleMon(copyFrom);
            Console.WriteLine(copy.name == copyFrom.name);
            Console.WriteLine(copy.health == copyFrom.health);
            Console.WriteLine(copy.skills == copyFrom.skills);
            Console.WriteLine(copy.skills[0] == copyFrom.skills[0]);
            copy.name = "anders";
            copy.skills[0].name = "newskill";
            Console.WriteLine(copy.name != copyFrom.name);
            Console.WriteLine(copy.skills[0].name != copyFrom.skills[0].name);
        }
    }
}
﻿namespace ConsoleMonApp
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
            TestConstructors();
            TestCopySkill();
            TestCopyConsoleMon();
            TestArena();
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

        static void TestConstructors()
        {
            Console.WriteLine("\nTestConstructors");
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

        static void TestArena()
        {
            ConsoleMonFactory factory = new ConsoleMonFactory();
            List<ConsoleMon> templates = factory.LoadJson("monsterdata.json");
            ConsoleMon FighterA = templates[0];
            ConsoleMon FighterB = templates[1];
            Arena battle = new Arena();
            battle.Fight(FighterA, FighterB);
        }
    }
}
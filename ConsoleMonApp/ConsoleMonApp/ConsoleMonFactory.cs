using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleMonApp
{
    internal class ConsoleMonFactory
    {
        internal void Load(string datafile)
        {
            string[] lines = File.ReadAllLines(datafile);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] typeSplit = lines[i].Split('|');
                string[] consoleMonData = typeSplit[0].Split(',');
                string[] consoleMonSkills = typeSplit[1].Split(";");
                consoleMonSkills = consoleMonSkills[1].Split(",");
                ConsoleMon dataMon = new ConsoleMon();
                Skill dataSkill = new Skill();
                dataMon.name = consoleMonData[0];
                dataMon.health = Int32.Parse(consoleMonData[2]);
                dataMon.energy = Int32.Parse(consoleMonData[4]);
                dataMon.weakness = (Element)Enum.Parse(typeof(Element), consoleMonData[6], true);
                dataSkill.name = consoleMonSkills[0];
                dataSkill.damage = Int32.Parse(consoleMonSkills[2]);
                dataSkill.energyCost = Int32.Parse(consoleMonSkills[4]);
                dataSkill.element = (Element)Enum.Parse(typeof(Element), consoleMonSkills[6], true);
                Console.WriteLine("\n" + dataMon.name);
                Console.WriteLine(consoleMonData[1] + ": " + dataMon.health);
                Console.WriteLine(consoleMonData[3] + ": " + dataMon.energy);
                Console.WriteLine(consoleMonData[5] + ": " + dataMon.weakness);
                Console.WriteLine(dataSkill.name);
                Console.WriteLine(consoleMonSkills[1] + ": " + dataSkill.damage);
                Console.WriteLine(consoleMonSkills[3] + ": " + dataSkill.energyCost);
                Console.WriteLine(consoleMonSkills[5] + ": " + dataSkill.element);
            }
        }
        internal List<ConsoleMon> LoadJson(string datafile)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
            string json = File.ReadAllText(datafile);
            Console.WriteLine(json);
            List<ConsoleMon> templates = JsonSerializer.Deserialize<List<ConsoleMon>>(json, options);
            Console.WriteLine(templates[0].name);
            return templates;
        }

        internal Skill CopySkill(Skill copyFrom)
        {
            Skill copyResult = new Skill(copyFrom.damage, copyFrom.energyCost, copyFrom.name, copyFrom.element);
            return copyResult;
        }

        internal ConsoleMon CopyConsoleMon(ConsoleMon copyFrom)
        {
            ConsoleMon copyResult = new ConsoleMon(copyFrom.health, copyFrom.energy, copyFrom.name, copyFrom.weakness);
            copyResult.skills = new List<Skill>();
            for (int i = 0; i < copyFrom.skills.Length; i++)
            {

                copyResult.skills.add(CopySkill(copyFrom.skills[i]));
            }
            return copyResult;
        }
    }
}

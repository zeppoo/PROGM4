using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonApp
{
    internal class Arena
    {
        internal void Fight(ConsoleMon FighterA, ConsoleMon FighterB)
        {
            Random rnd = new Random();
            int skill;

            Console.WriteLine(FighterA.name + " is in a battle with " + FighterB.name + "!\n");

            while (FighterA.health > 0 && FighterB.health > 0)
            {
                skill = rnd.Next(0, 2);
                if (FighterA.energy >= FighterA.skills[skill].energyCost)
                {
                    
                    Console.WriteLine(FighterA.name + " used " + FighterA.skills[skill].name + "!");
                    FighterA.skills[skill].UseOn(FighterB, FighterA);
                    Console.WriteLine(FighterB.name + " is down to " + FighterB.health + "HP\n");
                }
                else
                {
                    Console.WriteLine(FighterA.name + " used " + FighterA.skills[2].name + "!");
                    FighterA.skills[0].Rest(FighterA);
                    Console.WriteLine(FighterA.name + " regained energy\n");
                }

                if (FighterB.health <= 0)
                {
                    Console.WriteLine(FighterB.name + " has fainted \n" + FighterA.name + " has won!");
                }

                skill = rnd.Next(0, 2);
                if (FighterB.energy >= FighterB.skills[skill].energyCost)
                {
                    
                    Console.WriteLine(FighterB.name + " used " + FighterB.skills[skill].name + "!");
                    FighterB.skills[skill].UseOn(FighterA, FighterB);
                    Console.WriteLine(FighterA.name + " is down to " + FighterA.health + "HP\n");
                }
                else
                {
                    Console.WriteLine(FighterB.name + " used " + FighterB.skills[2].name + "!");
                    FighterB.skills[0].Rest(FighterB);
                    Console.WriteLine(FighterB.name + " regained energy\n");
                }

                if (FighterA.health <= 0)
                {
                    Console.WriteLine(FighterA.name + " has fainted \n" + FighterB.name + " has won!");
                }
            }
        }
    }
}

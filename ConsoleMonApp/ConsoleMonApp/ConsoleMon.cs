using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonApp
{
    internal class ConsoleMon
    {
        internal int health;
        internal int energy;
        internal string name;
        private Skill[] skills;
        internal Element weakness = Element.Fire;

        public ConsoleMon() 
        {

        }

        internal ConsoleMon(int health, int energy, string name, Element weakness)
        {
            this.health = health;
            this.energy = energy;
            this.name = name;
            this.weakness = weakness;
        }

        internal void TakeDamage(int damage)
        {
            this.health -= damage;
        }

        internal void DepleteEnergy(int energy)
        {
            this.energy -= energy;
        }
    }
}

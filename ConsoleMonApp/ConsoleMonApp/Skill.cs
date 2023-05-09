using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonApp
{
    internal class Skill
    {
        public int damage { get; set; }
        public int energyCost { get; set; }
        public string name { get; set; }
        public Element element { get; set; }

        public Skill()
        {

        }

        internal Skill(int damage, int energyCost, string name, Element element)
        {
            this.damage = damage;
            this.energyCost = energyCost;
            this.name = name;
            this.element = element;
        }
        

        internal void UseOn(ConsoleMon target, ConsoleMon caster)
        {
            caster.DepleteEnergy(energyCost);
            if (target.weakness == element)
            {
                target.TakeDamage(damage/2);
                target.TakeDamage(damage);
            }
            else
            {
                target.TakeDamage(damage);
            }
        }
    }
}

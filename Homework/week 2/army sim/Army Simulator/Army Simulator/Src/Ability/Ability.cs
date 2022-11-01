using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Army_Simulator.Src.Unit
{
    public class Ability
    {
        public string AbilityName { get; private set; }
        public string AbilityDescription { get; private set; }
        public int Stat { get; private set; }
        public string AbilityType { get; private set; }

        public Ability(string abilityName, string abilityDescription, int stat, string abilityType)
        {
            AbilityName = abilityName;
            AbilityDescription = abilityDescription;
            Stat = stat;
            AbilityType = abilityType;
        }

        public override string ToString()
        {
            return " Ability name: " + AbilityName + "\n Description: " + AbilityDescription + " \n Stat: " + Stat
                + "\n Ability type: " + AbilityType;
        }
    }
}

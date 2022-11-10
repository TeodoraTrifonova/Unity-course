using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public class Priest : Unit
    {
        public Priest(string unitName, int level, int xp, int range, Ability ability, int attack, int health, string allegeance, int row, int col) : base(unitName, level, xp, range, ability, attack, health, allegeance, row, col)
        {
        }

        public void UseAbility(Unit caster, Unit target)
        {
            if (IsAlly(caster, target) && caster.Ability.AbilityType == "heal")
            {
                target.Health = caster.Ability.Stat + target.Health;
                HealMessage(caster, target);
            }
        }
    }
}

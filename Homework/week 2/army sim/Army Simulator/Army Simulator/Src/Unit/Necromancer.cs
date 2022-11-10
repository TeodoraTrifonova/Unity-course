using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public class Necromancer : Unit
    {
        public Necromancer(string unitName, int level, int xp, int range, Ability ability, int attack, int health, string allegeance, int row, int col) : base(unitName, level, xp, range, ability, attack, health, allegeance, row, col)
        {
        }
        public void UseAbility(Unit caster, Unit target)
        {
            if (IsInRange(caster, target) && !(IsAlly(caster, target)))
            {
                target.Health = target.Health - caster.Ability.Stat;
                caster.Health = caster.Ability.Stat / 2 + caster.Health;
                if (target.Health < 0)
                {
                    target.Health = 0;
                    caster.Level += 1;
                    DeathMessage(caster, target);
                }
                else
                {
                    CastMagicMessage(caster, target);
                }
            }
        }
    }
}

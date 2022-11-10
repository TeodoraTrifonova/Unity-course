using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public class Hunter : Unit
    {
        public Hunter(string unitName, int level, int xp, int range, Ability ability, int attack, int health, string allegeance, int row, int col) : base(unitName, level, xp, range, ability, attack, health, allegeance, row, col)
        {
        }

        public void UseAbility(Unit caster, Unit target)
        {
            if (IsInRange(caster, target) && !(IsAlly(caster, target)))
            {
                Random random = new Random();
                int crit = random.Next(0, 100);
                if (crit < 50)
                {

                    target.Health = target.Health - caster.Ability.Stat;
                }
                else
                {
                    target.Health = target.Health - caster.Ability.Stat * 2;
                }

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

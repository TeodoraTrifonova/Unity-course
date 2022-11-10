using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public abstract class Unit
    {
        public string UnitName { get; private set; }
        public int Level { get;  set; }
        public int Xp { get;  set; }
        public int Range { get;  set; }
        public Ability Ability { get;  set; }
        public int Attack { get;  set; }
        public int Health { get; set; }
        public string Allegeance { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Unit(string unitName, int level, int xp, int range, Ability ability, int attack, int health, string allegeance, int row, int col)
        {
            UnitName = unitName;
            Level = level;
            Xp = xp;
            Range = range;
            Ability = ability;
            Attack = attack;
            Health = health;
            Allegeance = allegeance;
            Row = row;
            Col = col;
        }

        public Unit(Unit unit)
        {
            UnitName = unit.UnitName;
            Level = unit.Level;
            Xp = unit.Xp;
            Range = unit.Range;
            Ability = unit.Ability;
            Attack = unit.Attack;
            Health = unit.Health;
            Allegeance = unit.Allegeance;
            Row = unit.Row;
            Col = unit.Col;
        }


        void AbilityInfo(Unit unit)
        {
            unit.Ability.ToString();
        }

        void GetUnitInfo(Unit unit)
        {
            Console.WriteLine(" Name: " + UnitName + "\n Level: " + Level + "\n Xp: " + Xp + "\n Range: " +
            Range + "\n" + Ability.ToString() + "\n Attack: " + Attack + "\n Health: " + Health);
        }



        void AttackUnit(Unit attacker, Unit target)
        {
            if (IsAlly(attacker, target))
            {
                Console.WriteLine("You can't attack allies!");
            }
            else
            {
                target.Health = target.Health - attacker.Attack;
                if (target.Health < 0)
                {
                    target.Health = 0;
                    attacker.Level += 1;
                    DeathMessage(attacker, target);
                }
                else
                {
                    AttackMessage(attacker, target);
                }
            }

        }

        //public void UseAbility(Unit caster, Unit target)
        //{
        //    if (IsAlly(caster, target) && caster.Ability.AbilityType == "heal")
        //    {
        //        target.Health = caster.Ability.Stat + target.Health;
        //        HealMessage(caster, target);
        //    }
        //    else if (!(IsAlly(caster, target)) && caster.Ability.AbilityType == "damage")
        //    {
        //        target.Health = target.Health - caster.Ability.Stat;

        //        if (target.Health < 0)
        //        {
        //            target.Health = 0;
        //            caster.Level += 1;
        //            DeathMessage(caster, target);
        //        }
        //        else
        //        {
        //            CastMagicMessage(caster, target);
        //        }
        //    }

        //}

        public override string ToString()
        {
            return "\n\n Name: " + UnitName + "\n Level: " + Level + "\n Xp: " + Xp + "\n Range: " +
             Range + "\n" + Ability.ToString() + "\n Attack: " + Attack + "\n Health: " + Health;

        }
        public bool IsInRange(Unit atacker, Unit target)
        {
            int distance = 0;
            if (atacker.Row == target.Row)
            {
                distance = atacker.Row - target.Row;
                if(distance<0)
                { 
                    distance = distance * (-1); 
                }
                if(distance > atacker.Range)
                {
                    return true;
                }
            }
            else if (atacker.Col == target.Col)
            {
                distance = atacker.Col - target.Col;
                if (distance < 0)
                {
                    distance = distance * (-1);
                }
                if (distance > atacker.Range)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAlly(Unit unit, Unit unit1)
        {
            if (unit.Allegeance == unit1.Allegeance)
            {
                return true;
            }
            return false;
        }

        public void DeathMessage(Unit killer, Unit killed)
        {
            Console.WriteLine(killer.UnitName + " has killed " + killed.UnitName + " and leveled up!");
        }

        public void AttackMessage(Unit attacker, Unit target)
        {
            Console.WriteLine(attacker.UnitName + " has damaged " + target.UnitName + " and dealt " + attacker.Attack + " damage!");
            Console.WriteLine(target.UnitName + " has " + target.Health + "health left");
        }

        public void CastMagicMessage(Unit caster, Unit target)
        {
            Console.WriteLine(caster.UnitName + " has damaged " + target.UnitName + " and dealt " + caster.Attack + " damage!\n");
            Console.WriteLine(target.UnitName + " has " + target.Health + "health left");
        }

        public void HealMessage(Unit caster, Unit target)
        {
            Console.WriteLine(caster.UnitName + " has healed " + target.UnitName + " for" + caster.Ability.Stat + " points!\n");
            Console.WriteLine(target.UnitName + " has " + target.Health + "health!");
        }
    }
}


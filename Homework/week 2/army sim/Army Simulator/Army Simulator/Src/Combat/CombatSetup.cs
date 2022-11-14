using Army_Simulator.Src.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public class CombatSetup
    {
        public CombatSetup()
        {
            Init();
        }

        public void Init()
        {
            List<Unit> allUnits = GetAllUnitTypes();



            Console.WriteLine("\nPlayer 1 please choose your units\n");
            Army army1 = CreateArmy(allUnits);

            Console.WriteLine("\n\n\n\n\n\nPlayer 2 please choose your units");
            Army army2 = CreateArmy(allUnits);

            Console.Clear();

            Combat combat = new Combat();
            combat.PrepareBattleField(army1, army2);
        }

        public Army CreateArmy(List<Unit> allUnits)
        {
            List<Unit> army1Units = new List<Unit>();

            int unitCount = 0;
            int choice = 0;
            int unitsRemaining = 3;
            do
            {

                Console.WriteLine("\nPlease pick " + unitsRemaining + " units! ");
                int a = 0;
                for (int i = 0; i < allUnits.Count; i++)
                {
                    a = i + 1;
                    Console.WriteLine( a + " " + allUnits[i].UnitName.ToString());
                }

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    unitsRemaining--;
                    Ability assassinAbility = new Ability("Ambush", "Strikes a target (if target has less than 8 hp they are executed)", 5, "damage");
                    Assasin assassin = new Assasin("Assasin", 1, 0, 1, assassinAbility, 6, 14, "None", 0, 0);


                    //  Type unit = new Type(allUnits[choice - 1]);
                    army1Units.Add(assassin);
                    unitCount++;
                }
                catch (Exception e) when (e is FormatException || e is ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\n Number is out of range");
                    unitsRemaining++;
                    unitCount--;
                }


            } while (unitCount < 3 || (choice < 1 || choice > allUnits.Count));


            Console.WriteLine("\n\nInput player name: ");
            string player = Console.ReadLine();

            foreach (Unit unit in army1Units)
            {
                unit.Allegeance = player;
            }
            return new Army(army1Units);


        }


        public List<Unit> GetAllUnitTypes()
        {
            Ability assassinAbility = new Ability("Ambush", "Strikes a target (if target has less than 8 hp they are executed)", 5, "damage");
            Assasin assassin = new Assasin("Assasin", 1, 0, 1, assassinAbility, 6, 14, "None", 0, 0);

            Ability druidAbility = new Ability("Bite", "Turns into a bear and bites enemy", 6, "damage");
            Druid druid = new Druid("Druid", 1, 0, 1, druidAbility, 3, 25, "None", 0, 0);


            Ability hunterAbility = new Ability("Piercing arrow", "Shoot an enemy with a chance to crit", 4, "gamage");
            Hunter hunter = new Hunter("Hunter", 1, 0, 3, hunterAbility, 4, 15, "None", 0, 0);

            Ability mageAbility = new Ability("Meteor", "Targets all enemies and damages them", 3, "damage");
            Mage mage = new Mage("Mage", 1, 0, 2, mageAbility, 1, 17, "None", 0, 0);


            Ability necromancerAbility = new Ability("Leech", "Drains enemy health and heals", 6, "damage");
            Necromancer necromancer = new Necromancer("Necromancer", 1, 0, 2, necromancerAbility, 1, 17, "None", 0, 0);

            Ability priestAbility = new Ability("Holly light", "Heals ally for small amount", 4, "heal");
            Priest priest = new Priest("Priest", 1, 0, 2, priestAbility, 1, 20, "None", 0, 0);

            Ability warriorAbility = new Ability("Crushing blow", "Hits enemy and heals", 5, "damage");
            Warrior warrior = new Warrior("Warrior", 1, 0, 1, warriorAbility, 3, 25, "None", 0, 0);



            List<Unit> list = new List<Unit>();
            list.Add(assassin);
            list.Add(druid);
            list.Add(mage);
            list.Add(hunter);
            list.Add(necromancer);
            list.Add(priest);
            list.Add(warrior);

            return list;


        }




    }
}

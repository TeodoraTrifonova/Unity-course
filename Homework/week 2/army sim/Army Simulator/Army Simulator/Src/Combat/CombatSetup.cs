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

                Console.WriteLine("\nPlease pic " + unitsRemaining + " units! ");
                int a = 0;
                for (int i = 0; i < allUnits.Count; i++)
                {
                    a = i + 1;
                    Console.WriteLine("\n " + a + " " + allUnits[i].UnitName.ToString());
                }

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    unitsRemaining--;
                    army1Units.Add(allUnits[choice - 1]);
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

            foreach (Unit unit in allUnits)
            {
                unit.Allegeance = player;
            }
            return new Army(army1Units);


        }


        public List<Unit> GetAllUnitTypes()
        {
            Ability heal = new Ability("Holly light", "Heals ally for small amount", 3, "heal");
            Unit cleric = new Unit("Cleric", 1, 0, 2, heal, 1, 20, "None", 0, 0);

            Ability bonk = new Ability("Crushing blow", "Smashes weapon with devastating force", 5, "damage");
            Unit warrior = new Unit("Warrior", 1, 0, 1, bonk, 3, 25, "None", 0, 0);

            Ability arrow = new Ability("Piercing arrow", "Shoot an enemy", 4, "gamage");
            Unit archer = new Unit("Archer", 1, 0, 3, arrow, 4, 15, "None", 0, 0);


            Ability spell = new Ability("Frost", "Throws a snowball", 6, "damage");
            Unit mage = new Unit("Mage", 1, 0, 2, spell, 1, 17, "None", 0, 0);

            Ability stab = new Ability("Ambush", "Strikes a target", 5, "damage");
            Unit assassin = new Unit("Assasin", 1, 0, 1, stab, 6, 14, "None", 0, 0);

            List<Unit> list = new List<Unit>();
            list.Add(cleric);
            list.Add(warrior);
            list.Add(archer);
            list.Add(mage);
            list.Add(assassin);
            return list;


        }

        

    }
}

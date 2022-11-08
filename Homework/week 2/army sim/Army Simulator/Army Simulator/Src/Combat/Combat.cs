using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public class Combat : CombatInterface
    {
        public Unit[,] Map { get; set; }
        public Combat()
        {
            
        }

        public void PrepareBattleField(Army army1, Army army2)
        {
            Map = new Unit[4, 3]; 

            for(int i = 0; i<3; i++)
            {
                army1.Units[i].Row  = 0;
                army1.Units[i].Col = i;
                Map[0, i] = army1.Units[i];
            }

            for (int i = 0; i < 3; i++)
            {
                army2.Units[i].Row = 4;
                army2.Units[i].Col = i;
                Map[3, i] = army2.Units[i];
            }


            ShowBattleField(army1, army2,Map);

        }

        

        public void MoveUnit(Unit unit)
        {
            throw new NotImplementedException();
        }

        public bool CanAttack(Unit attacker, Unit defender)
        {
            throw new NotImplementedException();
        }

        public bool CanMove(Unit unit, string direction)
        {
            throw new NotImplementedException();
        }

        public bool PositionIsEmpty(List<Unit> army1, List<Unit> army2)
        {
            throw new NotImplementedException();
        }

        public void MoveUnit(Unit unit, string direction)
        {
            throw new NotImplementedException();
        }

        public void ShowBattleField(Army army1, Army army2, Unit[,] Map )
        {
            int rowLength = Map.GetLength(0);
            int colLength = Map.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Unit unit = Map[i, j];  

                    if(unit == null)
                    {
                        Console.Write(string.Format("{0} ", "[  ]"));
                    }
                    else
                    {
                         Console.Write(string.Format("{0} ", unit.Allegeance));
                    }
                   
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}

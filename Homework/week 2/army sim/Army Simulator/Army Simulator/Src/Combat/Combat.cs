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


        public void PrepareBattleField(Army army1, Army army2)
        {
            Map = new Unit[4, 3];

            for (int i = 0; i < 3; i++)
            {
                army1.Units[i].Row = 0;
                army1.Units[i].Col = i;
                Map[0, i] = army1.Units[i];
            }

            for (int i = 0; i < 3; i++)
            {
                army2.Units[i].Row = 4;
                army2.Units[i].Col = i;
                Map[3, i] = army2.Units[i];
            }


            ShowBattleField(army1, army2, Map);
            DisplayLegend();
        }


        public void ShowBattleField(Army army1, Army army2, Unit[,] Map)
        {
            int rowLength = Map.GetLength(0);
            int colLength = Map.GetLength(1);
            Console.Write(string.Format("\t"));
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Unit unit = Map[i, j];

                    if (unit == null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("{0} ", "[   ]"));
                    }
                    else
                    {
                        if (army1.Units.Contains(unit))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(string.Format("{0} ", "[ " + unit.UnitName[0] + " ]"));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(string.Format("{0} ", "[ " + unit.UnitName[0] + " ]"));
                        }

                    }

                }
                Console.Write(Environment.NewLine + Environment.NewLine + "\t");
            }

        }

        public void DisplayLegend()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(string.Format(" ** MAP LEGEND **"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(string.Format("\n\tA - Assasin "));
            Console.Write(string.Format("\n\tD - Driud"));
            Console.Write(string.Format("\n\tH - Hunter"));
            Console.Write(string.Format("\n\tM - Mage"));
            Console.Write(string.Format("\n\tN - Necromancer"));
            Console.Write(string.Format("\n\tP - Priest"));
            Console.Write(string.Format("\n\tW - Warrior\n"));
            Console.ForegroundColor = ConsoleColor.White;
        }


        public bool CanAttack(Unit attacker, Unit defender, Unit[,] Map)
        {
            throw new NotImplementedException();
        }

        public bool CanMove(Unit unit, string direction, Unit[,] Map)
        {
            switch (direction)
            {
                case "up":

                    if (PositionIsEmpty(unit.Row + 1, unit.Col))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case "down":
                    if (PositionIsEmpty(unit.Row - 1, unit.Col))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case "left":

                    if (PositionIsEmpty(unit.Row, unit.Col - 1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case "right":
                    if (PositionIsEmpty(unit.Row, unit.Col + 1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case "default":
                    Console.WriteLine("\nWrong direction!");
                    return false;
                    break;
            }
            return false;
        }

        public void MoveUnit(Unit unit, Unit[,] Map)
        {
            Console.WriteLine("Where do you want to go?  up/down/left/right\n");
            string direction = Console.ReadLine();
            if (CanMove(unit, direction, Map))
            {
                Unit temp = unit;
                switch (direction)
                {
                    case "up":
                        unit.Row++;
                        Map[temp.Row, temp.Col] = null; 
                        break;

                    case "down":
                        unit.Row--;
                        Map[temp.Row, temp.Col] = null;
                        break;

                    case "left":
                        unit.Col--;
                        Map[temp.Row, temp.Col] = null;
                        break;

                    case "right":
                        unit.Col++;
                        Map[temp.Row, temp.Col] = null;
                        break;

                    case "default":
                        Console.WriteLine("\nWrong direction!");

                        break;
                }

            }
        }

        public bool PositionIsEmpty(int row, int col)
        {

            if (Map[row, col] == null)
            {
                return true;
            }
            return false;
        }
    }
}

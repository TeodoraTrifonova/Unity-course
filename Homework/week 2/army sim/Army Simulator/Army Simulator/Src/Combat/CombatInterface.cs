using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public interface CombatInterface
    {
   
        public bool CanAttack(Unit attacker, Unit defender, Unit[,] Map);
        public bool CanMove(Unit unit, string direction, Unit[,] Map);
        public bool PositionIsEmpty(int row, int col);
        public void MoveUnit(Unit unit, Unit[,] Map);
        public void ShowBattleField(Army army1, Army army2, Unit[,] Map );

    }
}

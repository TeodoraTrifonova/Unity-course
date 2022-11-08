using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public interface CombatInterface
    {
        public void MoveUnit(Unit unit);
        public bool CanAttack(Unit attacker, Unit defender);
        public bool CanMove(Unit unit, string direction);
        public bool PositionIsEmpty(List<Unit> army1, List<Unit> army2);
        public void MoveUnit(Unit unit, string direction);
        public void ShowBattleField(Army army1, Army army2, Unit[,] Map );

    }
}

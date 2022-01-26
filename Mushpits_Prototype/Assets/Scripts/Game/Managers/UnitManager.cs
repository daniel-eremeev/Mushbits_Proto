using System.Collections.Generic;
using System.Linq;
using Utility.GameStateSystem;

namespace Game.Managers
{
    public static class UnitManager
    {
        private static readonly List<Unit> ActiveUnits = new List<Unit>();

        public static void Register(this Unit unit)
        {
            ActiveUnits.Add(unit);
        }

        public static void UnRegister(this Unit unit)
        {
            ActiveUnits.Remove(unit);

            if (ActiveUnits.Count == 0)
                GameStateManager.CurrentState = GameState.Win;
        }

        public static bool IsUnitOnBlock(Block block)
        {
            return ActiveUnits.Any(unit => unit.CurrentBlock == block);
        }

        public static Unit GetUnitOnBlock(Block block)
        {
            return ActiveUnits.FirstOrDefault(unit => unit.CurrentBlock == block);
        }
    }
}
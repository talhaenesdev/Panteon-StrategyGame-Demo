using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Units.Data;
using System.Collections.Generic;

namespace PanteonStrategyGame.Core.Signals
{
    public class ProductionQueueChangedSignal
    {
        public Barracks Barracks { get; }

        public IReadOnlyCollection<UnitData> Queue { get; }

        public ProductionQueueChangedSignal(
            Barracks barracks,
            IReadOnlyCollection<UnitData> queue)
        {
            Barracks = barracks;
            Queue = queue;
        }
    }
}
using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IProductionService
    {
        void Produce(
            ProductionComponent production,
            UnitData unitData);
    }
}
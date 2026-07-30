using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Buildings.Services
{
    public class ProductionService : IProductionService
    {
        public void Produce(
            ProductionComponent production,
            UnitData unitData)
        {
            production.Produce(unitData);
        }
    }
}
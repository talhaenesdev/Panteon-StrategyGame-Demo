using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Buildings.Models
{
    public class ProductionItem
    {
        public UnitData UnitData { get; }

        public float RemainingTime;

        public ProductionItem(UnitData unitData)
        {
            UnitData = unitData;
            RemainingTime = unitData.ProductionTime;
        }
    }
}
using PanteonStrategyGame.Buildings.Data;

namespace PanteonStrategyGame.Core.Signals
{
    public class BuildingPlacementRequestedSignal
    {
        public BuildingData BuildingData { get; }

        public BuildingPlacementRequestedSignal(BuildingData buildingData)
        {
            BuildingData = buildingData;
        }
    }
}
using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public class Barracks : Building
    {
        [SerializeField]
        private ProductionComponent productionComponent;

        public ProductionComponent ProductionComponent => productionComponent;
        public override string DisplayName => buildingData.DisplayName;
        public override Sprite Icon => buildingData.Icon;

        [SerializeField]
        private UnitData[] producibleUnits;
        public UnitData[] ProducibleUnits => producibleUnits;

        public UnitData GetUnit(int index)
        {
            if (index < 0 || index >= producibleUnits.Length)
                return null;

            return producibleUnits[index];
        }
    }
}
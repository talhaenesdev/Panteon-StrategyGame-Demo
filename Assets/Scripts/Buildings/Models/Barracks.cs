using UnityEngine;
using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Buildings.Models
{
    public class Barracks : Building
    {
        public override string DisplayName => buildingData.DisplayName;
        [SerializeField]
        private UnitData[] producibleUnits;
        public UnitData GetUnit(int index)
        {
            if (index < 0 || index >= producibleUnits.Length)
                return null;

            return producibleUnits[index];
        }
    }
}
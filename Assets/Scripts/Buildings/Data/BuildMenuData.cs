using UnityEngine;

namespace PanteonStrategyGame.Buildings.Data
{
    [CreateAssetMenu(
        fileName = "BuildMenuData",
        menuName = "Panteon Strategy Game/Buildings/Build Menu")]
    public class BuildMenuData : ScriptableObject
    {
        [SerializeField]
        private BuildingData[] buildings;

        public BuildingData[] Buildings => buildings;
    }
}
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Data
{
    [CreateAssetMenu(fileName = "BuildingData", menuName = "Panteon Strategy Game/Buildings/Building Data")]
    public class BuildingData : ScriptableObject
    {
        [Header("General")]
        public string BuildingName;
        public Sprite Icon;
        public GameObject Prefab;

        [Header("Placement")]
        public Vector2Int Size = Vector2Int.one;

        [Header("Stats")]
        public int MaxHealth;
    }
}

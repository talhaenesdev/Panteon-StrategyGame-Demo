using UnityEngine;

namespace PanteonStrategyGame.Buildings.Data
{
    [CreateAssetMenu(fileName = "BuildingData",  menuName = "Panteon Strategy Game/Buildings/Building Data")]
    public class BuildingData : ScriptableObject
    {
        public BuildingType Type;

        [Header("General")]
        public string BuildingName;
        public Sprite Icon;

        [Header("Prefabs")]
        public GameObject BuildingPrefab;
        public GameObject GhostPrefab;

        [Header("Stats")]
        public int MaxHealth;

        [Header("Placement")]
        public Vector2Int Size;
    }
}
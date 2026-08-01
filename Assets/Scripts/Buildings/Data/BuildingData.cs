using UnityEngine;

namespace PanteonStrategyGame.Buildings.Data
{
    [CreateAssetMenu(fileName = "BuildingData",  menuName = "Panteon Strategy Game/Buildings/Building Data")]
    public class BuildingData : ScriptableObject
    {
        [field: SerializeField]
        public string DisplayName { get; private set; }
        public BuildingType Type;

        [Header("General")]
        public string BuildingName;
        public Sprite Icon;

        [Header("Pooling")]
        [SerializeField] private string _poolKey;
        public string PoolKey => _poolKey;

        [SerializeField] private string _ghostPoolKey;
        public string GhostPoolKey => _ghostPoolKey;

        [Header("Stats")]
        public int MaxHealth;

        [Header("Placement")]
        public Vector2Int Size;
    }
}
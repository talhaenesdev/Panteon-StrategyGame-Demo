using UnityEngine;

namespace PanteonStrategyGame.Units.Data
{
    [CreateAssetMenu(
        fileName = "UnitData",
        menuName = "Panteon Strategy Game/Units/Unit Data")]
    public class UnitData : ScriptableObject
    {
        [field: SerializeField]
        public string DisplayName { get; private set; }

        public UnitType Type;

        [Header("General")]
        public string UnitName;

        public Sprite Icon;

        [Header("Pooling")]
        [SerializeField]
        private string poolKey;
        public string PoolKey => poolKey;

        [Header("Stats")]
        public int MaxHealth;

        public int Damage;

        public float MoveSpeed;

        [Header("Production")]
        [SerializeField]
        private float productionTime = 3f;
        public float ProductionTime => productionTime;
    }
}
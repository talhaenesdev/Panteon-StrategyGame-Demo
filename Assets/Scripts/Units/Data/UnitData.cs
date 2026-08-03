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

        public float MoveSpeed;

        [Header("Production")]
        [SerializeField]
        private float productionTime = 3f;
        public float ProductionTime => productionTime;

        [Header("Combat")]
        [SerializeField]
        private float attackRange = 2f;
        public float AttackRange => attackRange;

        [SerializeField]
        private float attackRate = 1f;
        public float AttackRate => attackRate;

        [SerializeField]
        private int damage = 10;
        public int Damage => damage;
    }
}
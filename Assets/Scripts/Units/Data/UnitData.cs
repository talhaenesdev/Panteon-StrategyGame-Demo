using UnityEngine;

namespace PanteonStrategyGame.Units.Data
{
    [CreateAssetMenu(
        fileName = "UnitData",
        menuName = "Panteon Strategy Game/Units/Unit Data")]
    public class UnitData : ScriptableObject
    {
        #region General

        [field: Header("General")]

        [field: SerializeField]
        public string DisplayName { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }

        #endregion

        #region Pooling

        [field: Header("Pooling")]

        [field: SerializeField]
        public string PoolKey { get; private set; }

        #endregion

        #region Stats

        [field: Header("Stats")]

        [field: SerializeField]
        [field: Min(1)]
        public int MaxHealth { get; private set; } = 100;

        [field: SerializeField]
        [field: Tooltip("Movement speed of the unit.")]
        [field: Range(0.5f, 20f)]
        public float MoveSpeed { get; private set; } = 5f;

        #endregion

        #region Production

        [field: Header("Production")]

        [field: SerializeField]
        [field: Tooltip("Time required to produce this unit.")]
        [field: Range(0.1f, 60f)]
        public float ProductionTime { get; private set; } = 3f;

        #endregion

        #region Combat

        [field: Header("Combat")]

        [field: SerializeField]
        [field: Tooltip("Attack range of the unit.")]
        [field: Range(0.5f, 20f)]
        public float AttackRange { get; private set; } = 2f;

        [field: SerializeField]
        [field: Tooltip("Attacks per second.")]
        [field: Range(0.1f, 10f)]
        public float AttackRate { get; private set; } = 1f;

        [field: SerializeField]
        [field: Tooltip("Damage dealt per attack.")]
        [field: Range(1, 1000)]
        public int Damage { get; private set; } = 10;

        #endregion
    }
}
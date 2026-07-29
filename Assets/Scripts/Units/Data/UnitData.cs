using UnityEngine;

namespace PanteonStrategyGame.Units.Data
{
    [CreateAssetMenu(
        fileName = "UnitData",
        menuName = "Panteon Strategy Game/Units/Unit Data")]
    public class UnitData : ScriptableObject
    {
        public UnitType Type;

        [Header("General")]
        public string UnitName;

        public Sprite Icon;

        public GameObject Prefab;

        [Header("Stats")]
        public int MaxHealth;

        public int Damage;

        public float MoveSpeed;
    }
}
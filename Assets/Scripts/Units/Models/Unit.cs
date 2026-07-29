using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Units.Models
{
    public abstract class Unit : Entity
    {
        protected UnitData Data;

        public int Damage => Data.Damage;

        public float MoveSpeed => Data.MoveSpeed;

        public virtual void Initialize(UnitData data)
        {
            Data = data;
            CurrentHealth = data.MaxHealth;
        }
    }
}
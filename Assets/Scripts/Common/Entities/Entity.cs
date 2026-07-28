using UnityEngine;

namespace PanteonStrategyGame.Common.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public int CurrentHealth { get; protected set; }

        public virtual void TakeDamage(int damage)
        {
        }

        protected virtual void DestroyEntity()
        {
        }
    }
}

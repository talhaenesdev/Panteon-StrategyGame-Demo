using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IDamageable
    {
        int CurrentHealth { get; }

        int MaxHealth { get; }

        void TakeDamage(int damage, IEntity attacker);

        Vector3 GetAttackPosition(Vector3 attackerPosition);
    }
}
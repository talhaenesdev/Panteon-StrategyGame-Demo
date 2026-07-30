using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IEntity
    {
        Transform Transform { get; }

        int CurrentHealth { get; }

        void TakeDamage(int damage);
    }
}
namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IDamageable
    {
        int CurrentHealth { get; }
        void TakeDamage(int damage);
    }
}
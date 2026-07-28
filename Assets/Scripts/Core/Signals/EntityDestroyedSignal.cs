using PanteonStrategyGame.Core.Interfaces;

namespace PanteonStrategyGame.Core.Signals
{
    public class EntityDestroyedSignal
    {
        public IDamageable DestroyedEntity { get; }

        public EntityDestroyedSignal(IDamageable destroyedEntity)
        {
            DestroyedEntity = destroyedEntity;
        }
    }
}
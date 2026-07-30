using PanteonStrategyGame.Common.Entities;

namespace PanteonStrategyGame.Core.Signals
{
    public class EntityDestroyedSignal
    {
        public Entity DestroyedEntity { get; }

        public EntityDestroyedSignal(Entity destroyedEntity)
        {
            DestroyedEntity = destroyedEntity;
        }
    }
}
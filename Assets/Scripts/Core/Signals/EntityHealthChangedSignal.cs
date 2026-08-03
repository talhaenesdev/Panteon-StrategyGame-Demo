using PanteonStrategyGame.Common.Entities;

namespace PanteonStrategyGame.Core.Signals
{
    public class EntityHealthChangedSignal
    {
        public Entity Entity { get; }

        public EntityHealthChangedSignal(Entity entity)
        {
            Entity = entity;
        }
    }
}
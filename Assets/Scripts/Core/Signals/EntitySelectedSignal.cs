using PanteonStrategyGame.Common.Entities;

namespace PanteonStrategyGame.Core.Signals
{
    public class EntitySelectedSignal
    {
        public Entity SelectedEntity { get; }

        public EntitySelectedSignal(Entity selectedEntity)
        {
            SelectedEntity = selectedEntity;
        }
    }
}
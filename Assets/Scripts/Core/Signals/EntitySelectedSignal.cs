using PanteonStrategyGame.Core.Interfaces;

namespace PanteonStrategyGame.Core.Signals
{
    public class EntitySelectedSignal
    {
        public ISelectable SelectedEntity { get; }

        public EntitySelectedSignal(ISelectable selectedEntity)
        {
            SelectedEntity = selectedEntity;
        }
    }
}
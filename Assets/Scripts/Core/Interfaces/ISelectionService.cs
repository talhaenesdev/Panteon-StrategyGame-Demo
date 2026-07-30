using PanteonStrategyGame.Common.Entities;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface ISelectionService
    {
        Entity SelectedEntity { get; }

        void Select(Entity entity);

        void ClearSelection();
    }
}
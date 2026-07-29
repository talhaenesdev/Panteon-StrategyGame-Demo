using PanteonStrategyGame.Units.Models;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface ISelectionService
    {
        Unit SelectedUnit { get; }

        void Select(Unit unit);

        void ClearSelection();
    }
}
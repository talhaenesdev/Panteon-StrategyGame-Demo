using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Units.Services
{
    public class SelectionService : ISelectionService
    {
        public Unit SelectedUnit { get; private set; }

        public void Select(Unit unit)
        {
            Debug.Log($"Selected : {unit.name}");

            if (SelectedUnit == unit)
                return;

            SelectedUnit?.Deselect();

            SelectedUnit = unit;

            SelectedUnit.Select();
        }

        public void ClearSelection()
        {
            SelectedUnit?.Deselect();
            SelectedUnit = null;
        }
    }
}
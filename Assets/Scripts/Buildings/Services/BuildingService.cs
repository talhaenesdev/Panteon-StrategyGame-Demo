using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Models;

namespace PanteonStrategyGame.Buildings.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly List<Building> _buildings = new();

        public IReadOnlyList<Building> Buildings => _buildings;

        public void Register(Building building)
        {
            if (_buildings.Contains(building))
                return;

            _buildings.Add(building);
        }

        public void Unregister(Building building)
        {
            _buildings.Remove(building);
        }
    }
}
using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Models;

namespace PanteonStrategyGame.Buildings.Services
{
    public interface IBuildingService
    {
        IReadOnlyList<Building> Buildings { get; }

        void Register(Building building);

        void Unregister(Building building);
    }
}
using System.Collections.Generic;
using PanteonStrategyGame.Units.Models;

namespace PanteonStrategyGame.Units.Services
{
    public interface IUnitService
    {
        IReadOnlyList<Unit> Units { get; }

        void Register(Unit unit);

        void Unregister(Unit unit);
    }
}
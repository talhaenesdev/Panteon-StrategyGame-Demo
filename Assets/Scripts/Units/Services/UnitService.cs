using System.Collections.Generic;
using PanteonStrategyGame.Units.Models;

namespace PanteonStrategyGame.Units.Services
{
    public class UnitService : IUnitService
    {
        private readonly List<Unit> _units = new();

        public IReadOnlyList<Unit> Units => _units;

        public void Register(Unit unit)
        {
            if (_units.Contains(unit))
                return;

            _units.Add(unit);
        }

        public void Unregister(Unit unit)
        {
            _units.Remove(unit);
        }
    }
}
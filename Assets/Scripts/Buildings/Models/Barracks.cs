using UnityEngine;
using Zenject;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Buildings.Models
{
    public class Barracks : Building
    {
        [SerializeField] private SpawnPoint spawnPoint;
        [SerializeField] private UnitData testUnit;

        [Inject] private IUnitFactory _unitFactory;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;

            _unitFactory.Create(
                testUnit,
                spawnPoint.transform.position);
        }
    }
}
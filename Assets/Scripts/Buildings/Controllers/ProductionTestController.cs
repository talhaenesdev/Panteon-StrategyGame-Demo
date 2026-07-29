using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Controllers
{
    public class ProductionTestController : MonoBehaviour
    {
        [SerializeField] private Barracks barracks;

        [SerializeField]
        private ProductionComponent production;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                production.Produce(
                    barracks.GetUnit(0));
            }
        }
    }
}
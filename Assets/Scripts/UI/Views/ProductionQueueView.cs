using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionQueueView : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        public Transform Container => _container;
    }
}
using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionQueueView : MonoBehaviour
    {
        [SerializeField]
        private Transform container;

        public Transform Container => container;
    }
}
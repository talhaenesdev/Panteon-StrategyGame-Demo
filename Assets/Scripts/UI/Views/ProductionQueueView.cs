using System.Collections.Generic;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionQueueView : MonoBehaviour
    {
        [SerializeField] private QueueItemView itemPrefab;
        [SerializeField] private Transform container;

        public void Refresh(IReadOnlyCollection<UnitData> queue)
        {
            Clear();

            foreach (var unit in queue)
            {
                var item = Instantiate(itemPrefab, container);

                item.Initialize(unit.DisplayName);
            }
        }

        private void Clear()
        {
            foreach (Transform child in container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
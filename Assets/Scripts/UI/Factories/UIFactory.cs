using UnityEngine;
using PanteonStrategyGame.Core.Pooling;
using PanteonStrategyGame.UI.Interfaces;
using PanteonStrategyGame.UI.Views;

namespace PanteonStrategyGame.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly PoolManager _poolManager;

        public UIFactory(PoolManager poolManager)
        {
            _poolManager = poolManager;
        }

        public ProductionButtonView CreateProductionButton(Transform parent)
        {
            GameObject obj =
                _poolManager.Get(
                    "ProductionButton",
                    parent);

            return obj.GetComponent<ProductionButtonView>();
        }

        public BuildButtonView CreateBuildButton(Transform parent)
        {
            GameObject obj =
                _poolManager.Get(
                    "BuildButton",
                    parent);

            return obj.GetComponent<BuildButtonView>();
        }

        public QueueItemView CreateQueueItem(Transform parent)
        {
            GameObject obj =
                _poolManager.Get(
                    "QueueItem",
                    parent);

            return obj.GetComponent<QueueItemView>();
        }

        public void Release(GameObject obj)
        {
            _poolManager.Release(obj);
        }
    }
}
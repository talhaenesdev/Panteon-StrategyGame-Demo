using UnityEngine;
using PanteonStrategyGame.UI.Views;

namespace PanteonStrategyGame.UI.Interfaces
{
    public interface IUIFactory
    {
        ProductionButtonView CreateProductionButton(Transform parent);

        BuildButtonView CreateBuildButton(Transform parent);

        QueueItemView CreateQueueItem(Transform parent);

        void Release(GameObject obj);
    }
}
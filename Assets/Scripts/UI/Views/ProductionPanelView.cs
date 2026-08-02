using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionPanelView : MonoBehaviour
    {
        [SerializeField]
        private Transform buttonContainer;

        public Transform ButtonContainer => buttonContainer;

        private void Awake()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
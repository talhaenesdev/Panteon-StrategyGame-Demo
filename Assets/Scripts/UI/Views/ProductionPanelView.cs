using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionPanelView : MonoBehaviour
    {
        [SerializeField]
        private Transform _buttonContainer;

        public Transform ButtonContainer => _buttonContainer;

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
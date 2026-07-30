using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionPanelView : MonoBehaviour
    {
        [SerializeField]
        private ProductionButtonView buttonPrefab;
        [SerializeField] private Transform buttonContainer;

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

        public ProductionButtonView CreateButton()
        {
            return Instantiate(buttonPrefab, buttonContainer);
        }

        public void ClearButtons()
        {
            foreach (Transform child in buttonContainer)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
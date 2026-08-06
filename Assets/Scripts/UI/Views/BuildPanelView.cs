using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class BuildPanelView : MonoBehaviour
    {
        [SerializeField]
        private Transform _buttonContainer;

        public Transform ButtonContainer => _buttonContainer;

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
using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class BuildPanelView : MonoBehaviour
    {
        [SerializeField]
        private Transform buttonContainer;

        public Transform ButtonContainer => buttonContainer;

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
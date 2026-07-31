using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class BuildPanelView : MonoBehaviour
    {
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private BuildButtonView buttonPrefab;

        public BuildButtonView CreateButton()
        {
            return Instantiate(buttonPrefab, buttonContainer);
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
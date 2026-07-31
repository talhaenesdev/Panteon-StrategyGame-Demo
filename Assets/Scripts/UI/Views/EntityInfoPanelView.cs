using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class EntityInfoPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text typeText;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private Image entityIcon;

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

        public void Refresh(string entityName, string entityType, int health, Sprite icon)
        {
            nameText.text = entityName;
            typeText.text = entityType;
            healthText.text = $"HP : {health}";
            entityIcon.sprite = icon;
        }
    }
}
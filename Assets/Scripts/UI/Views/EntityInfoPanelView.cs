using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class EntityInfoPanelView : MonoBehaviour
    {
        private int _maxHealth;
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

        public void Refresh(
            string entityName,
            string entityType,
            int currentHealth,
            int maxHealth,
            Sprite icon)
        {
            nameText.text = entityName;
            typeText.text = entityType;
            entityIcon.sprite = icon;

            healthText.text = $"{currentHealth} / {maxHealth}";
        }

        public void SetHealth(int currentHealth, int maxHealth)
        {
            healthText.text = $"{currentHealth} / {maxHealth}";
        }
    }
}
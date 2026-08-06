using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class EntityInfoPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _typeText;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Image _entityIcon;

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
            _nameText.text = entityName;
            _typeText.text = entityType;
            _entityIcon.sprite = icon;

            _healthText.text = $"{currentHealth} / {maxHealth}";
        }

        public void SetHealth(int currentHealth, int maxHealth)
        {
            _healthText.text = $"{currentHealth} / {maxHealth}";
        }
    }
}
using TMPro;
using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class EntityInfoPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text typeText;
        [SerializeField] private TMP_Text healthText;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetName(string value)
        {
            nameText.text = value;
        }

        public void SetType(string value)
        {
            typeText.text = value;
        }

        public void SetHealth(int health)
        {
            healthText.text = $"HP : {health}";
        }
    }
}
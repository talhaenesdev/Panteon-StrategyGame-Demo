using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class QueueItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private Image _image;

        public void Initialize(string title, Sprite icon)
        {
            _titleText.text = title;
            _image.sprite = icon;
        }
    }
}
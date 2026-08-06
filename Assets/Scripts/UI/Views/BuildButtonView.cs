using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class BuildButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _buttonIcon;

        public void Initialize(string text, Sprite icon, Action onClick)
        {
            _title.text = text;
            _buttonIcon.sprite = icon;
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}
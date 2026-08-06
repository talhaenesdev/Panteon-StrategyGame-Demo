using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class ProductionButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _buttonIcon;

        public void Initialize(string titleText,Sprite icon, Action onClick)
        {
            _title.text = titleText;
            _buttonIcon.sprite = icon;
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}
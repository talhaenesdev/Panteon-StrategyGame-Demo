using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonStrategyGame.UI.Views
{
    public class BuildButtonView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text title;
        [SerializeField] private Image buttonIcon;

        public void Initialize(string text, Sprite icon, Action onClick)
        {
            title.text = text;
            buttonIcon.sprite = icon;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}
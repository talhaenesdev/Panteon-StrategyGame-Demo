using TMPro;
using UnityEngine;

namespace PanteonStrategyGame.UI.Views
{
    public class QueueItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;

        public void Initialize(string title)
        {
            titleText.text = title;
        }
    }
}
using UnityEngine;
using TMPro;

namespace MicroForest.Player
{
    public class BugCountDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            PocketInventory.OnBugCountChanged += UpdateText;
        }

        private void OnDisable()
        {
            PocketInventory.OnBugCountChanged -= UpdateText;
        }

        private void UpdateText(int count)
        {
            _text.text = $"Bichos: {count}";
        }
    }
}
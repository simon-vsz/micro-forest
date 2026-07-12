using UnityEngine;
using TMPro;

namespace MicroForest.Economy
{
    public class BugTokenDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            EconomyManager.OnTokensChanged += UpdateText;
        }

        private void OnDisable()
        {
            EconomyManager.OnTokensChanged -= UpdateText;
        }

        private void UpdateText(int total)
        {
            _text.text = $"Bug Tokens: {total}";
        }

        private void Start()
        {
            _text.text = "Bug Tokens: 0";
        }
    }
}
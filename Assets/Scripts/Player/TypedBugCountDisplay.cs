using UnityEngine;
using TMPro;

namespace MicroForest.Player
{
    public class TypedBugCountDisplay : MonoBehaviour
    {
        [SerializeField] private World.InsectType _typeToShow;
        [SerializeField] private TextMeshProUGUI _text;

        private void Awake()
        {
            _text.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            PocketInventory.OnBugCountChanged += HandleCountChanged;
        }

        private void OnDisable()
        {
            PocketInventory.OnBugCountChanged -= HandleCountChanged;
        }

        private void HandleCountChanged(World.InsectType type, int count)
        {
            if (type != _typeToShow) return;

            _text.gameObject.SetActive(count > 0);
            _text.text = $"{type}: {count}";
        }
    }
}
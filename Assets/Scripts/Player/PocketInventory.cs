using UnityEngine;

namespace MicroForest.Player
{
    public class PocketInventory : MonoBehaviour
    {
        public static System.Action<int> OnBugCountChanged;

        private int _bugCount;

        private void OnEnable()
        {
            World.Insect.OnCollected += HandleInsectCollected;
        }

        private void OnDisable()
        {
            World.Insect.OnCollected -= HandleInsectCollected;
        }

        private void HandleInsectCollected()
        {
            _bugCount++;
            OnBugCountChanged?.Invoke(_bugCount);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace MicroForest.Player
{
    public class PocketInventory : MonoBehaviour
    {
        public static System.Action<World.InsectType, int> OnBugCountChanged;

        private Dictionary<World.InsectType, int> _counts = new Dictionary<World.InsectType, int>();

        private void OnEnable()
        {
            World.Insect.OnCollected += HandleInsectCollected;
        }

        private void OnDisable()
        {
            World.Insect.OnCollected -= HandleInsectCollected;
        }

        private void HandleInsectCollected(World.InsectType type)
        {
            if (!_counts.ContainsKey(type))
            {
                _counts[type] = 0;
            }

            _counts[type]++;
            OnBugCountChanged?.Invoke(type, _counts[type]);
        }
        
        public int GetCount(World.InsectType type)
        {
            return _counts.ContainsKey(type) ? _counts[type] : 0;
        }

        public void Clear()
        {
            _counts.Clear();
            OnBugCountChanged?.Invoke(World.InsectType.Common, 0);
            OnBugCountChanged?.Invoke(World.InsectType.Rare, 0);
        }
    }
}
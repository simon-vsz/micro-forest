using UnityEngine;

namespace MicroForest.Economy
{
    public class EconomyManager : MonoBehaviour
    {
        public static EconomyManager Instance { get; private set; }
        public static System.Action<int> OnTokensChanged;

        private int _totalTokens;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            Core.SaveData data = Core.SaveSystem.Load();
            _totalTokens = data.totalBugTokens;
            OnTokensChanged?.Invoke(_totalTokens);
        }

        public void AddTokens(int amount)
        {
            _totalTokens += amount;
            OnTokensChanged?.Invoke(_totalTokens);
            PersistTokens();
        }

        public bool SpendTokens(int amount)
        {
            if (_totalTokens < amount) return false;

            _totalTokens -= amount;
            OnTokensChanged?.Invoke(_totalTokens);
            PersistTokens();
            return true;
        }

        private void PersistTokens()
        {
            Core.SaveData data = Core.SaveSystem.Load();
            data.totalBugTokens = _totalTokens;
            Core.SaveSystem.Save(data);
        }
    }
}
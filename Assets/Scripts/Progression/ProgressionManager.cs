using System.Collections.Generic;
using UnityEngine;

namespace MicroForest.Progression
{
    public enum UpgradeType
    {
        MovementSpeed,
        AttackSpeed
    }

    public class ProgressionManager : MonoBehaviour
    {
        public static ProgressionManager Instance { get; private set; }
        public static System.Action<UpgradeType, int> OnLevelChanged;

        private static readonly int[] LevelCosts = { 5, 10, 15 };
        private const int MaxLevel = 3;

        private Dictionary<UpgradeType, int> _levels = new Dictionary<UpgradeType, int>();

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
            _levels[UpgradeType.MovementSpeed] = data.movementSpeedLevel;
            _levels[UpgradeType.AttackSpeed] = data.attackSpeedLevel;

            OnLevelChanged?.Invoke(UpgradeType.MovementSpeed, _levels[UpgradeType.MovementSpeed]);
            OnLevelChanged?.Invoke(UpgradeType.AttackSpeed, _levels[UpgradeType.AttackSpeed]);
        }

        public int GetLevel(UpgradeType type)
        {
            return _levels.ContainsKey(type) ? _levels[type] : 0;
        }

        public int GetCostForNextLevel(UpgradeType type)
        {
            int currentLevel = GetLevel(type);
            if (currentLevel >= MaxLevel) return -1;
            return LevelCosts[currentLevel];
        }

        public bool TryPurchase(UpgradeType type)
        {
            int cost = GetCostForNextLevel(type);
            if (cost < 0) return false;
            if (!Economy.EconomyManager.Instance.SpendTokens(cost)) return false;

            _levels[type]++;
            SaveProgress();
            OnLevelChanged?.Invoke(type, _levels[type]);
            return true;
        }

        private void SaveProgress()
        {
            Core.SaveData data = Core.SaveSystem.Load();
            data.movementSpeedLevel = _levels[UpgradeType.MovementSpeed];
            data.attackSpeedLevel = _levels[UpgradeType.AttackSpeed];
            Core.SaveSystem.Save(data);
        }
    }
}
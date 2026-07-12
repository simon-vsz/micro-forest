using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


namespace MicroForest.Progression
{
    public class ShopMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TextMeshProUGUI _tokenText;
        [SerializeField] private TextMeshProUGUI _movementLevelText;
        [SerializeField] private TextMeshProUGUI _attackLevelText;
        [SerializeField] private Core.SleepTransition _sleepTransition;
        [SerializeField] private Player.PlayerMovement _playerMovement;
        [SerializeField] private GameObject _firstSelectedButton;
        [SerializeField] private GameObject _movementButton;
        [SerializeField] private GameObject _attackButton;

        private void Awake()
        {
            _panel.SetActive(false);
        }

        private void OnEnable()
        {
            Economy.EconomyManager.OnTokensChanged += HandleTokensChanged;
            ProgressionManager.OnLevelChanged += HandleLevelChanged;
        }

        private void OnDisable()
        {
            Economy.EconomyManager.OnTokensChanged -= HandleTokensChanged;
            ProgressionManager.OnLevelChanged -= HandleLevelChanged;
        }

        public void Open()
        {
            _playerMovement.SetActionMap("UI");
            _panel.SetActive(true);
            RefreshMovementText(ProgressionManager.Instance.GetLevel(UpgradeType.MovementSpeed));
            RefreshAttackText(ProgressionManager.Instance.GetLevel(UpgradeType.AttackSpeed));
            StartCoroutine(SelectFirstButtonNextFrame());
        }

        private System.Collections.IEnumerator SelectFirstButtonNextFrame()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return null;
            EventSystem.current.SetSelectedGameObject(_firstSelectedButton);
        }

        public void PurchaseMovementSpeed()
        {
            ProgressionManager.Instance.TryPurchase(UpgradeType.MovementSpeed);
            StartCoroutine(ReselectButtonNextFrame(_movementButton));
        }

        public void PurchaseAttackSpeed()
        {
            ProgressionManager.Instance.TryPurchase(UpgradeType.AttackSpeed);
            StartCoroutine(ReselectButtonNextFrame(_attackButton));
        }

        private System.Collections.IEnumerator ReselectButtonNextFrame(GameObject button)
        {
            yield return null;
            EventSystem.current.SetSelectedGameObject(button);
}

        public void Continue()
        {
            _playerMovement.SetActionMap("Player");
            _playerMovement.SetMovementEnabled(true);
            _panel.SetActive(false);
            _sleepTransition.PlaySleepSequence();
        }

        private void HandleTokensChanged(int total)
        {
            _tokenText.text = $"Bug Tokens: {total}";
        }

        private void HandleLevelChanged(UpgradeType type, int level)
        {
            if (type == UpgradeType.MovementSpeed) RefreshMovementText(level);
            if (type == UpgradeType.AttackSpeed) RefreshAttackText(level);
        }

        private void RefreshMovementText(int level)
        {
            int cost = ProgressionManager.Instance.GetCostForNextLevel(UpgradeType.MovementSpeed);
            _movementLevelText.text = cost >= 0 ? $"Velocidad Nv.{level} (Costo: {cost})" : $"Velocidad Nv.{level} (MAX)";
        }

        private void RefreshAttackText(int level)
        {
            int cost = ProgressionManager.Instance.GetCostForNextLevel(UpgradeType.AttackSpeed);
            _attackLevelText.text = cost >= 0 ? $"Vel. Ataque Nv.{level} (Costo: {cost})" : $"Vel. Ataque Nv.{level} (MAX)";
        }
    }
}
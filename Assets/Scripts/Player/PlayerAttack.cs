using UnityEngine;
using UnityEngine.InputSystem;

namespace MicroForest.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _attackHitbox;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _hitboxActiveDuration = 0.15f;
        [SerializeField] private PocketInventory _pocketInventory;
        [SerializeField] private Core.SleepTransition _sleepTransition;


        private float _lastAttackTime = -999f;
        private bool _isNearHouse;

        private void Awake()
        {
            _attackHitbox.SetActive(false);
        }

        private void OnEnable()
        {
            World.HouseInteractionZone.OnPlayerEnteredZone += HandleEnteredHouseZone;
            World.HouseInteractionZone.OnPlayerExitedZone += HandleExitedHouseZone;
        }

        private void OnDisable()
        {
            World.HouseInteractionZone.OnPlayerEnteredZone -= HandleEnteredHouseZone;
            World.HouseInteractionZone.OnPlayerExitedZone -= HandleExitedHouseZone;
        }

        private void HandleEnteredHouseZone()
        {
            _isNearHouse = true;
        }

        private void HandleExitedHouseZone()
        {
            _isNearHouse = false;
        }
        
        private void ConvertPocketToTokens()
        {
            int commonCount = _pocketInventory.GetCount(World.InsectType.Common);
            int rareCount = _pocketInventory.GetCount(World.InsectType.Rare);

            int tokensEarned = (commonCount * 1) + (rareCount * 3);

            Economy.EconomyManager.Instance.AddTokens(tokensEarned);
            _pocketInventory.Clear();

            Debug.Log($"Micro durmió. Ganó {tokensEarned} Bug Tokens.");
            _sleepTransition.PlaySleepSequence();
        }

        public void OnAttack(InputValue value)
        {
            if (!value.isPressed) return;

            if (_isNearHouse)
            {
                ConvertPocketToTokens();
                return;
            }

            if (Time.time - _lastAttackTime < _attackCooldown) return;

            _lastAttackTime = Time.time;
            StartCoroutine(ActivateHitbox());
        }

        private System.Collections.IEnumerator ActivateHitbox()
        {
            _attackHitbox.SetActive(true);
            yield return new WaitForSeconds(_hitboxActiveDuration);
            _attackHitbox.SetActive(false);
        }
    }
}
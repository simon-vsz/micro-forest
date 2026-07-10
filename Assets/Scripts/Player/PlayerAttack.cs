using UnityEngine;
using UnityEngine.InputSystem;

namespace MicroForest.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _attackHitbox;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _hitboxActiveDuration = 0.15f;

        private float _lastAttackTime = -999f;

        private void Awake()
        {
            _attackHitbox.SetActive(false);
        }

        public void OnAttack(InputValue value)
        {
            if (!value.isPressed) return;

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
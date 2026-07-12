using UnityEngine;
using UnityEngine.InputSystem;

namespace MicroForest.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _speedPerLevel = 1f;


        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private Vector2 _moveInput;
        private float _speedBonus = 0f;
        private bool _movementEnabled = true;

        public float MoveSpeed => _moveSpeed + _speedBonus;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();
        }

        public void SetActionMap(string mapName)
        {
            foreach (var actionMap in _playerInput.actions.actionMaps)
            {
                if (actionMap.name == mapName)
                {
                    actionMap.Enable();
                    Debug.Log("Activado: " + actionMap.name);
                }
                else
                {
                    actionMap.Disable();
                }
            }
        }

        private void Start()
        {
            SetActionMap("Player");
        }

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            if (!_movementEnabled) return;
            Vector3 movement = new Vector3(_moveInput.x, 0f, _moveInput.y);
            Vector3 newPosition = _rigidbody.position + movement * MoveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPosition);

            if (movement.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                _rigidbody.MoveRotation(targetRotation);
            }
        }

        private void OnEnable()
        {
            Progression.ProgressionManager.OnLevelChanged += HandleLevelChanged;
        }

        private void OnDisable()
        {
            Progression.ProgressionManager.OnLevelChanged -= HandleLevelChanged;
        }

        private void HandleLevelChanged(Progression.UpgradeType type, int level)
        {
            if (type == Progression.UpgradeType.MovementSpeed)
            {
                _speedBonus = level * _speedPerLevel;
            }
        }

        public void SetMovementEnabled(bool enabled)
        {
            _movementEnabled = enabled;
            if (!enabled)
            {
                _moveInput = Vector2.zero;
                _rigidbody.linearVelocity = Vector3.zero;
            }
        }
    }
}
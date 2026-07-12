using UnityEngine;
using UnityEngine.InputSystem;

namespace MicroForest.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private Vector2 _moveInput;
        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            foreach (var actionMap in _playerInput.actions.actionMaps)
            {
                if (actionMap.name == "Player")
                {
                    actionMap.Enable();
                }
                else
                {
                    actionMap.Disable();
                }
            }
        }

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(_moveInput.x, 0f, _moveInput.y);
            Vector3 newPosition = _rigidbody.position + movement * _moveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPosition);

            if (movement.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                _rigidbody.MoveRotation(targetRotation);
            }
        }
    }
}
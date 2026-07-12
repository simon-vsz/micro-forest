using UnityEngine;

namespace MicroForest.World
{
    [RequireComponent(typeof(Rigidbody))]
    public class Insect : MonoBehaviour
    {
        public static System.Action<InsectType> OnCollected;

        [SerializeField] private float _hopForce = 4f;
        [SerializeField] private float _hopUpForce = 5f;
        [SerializeField] private float _attractSpeed = 4f;
        [SerializeField] private float _pickupDistance = 0.3f;
        [SerializeField] private float _attractSpeedMultiplier = 1.5f;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _commonMaterial;
        [SerializeField] private Material _rareMaterial;

        private Rigidbody _rigidbody;
        private Transform _target;
        private bool _isAttracted;
        private bool _hasLanded;
        private InsectType _type;

        public bool HasLanded => _hasLanded;
        public InsectType Type => _type;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetType(InsectType type)
        {
            _type = type;

            if (type == InsectType.Rare)
            {
                _renderer.material = _rareMaterial;
            }
            else
            {
                _renderer.material = _commonMaterial;
            }
        }

        public void Hop(Vector3 direction)
        {
            _rigidbody.AddForce(direction.normalized * _hopForce + Vector3.up * _hopUpForce, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _hasLanded = true;
        }

        public void Attract(Transform target, float playerSpeed)
        {
            if (!_hasLanded) return;

            _target = target;
            _isAttracted = true;
            _attractSpeed = playerSpeed * _attractSpeedMultiplier;
            _rigidbody.isKinematic = true;
        }

        private void Update()
        {
            if (!_isAttracted) return;

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _attractSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _target.position) <= _pickupDistance)
            {
                OnCollected?.Invoke(_type);
                Destroy(gameObject);
            }
        }
    }
}
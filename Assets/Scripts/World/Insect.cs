using UnityEngine;

namespace MicroForest.World
{
    [RequireComponent(typeof(Rigidbody))]
    public class Insect : MonoBehaviour
    {
        public static System.Action OnCollected;

        [SerializeField] private float _hopForce = 4f;
        [SerializeField] private float _hopUpForce = 5f;
        [SerializeField] private float _attractSpeed = 4f;
        [SerializeField] private float _pickupDistance = 0.3f;

        private Rigidbody _rigidbody;
        private Transform _target;
        private bool _isAttracted;
        private bool _hasLanded;

        public bool HasLanded => _hasLanded;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Hop(Vector3 direction)
        {
            _rigidbody.AddForce(direction.normalized * _hopForce + Vector3.up * _hopUpForce, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _hasLanded = true;
        }

        public void Attract(Transform target)
        {
            if (!_hasLanded) return;

            _target = target;
            _isAttracted = true;
            _rigidbody.isKinematic = true;
        }

        private void Update()
        {
            if (!_isAttracted) return;

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _attractSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _target.position) <= _pickupDistance)
            {
                OnCollected?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
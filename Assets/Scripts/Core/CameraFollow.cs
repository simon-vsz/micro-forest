using UnityEngine;

namespace MicroForest.Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothTime = 0.2f;

        private Vector3 _offset;
        private Vector3 _velocity;

        private void Start()
        {
            _offset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = _target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _smoothTime);
        }
    }
}
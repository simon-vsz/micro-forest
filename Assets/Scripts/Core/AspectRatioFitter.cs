using UnityEngine;

namespace MicroForest.Core
{
    [RequireComponent(typeof(Camera))]
    public class AspectRatioFitter : MonoBehaviour
    {
        [SerializeField] private float _targetAspect = 16f / 9f;

        private Camera _camera;
        private int _lastScreenWidth;
        private int _lastScreenHeight;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Screen.width == _lastScreenWidth && Screen.height == _lastScreenHeight) return;

            _lastScreenWidth = Screen.width;
            _lastScreenHeight = Screen.height;
            ApplyLetterbox();
        }

        private void ApplyLetterbox()
        {
            float windowAspect = (float)Screen.width / Screen.height;
            float scaleHeight = windowAspect / _targetAspect;

            if (scaleHeight < 1f)
            {
                Rect rect = _camera.rect;
                rect.width = 1f;
                rect.height = scaleHeight;
                rect.x = 0f;
                rect.y = (1f - scaleHeight) / 2f;
                _camera.rect = rect;
            }
            else
            {
                float scaleWidth = 1f / scaleHeight;
                Rect rect = _camera.rect;
                rect.width = scaleWidth;
                rect.height = 1f;
                rect.x = (1f - scaleWidth) / 2f;
                rect.y = 0f;
                _camera.rect = rect;
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace MicroForest.Core
{
    public class SleepTransition : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;
        [SerializeField] private Transform _respawnPoint;
        [SerializeField] private Transform _player;
        [SerializeField] private float _fadeDuration = 0.5f;

        public void PlaySleepSequence()
        {
            StartCoroutine(SleepRoutine());
        }

        private IEnumerator SleepRoutine()
        {
            yield return StartCoroutine(Fade(0f, 1f));

            World.WorldResetManager.ResetWorld();
            _player.position = _respawnPoint.position;

            yield return new WaitForSeconds(0.3f);

            yield return StartCoroutine(Fade(1f, 0f));
        }

        private IEnumerator Fade(float from, float to)
        {
            float elapsed = 0f;
            Color color = _fadeImage.color;

            while (elapsed < _fadeDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(from, to, elapsed / _fadeDuration);
                _fadeImage.color = new Color(color.r, color.g, color.b, alpha);
                yield return null;
            }

            _fadeImage.color = new Color(color.r, color.g, color.b, to);
        }
    }
}
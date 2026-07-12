using UnityEngine;

namespace MicroForest.World
{
    public class HouseInteractionZone : MonoBehaviour
    {
        public static System.Action OnPlayerEnteredZone;
        public static System.Action OnPlayerExitedZone;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerEnteredZone?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerExitedZone?.Invoke();
            }
        }
    }
}
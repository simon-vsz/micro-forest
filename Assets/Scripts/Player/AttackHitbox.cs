using UnityEngine;

namespace MicroForest.Player
{
    public class AttackHitbox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Vegetation"))
            {
                World.Vegetation vegetation = other.GetComponent<World.Vegetation>();
                if (vegetation != null)
                {
                    vegetation.Cut();
                }
            }
        }
    }
}
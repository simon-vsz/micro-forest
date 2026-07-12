using UnityEngine;

namespace MicroForest.Player
{
    public class CollectionRadius : MonoBehaviour
    {
        [SerializeField] private Transform _attractTarget;
        [SerializeField] private PlayerMovement _playerMovement;

        private void OnTriggerStay(Collider other)
        {
            World.Insect insect = other.GetComponent<World.Insect>();
            if (insect != null && insect.HasLanded)
            {
                insect.Attract(_attractTarget, _playerMovement.MoveSpeed);
            }
        }
    }
}
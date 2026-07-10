using UnityEngine;

namespace MicroForest.World
{
    public class Vegetation : MonoBehaviour
    {
        public void Cut()
        {
            Destroy(gameObject);
        }
    }
}
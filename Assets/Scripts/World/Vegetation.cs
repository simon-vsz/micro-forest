using UnityEngine;

namespace MicroForest.World
{
    public class Vegetation : MonoBehaviour
    {
        [SerializeField] private GameObject _insectPrefab;

        public void Cut()
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 hopDirection = (transform.position - playerPosition);
            hopDirection.y = 0f;

            GameObject insectObject = Instantiate(_insectPrefab, transform.position, Quaternion.identity);
            insectObject.GetComponent<Insect>().Hop(hopDirection);

            Destroy(gameObject);
        }
    }
}
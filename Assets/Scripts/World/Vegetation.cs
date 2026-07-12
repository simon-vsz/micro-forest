using System.Collections.Generic;
using UnityEngine;

namespace MicroForest.World
{
    public class Vegetation : MonoBehaviour
    {
        [SerializeField] private GameObject _insectPrefab;
        [SerializeField] private float _rareChance = 0.2f;

        public static List<Vegetation> AllVegetation { get; private set; } = new List<Vegetation>();

        private void Awake()
        {
            AllVegetation.Add(this);
        }

        private void OnDestroy()
        {
            AllVegetation.Remove(this);
        }

        public void Cut()
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 hopDirection = (transform.position - playerPosition);
            hopDirection.y = 0f;

            GameObject insectObject = Instantiate(_insectPrefab, transform.position, Quaternion.identity);
            Insect insect = insectObject.GetComponent<Insect>();
            InsectType type = Random.value < _rareChance ? InsectType.Rare : InsectType.Common;
            insect.SetType(type);
            insect.Hop(hopDirection);

            gameObject.SetActive(false);
        }

        public void Reset()
        {
            gameObject.SetActive(true);
        }
    }
}
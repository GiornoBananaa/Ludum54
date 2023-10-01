using JetBrains.Annotations;
using UnityEngine;

namespace ItemsSystem
{
    public class EnergySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] positions;
        [SerializeField] private float minDelay=5, maxDelay=10;
        [SerializeField] private GameObject energyPrefab;

        private float _delay;
        private void Update()
        {
            _delay -= Time.deltaTime;
            if (_delay <= 0)
            {
                Spawn();
            }
        }
        private void Spawn()
        {
            _delay = Random.Range(minDelay, maxDelay);

            Transform transform = positions[Random.Range(0, positions.Length)];
            Instantiate(energyPrefab, transform.position, Quaternion.identity);
        }
    }
}

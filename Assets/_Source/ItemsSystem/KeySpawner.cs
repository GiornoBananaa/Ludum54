using System;
using PathSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemsSystem
{
    public class KeySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject keyPrefab;
        [SerializeField] private int count;
        [SerializeField] private int maxKeysOnOnePart;
        
        public void Spawn(PathNode[] InfectedNodes)
        {
            int keys = Random.Range(0, maxKeysOnOnePart+1);
            for (int i = 0; i < InfectedNodes.Length; i++)
            {
                Transform transform = InfectedNodes[Random.Range(0, InfectedNodes.Length)].transform;
                Instantiate(keyPrefab, transform.position, Quaternion.identity);
                count--;
            }
        }
    }
}

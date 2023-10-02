using PathSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace ItemsSystem
{
    public class CoreShardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject shardPrefab;
        [SerializeField] private int count;
        [SerializeField] private int maxShardsOnOnePart;

        private int _spawned;
        
        public void Spawn(PathNode[] InfectedNodes)
        {
            int shard = Random.Range(1, maxShardsOnOnePart+1);
            for (int i = 0; i < shard; i++)
            {
                if(_spawned >= count) return;
                Transform transform = InfectedNodes[Random.Range(0, InfectedNodes.Length)].transform;
                Instantiate(shardPrefab, transform.position, Quaternion.identity);
                _spawned++;
            }
        }
    }
}

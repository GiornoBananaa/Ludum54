using System.Collections;
using System.Collections.Generic;
using PathSystem;
using UnityEngine;
namespace ItemsSystem
{
    [RequireComponent(typeof(EnergyAccumulator))]
    [RequireComponent(typeof(Collider2D))]
    public class CoreItemUnloader : MonoBehaviour
    {
        [SerializeField] private int energyExchangeRate = 1;
        [SerializeField] private List<InfectedPath> infectedPaths;
        [SerializeField] private List<GameObject> coreFragments;
        [SerializeField] private AudioSource virusUnlocker;
        [SerializeField] private AudioSource shardPlace;
        
        private EnergyAccumulator energyAccumulator;
        
        private void Start()
        {
            energyAccumulator = GetComponent<EnergyAccumulator>();
        }
        private void UnloadInventory(Inventory inventory)
        {
            energyAccumulator.AddEnegry(inventory.energy * energyExchangeRate);
            if(inventory.keys > 0) virusUnlocker.Play();
            
            for (int i = 0; i < inventory.keys; i++)
            {
                if (infectedPaths.Count == 0) break;
                infectedPaths[infectedPaths.Count-1].OpenPath();
                infectedPaths.RemoveAt(infectedPaths.Count - 1);
            }
            if(inventory.fragments > 0) shardPlace.Play();
            for (int i = 0; i < inventory.fragments; i++)
            {
                if (coreFragments.Count == 0) break;
                coreFragments[coreFragments.Count-1].SetActive(true);
                coreFragments.RemoveAt(coreFragments.Count - 1);

                if(coreFragments.Count == 0) GameManager.Instance.WinGame();
            }
            inventory.Clear();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            Inventory inventory;
            if (collision.gameObject.TryGetComponent(out inventory))
            {
                UnloadInventory(inventory);

            }
        }
    }
}

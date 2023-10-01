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
        
        private EnergyAccumulator energyAccumulator;
        private void Start()
        {
            energyAccumulator = GetComponent<EnergyAccumulator>();
        }
        private void UnloadInventory(Inventory inventory)
        {
            energyAccumulator.AddEnegry(inventory.energy * energyExchangeRate);
            for (int i = 0; i < inventory.keys; i++)
            {
                infectedPaths[infectedPaths.Count-1].OpenPath();
                infectedPaths.RemoveAt(infectedPaths.Count - 1);
            }
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

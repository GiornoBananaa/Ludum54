using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ItemsSystem
{
    [RequireComponent(typeof(EnergyAccumulator))]
    [RequireComponent(typeof(Collider2D))]
    public class CoreItemUnloader : MonoBehaviour
    {
        [SerializeField] private int energyExchangeRate=1;

        private EnergyAccumulator energyAccumulator;
        private void Start()
        {
            energyAccumulator = GetComponent<EnergyAccumulator>();
        }
        private void UnloadInventory(Inventory inventory)
        {
            energyAccumulator.AddEnegry(inventory.energy * energyExchangeRate);


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

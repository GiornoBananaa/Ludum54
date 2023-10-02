using System;
using UnityEngine;

namespace ItemsSystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] private AudioSource energyPickUpAudio;
        [SerializeField] private AudioSource corePickUpAudio;
        [SerializeField] private AudioSource keyPickUpAudio;

        public event EventHandler OnInventoryChanged;

        public int keys { get; private set; }
        public int energy { get; private set; }
        public int fragments { get; private set; }

        public bool AddKey(int amount = 1)
        {
            if (IsInventoryFull()) return false;
            if(keyPickUpAudio != null)keyPickUpAudio.Play();
            keys += amount;
            OnInventoryChanged?.Invoke(this, new EventArgs());
            return true;
        }

        public bool AddEnergy(int amount = 1)
        {
            if (IsInventoryFull()) return false;
            if(energyPickUpAudio != null)energyPickUpAudio.Play();
            energy += amount;
            OnInventoryChanged?.Invoke(this, new EventArgs());
            return true;
        }
        
        public bool AddFragment(int amount = 1)
        {
            if (IsInventoryFull()) return false;
            if(corePickUpAudio != null)corePickUpAudio.Play();
            fragments += amount;
            OnInventoryChanged?.Invoke(this, new EventArgs());
            return true;
        }
        
        public bool IsInventoryFull()
        {
            return energy + keys + fragments >= inventorySize;
        }

        public void Clear()
        {
            energy = 0;
            keys = 0;
            fragments = 0;
            OnInventoryChanged?.Invoke(this, new EventArgs());
        }

        public int GetInventorySize()
        {
            return inventorySize;
        }
    }
}

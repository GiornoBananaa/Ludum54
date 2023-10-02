using UnityEngine;

namespace ItemsSystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] private AudioSource energyPickUpAudio;
        [SerializeField] private AudioSource corePickUpAudio;
        [SerializeField] private AudioSource keyPickUpAudio;

        public int keys { get; private set; }
        public int energy { get; private set; }
        public int fragments { get; private set; }

        public bool AddKey(int amount = 1)
        {
            if (IsInventoryFull()) return false;
            keyPickUpAudio.Play();
            keys += amount;
            return true;
        }

        public bool AddEnergy(int amount = 1)
        {
            if (IsInventoryFull()) return false;
            energyPickUpAudio.Play();
            energy += amount;
            return true;
        }
        
        public bool AddFragment(int amount = 1)
        {
            if (IsInventoryFull()) return false;
            corePickUpAudio.Play();
            fragments += amount;
            return true;
        }
        
        private bool IsInventoryFull()
        {
            return energy + keys + fragments >= inventorySize;
        }

        public void Clear()
        {
            energy = 0;
            keys = 0;
            fragments = 0;
        }
    }
}

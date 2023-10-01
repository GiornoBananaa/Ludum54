using System;
using UnityEngine;

namespace ItemsSystem
{
    public class Energy : Item
    {
        protected override bool PickUp(Inventory targetInventory)
        {

            return targetInventory.AddEnergy();
        }
    }
}

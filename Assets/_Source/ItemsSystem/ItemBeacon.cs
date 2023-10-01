using System;
using UnityEngine;

namespace ItemsSystem
{
    public class ItemBeacon : ObjectBeacon
    {
        [SerializeField] private Item item;

        private void Update()
        {
            if (item == null)
            {
                TurnBeaconOff();
                return;
            }
            LookAtItem(item.transform);
            CheckDistance(item.transform);
        }

        private void TurnBeaconOff()
        {
            gameObject.SetActive(false);
        }
    }
}

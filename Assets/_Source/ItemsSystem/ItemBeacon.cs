using System;
using UnityEngine;

namespace ItemsSystem
{
    public class ItemBeacon : MonoBehaviour
    {
        [SerializeField] private float minRenderDistance;
        [SerializeField] private Item item;
        [SerializeField] private GameObject sprite;

        private bool _isHidden = false;

        private void Start()
        {
            //item.OnPickUp += TurnBeaconOff;
        }

        private void Update()
        {
            LookAtItem();
            CheckDistance();
        }
        
        private void LookAtItem()
        {
            transform.right = item.transform.position - transform.position;
        }
        
        private void CheckDistance()
        {
            if (Vector3.Distance(item.transform.position,transform.position) < minRenderDistance)
            {
                _isHidden = true;
                sprite.SetActive(false);
            }
            else if(_isHidden)
            {
                _isHidden = false;
                sprite.SetActive(true);
            }
        }
        
        private void TurnBeaconOff()
        {
            gameObject.SetActive(false);
        }
    }
}

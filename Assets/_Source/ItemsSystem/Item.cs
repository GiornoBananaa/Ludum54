using UnityEngine;

namespace ItemsSystem
{
    public class Item : MonoBehaviour
    {
        [SerializeField] protected LayerMask playerLayerMask;

        protected Inventory Inventory;
        
        
        public void Construct(Inventory inventory)
        {
            Inventory = inventory;
        }
        
        protected virtual void PickUp() { }
        
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (playerLayerMask == (playerLayerMask | (1 << collision.gameObject.layer)))
            {
                PickUp();
                Destroy(gameObject);
            }
        }
    }
}

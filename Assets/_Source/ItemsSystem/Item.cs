using UnityEngine;

namespace ItemsSystem
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected LayerMask playerLayerMask;

        protected abstract bool PickUp(Inventory targetInventory);

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerLayerMask == (playerLayerMask | (1 << collision.gameObject.layer)))
            {
                Inventory targetInventory;
                if (collision.gameObject.TryGetComponent(out targetInventory))
                {
                    if (PickUp(targetInventory))
                    {
                        Destroy(gameObject);

                    }
                }
            }
        }
    }
}

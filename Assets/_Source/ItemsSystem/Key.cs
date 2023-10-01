namespace ItemsSystem
{
    public class Key : Item
    {
        protected override bool PickUp(Inventory targetInventory)
        {
            return targetInventory.AddKey();
        }
    }
}

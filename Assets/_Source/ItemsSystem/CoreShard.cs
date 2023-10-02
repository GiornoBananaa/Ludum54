namespace ItemsSystem
{
    public class CoreShard : Item
    {
        protected override bool PickUp(Inventory targetInventory)
        {
            return targetInventory.AddFragment();
        }
    }
}

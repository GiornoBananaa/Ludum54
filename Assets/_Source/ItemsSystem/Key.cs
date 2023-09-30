namespace ItemsSystem
{
    public class Key : Item
    {
        protected override void PickUp()
        {
            Inventory.AddKey();
        }
    }
}

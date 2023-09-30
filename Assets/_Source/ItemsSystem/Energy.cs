namespace ItemsSystem
{
    public class Energy : Item
    {
        protected override void PickUp()
        {
            Inventory.AddEnergy();
        }
    }
}

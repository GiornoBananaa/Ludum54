using ItemsSystem;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Inventory))]
public class InventoryFrontend : MonoBehaviour
{
    [SerializeField] private Color keyColor, fragmentsColor, energyColor;
    [SerializeField] private SpriteRenderer[] slots;

    private Inventory inventory;
    private int currentSlotID;
    private void Start()
    {
        inventory = GetComponent<Inventory>();
        inventory.OnInventoryChanged += Inventory_OnInventoryChanged;
        DrawInventory();
    }

    private void Inventory_OnInventoryChanged(object sender, System.EventArgs e)
    {
        DrawInventory();
    }

    private void DrawInventory()
    {
        Clear();
        //Debug.Log(inventory.fragments + " " + inventory.keys + " " + inventory.energy);

        for (int i = 0; i < inventory.fragments; i++)
            FillSlot(fragmentsColor);
        for (int i = 0; i < inventory.keys; i++)
            FillSlot(keyColor);
        for (int i = 0; i < inventory.energy; i++)
            FillSlot(energyColor);
    }
    private void FillSlot(UnityEngine.Color color)
    {
        //        if (ID > inventory.GetInventorySize())
        //            return;
        slots[currentSlotID].gameObject.SetActive(true);
        slots[currentSlotID].color = color;
        currentSlotID++;
    }

    private void Clear()
    {
        currentSlotID = 0;
        foreach (var slot in slots)
        {
            slot.gameObject.SetActive(false);
        }
    }
}

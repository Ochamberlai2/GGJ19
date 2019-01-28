using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SerializedMonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private List<ItemDefinition> inventorySlots;
    [SerializeField]
    private int maxInventorySize = 3;


    /*
     * This function will return true if there is at least one slot open in the inventory
     */
    public bool CanAddToInventory()
    {
        return inventorySlots.Count + 1 <= maxInventorySize;
    }

    /*
     *  This function will add an item to the inventory. It will return false if it cannot add an item to the inventory or true if it has added the item
     */
     public bool AddItemToInventory(ItemDefinition itemToAdd)
    {
        if(!CanAddToInventory())
        {
            return false;
        }
        inventorySlots.Add(itemToAdd);
        return true;
    }

    /*
     * This function will remove an item from the inventory. It will return false if the item does not exist in the inventory, or true if it has been removed
     */
     public bool RemoveItemFromInventory(ItemDefinition itemToRemove)
    {
        if (!inventorySlots.Contains(itemToRemove))
            return false;

        inventorySlots.Remove(itemToRemove);
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This object just holds all the inventory slots
/// </summary>
[CreateAssetMenu(menuName= "Character/Inventory", fileName = "New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<InventorySlot> InventorySlots = new List<InventorySlot>();

	/// <summary>
	/// Adds an item to the inventory.
	/// </summary>
	/// <param name="item">The item to add.</param>
	public InventorySlot AddItem(Item item)
	{
		InventorySlot freeInventorySlot = GetFreeInventorySlot();
		freeInventorySlot.Item = item;
		return freeInventorySlot;
	}

	public InventorySlot FindSlotFromItem(Item item)
	{
		foreach (InventorySlot inventorySlot in InventorySlots)
		{
			if (inventorySlot.Item == item)
			{
				return inventorySlot;
			}
		}
		return null;
	}

	public bool HasItem(Item item)
	{
		foreach(InventorySlot inventorySlot in InventorySlots)
		{
			if (inventorySlot.Item == item)
			{
				return true;
			}
		}
		return false;
	}

	private InventorySlot GetFreeInventorySlot()
	{
		foreach(InventorySlot inventorySlot in InventorySlots)
		{
			if (inventorySlot.Item == null)
			{
				return inventorySlot;
			}
		}
		return null;
	}
}

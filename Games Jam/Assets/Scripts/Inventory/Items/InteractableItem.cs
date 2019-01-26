using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
	[SerializeField] private Item item;

	public void OnMouseDown()
	{
		InventorySlot inventorySlot = item.Inventory.FindSlotFromItem(item);
		if (inventorySlot != null && item.Consumable)
		{
			inventorySlot.Item = null;
			if (item.UseEvent != null)
			{
				item.UseEvent.Raise();
			}
			Destroy(gameObject);
			return;
		}

		if (item.Inventory == null)
		{
			if (item.UseEvent != null)
			{
				item.UseEvent.Raise();
			}
			Destroy(gameObject);
		}
		else
		{
			// add item to inventory
			InventorySlot newInventorySlot = item.Inventory.AddItem(item);
			
			if (newInventorySlot != null && newInventorySlot.SlotTransform != null)
			{
				transform.SetParent(newInventorySlot.SlotTransform.RuntimeValue);
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
			}
		}
	}
}

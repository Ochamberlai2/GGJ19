using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
	[SerializeField] private Item item;

	public void OnMouseDown()
	{
		if (item.Inventory.HasItem(item) && item.Consumable)
		{
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
			InventorySlot inventorySlot = item.Inventory.AddItem(item);
			
			if (inventorySlot != null && inventorySlot.SlotTransform != null)
			{
				transform.SetParent(inventorySlot.SlotTransform.RuntimeValue);
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
			}
		}
	}
}

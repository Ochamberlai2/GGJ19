using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
	[SerializeField] private Item item;

	public void OnMouseDown()
	{
		if (item.Inventory == null)
		{
			gameObject.SetActive(false);
			if (item.UseEvent != null)
			{
				item.UseEvent.Raise();
			}
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

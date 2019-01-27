using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
	[SerializeField] private Item item;

	public void OnMouseDown()
	{
		if (item == null)
		{
			Debug.LogWarning("Item doesn't have item scriptable object attached.");
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
			InventorySlot inventorySlot = item.Inventory.FindSlotFromItem(item);

			Debug.Log("Inventory Slot: " + inventorySlot);
			if (inventorySlot != null && item.Consumable)
			{
				Debug.Log("Eating consumable");
				inventorySlot.Item = null;
				if (item.UseEvent != null)
				{
					item.UseEvent.Raise();
				}
				Destroy(gameObject);
				return;
			}

			// add item to inventory
			InventorySlot newInventorySlot = item.Inventory.AddItem(item);
			
			if (newInventorySlot != null && newInventorySlot.SlotTransform != null)
			{
				transform.SetParent(newInventorySlot.SlotTransform.RuntimeValue);
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				transform.GetComponent<SpriteRenderer>().sortingLayerName = "Items_After";
			}
		}
	}
}

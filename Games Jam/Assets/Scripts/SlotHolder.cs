using UnityEngine;
using System.Collections;

public class SlotHolder : MonoBehaviour
{
	[SerializeField] private InventorySlot _inventorySlot;
	public InventorySlot InventorySlot
	{
		get
		{
			return _inventorySlot;
		}
		set
		{
			_inventorySlot = value;
			OnEnable();
		}
	}

	[Tooltip("This is where the object will move to when equipped.")]
	[SerializeField] private Transform itemHolder;

	private void OnEnable()
	{
		InventorySlot.OnAddItem += ShowItemOnCharacter;
		ShowItemOnCharacter(InventorySlot.Item);
	}

	private void OnDisable()
	{
		InventorySlot.OnAddItem -= ShowItemOnCharacter;
	}

	public void ShowItemOnCharacter(Item item)
	{
		if (item == null)
		{
			return;
		}

		// show the item on the character
		Transform itemTransform = item.AssignedObject.transform;
		
		itemTransform.SetParent(itemHolder);
		itemTransform.localPosition = Vector3.zero;
		itemTransform.localRotation = Quaternion.identity;
	}
}

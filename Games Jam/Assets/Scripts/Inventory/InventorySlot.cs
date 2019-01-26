using UnityEngine;

[CreateAssetMenu(menuName = "Character/Inventory Slot", fileName = "New Inventory Slot")]
public class InventorySlot : ScriptableObject, ISerializationCallbackReceiver
{
	public TransformVariable SlotTransform;
	[SerializeField] private Item startingItem;
	[System.NonSerialized] private Item _inventoryItem;

	public delegate void AddItem(Item item);
	public event AddItem OnAddItem;

	public Item Item
	{
		get
		{
			return _inventoryItem;
		}
		set
		{
			if (_inventoryItem == value)
			{
				return;
			}
			
			_inventoryItem = value;
			OnAddItem?.Invoke(_inventoryItem);
		}
	}

	public void OnBeforeSerialize()
	{
		_inventoryItem = startingItem;
	}

	public void OnAfterDeserialize()
	{
		
	}
}

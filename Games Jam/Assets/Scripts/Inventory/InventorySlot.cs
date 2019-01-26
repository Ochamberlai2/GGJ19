using UnityEngine;

[CreateAssetMenu(menuName = "Character/Inventory Slot", fileName = "New Inventory Slot")]
public class InventorySlot : ScriptableObject
{
	[SerializeField] private Item _inventoryItem;

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
}

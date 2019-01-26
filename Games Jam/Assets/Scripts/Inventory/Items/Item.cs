using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
	[Tooltip("If this exists, it adds the item to inventory when clicked.")]
	public Inventory Inventory;
	[Tooltip("The event that fires when this object is used.")]
	public GameEvent UseEvent;
}

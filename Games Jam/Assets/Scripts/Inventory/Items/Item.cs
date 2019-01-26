using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
	[Tooltip("If this exists, it adds the item to inventory when clicked.")]
	public Inventory Inventory;
	[Tooltip("The event that fires when this object is used.")]
	public GameEvent UseEvent;

	/// <summary>
	/// This should be called from the InteractableItem class.
	/// It will run when the object is clicked.
	/// </summary>
	public virtual void OnClick()
	{
		
	}
}

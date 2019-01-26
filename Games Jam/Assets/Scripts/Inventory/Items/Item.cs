using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
	[Tooltip("If this exists, it adds the item to inventory when clicked.")]
	[SerializeField] private Inventory inventory;
	[Tooltip("The event that fires when this object is used.")]
	public GameEvent UseEvent;

	[HideInInspector] public InteractableItem AssignedObject;

	/// <summary>
	/// This should be called from the InteractableItem class.
	/// It will run when the object is clicked.
	/// </summary>
	public virtual void OnClick()
	{
		if (inventory != null)
		{
			// add to inventory
			inventory.AddItem(this);
		}
		else
		{
			// use item immediately
			AssignedObject.gameObject.SetActive(false);
			if (UseEvent != null)
			{
				UseEvent.Raise();
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
	[SerializeField] private Item item;

	private void Awake()
	{
		if (item == null)
		{
			Debug.LogWarning("MonoBehaviour Item has no Scriptable Object Item attached.", gameObject);
			return;
		}
		item.AssignedObject = this;
	}

	// private void Update()
	// {
		// // if clicked then...
		// // item.OnClick();
	// }
}

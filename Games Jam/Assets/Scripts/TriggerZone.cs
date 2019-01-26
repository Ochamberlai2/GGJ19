using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
	[SerializeField] private string tag;
	[SerializeField] private UnityEvent OnTrigger;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag(tag)) return;
		OnTrigger.Invoke();
	}
}

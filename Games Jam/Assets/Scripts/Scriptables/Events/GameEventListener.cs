using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class GameEventListener : MonoBehaviour
{
	[SerializeField] private GameEvent _event;
	[SerializeField] private UnityEvent response;

	private void OnEnable()
	{
		if (_event == null) return;
		_event.RegisterListener(this);
	}

	private void OnDisable()
	{
		if (_event == null) return;
		_event.UnregisterListener(this);
	}

	public void OnEventRaised()
	{
		response.Invoke();
	}
}
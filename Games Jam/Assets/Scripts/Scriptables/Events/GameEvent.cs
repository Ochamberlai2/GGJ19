using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent", menuName = "Events/GameEvent", order = 2)]
public class GameEvent : RaisableEvent
{
	private List<GameEventListener> listeners = new List<GameEventListener>();

	public override void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			if (listeners[i] == null)
			{
				Debug.Log("Cleared up null listener at " + i + " position.");
				listeners.RemoveAt(i);
				continue;
			}
			listeners[i].OnEventRaised();
		}
	}

	public void RegisterListener(GameEventListener listener)
	{
		if (!listeners.Contains(listener))
			listeners.Add(listener);
		else
			Debug.LogWarning("Listener reregistered to event.");
	}

	public void UnregisterListener(GameEventListener listener)
	{
		listeners.Remove(listener);
	}
}
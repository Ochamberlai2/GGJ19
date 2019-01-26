using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformGroup : MonoBehaviour
{
    [System.NonSerialized] private List<TransformVariable> transformVariables;

	public void Add(TransformVariable t)
	{
		transformVariables.Add(t);
	}

	public void Remove(TransformVariable t)
	{
		transformVariables.Remove(t);
	}
}

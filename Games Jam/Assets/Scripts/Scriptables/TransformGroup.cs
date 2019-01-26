using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Transform Group", menuName = "TransformGroup")]
public class TransformGroup : ScriptableObject
{
    [System.NonSerialized] public List<Transform> Transforms = new List<Transform>();

	public void Add(Transform t)
	{
		Transforms.Add(t);
	}

	public void Remove(Transform t)
	{
		Transforms.Remove(t);
	}

	public static implicit operator List<Transform>(TransformGroup tg)
	{
		return tg.Transforms;
	}
}

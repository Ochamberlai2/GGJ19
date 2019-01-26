using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToTransformGroup : MonoBehaviour
{
    [SerializeField] private TransformGroup transformGroup;

	private void OnEnable()
	{
		transformGroup.Add(transform);
	}
	private void OnDisable()
	{
		transformGroup.Remove(transform);
	}
}

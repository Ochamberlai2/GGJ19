using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowTransform : MonoBehaviour
{
    [SerializeField] private Transform followTransform;

	private void Update()
	{
		if (followTransform == null)
		{
			return;
		}
		transform.position = followTransform.position;
		transform.rotation = followTransform.rotation;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
	[SerializeField] private SceneViews sceneViews;

	private void Awake()
	{
		for (int i = 0; i < Mathf.Min(sceneViews.SceneViewList.Count, transform.childCount); i++)
		{
			sceneViews.SceneViewList[i].CameraTransform = transform.GetChild(i);
		}
	}
}

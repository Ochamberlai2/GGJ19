using UnityEngine;

[System.Serializable]
public class SceneView
{
	// this is added using CameraPositions script
	[HideInInspector] public Transform CameraTransform;
	public GameEvent OnEnterScene;
	public string DialogueIndex;
}
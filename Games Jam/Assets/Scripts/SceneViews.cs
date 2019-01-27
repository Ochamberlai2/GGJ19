using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneViews", fileName = "New Scene Views")]
public class SceneViews : ScriptableObject
{
	public List<SceneView> SceneViewList = new List<SceneView>();
}

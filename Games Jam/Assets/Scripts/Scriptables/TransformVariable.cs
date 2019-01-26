using UnityEngine;

[CreateAssetMenu(fileName = "NewTransformVariable", menuName = "Variables/Transform")]
public class TransformVariable : ScriptableObject
{
	[System.NonSerialized] public Transform RuntimeValue;
}
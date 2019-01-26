using UnityEngine;

public class SetTransformVariable : MonoBehaviour
{
	[SerializeField] private TransformVariable transformVariable;

	void Awake()
	{
		if (transformVariable == null)
		{
			Debug.LogWarning("No Transform Variable attached to object", gameObject);
			return;
		}
		transformVariable.RuntimeValue = transform;
	}
}
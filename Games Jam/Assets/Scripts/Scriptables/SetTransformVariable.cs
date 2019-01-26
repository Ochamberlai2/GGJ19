using UnityEngine;

public class SetTransformVariable : MonoBehaviour
{
	[SerializeField] private TransformVariable transformVariable;

	void Awake()
	{
		transformVariable.RuntimeValue = this.transform;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
	private void FixedUpdate()
	{
		Run();
	}

	private void Run()
	{
		transform.position = transform.position + (Input.GetAxis("Horizontal") * Vector3.right * 2f * Time.fixedDeltaTime);
	}
}

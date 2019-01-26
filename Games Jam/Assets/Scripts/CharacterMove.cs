using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
	Camera mainCamera;
	float MovePosition;
	float MoveDirection = 0f;

	private void Awake()
	{
		mainCamera = Camera.main;
		MovePosition = transform.position.x;
	}

	private void FixedUpdate()
	{
		Run();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
			{
				MovePosition = hit.point.x;
				MoveDirection = transform.position.x < MovePosition ? 1f : -1f;
			}
		}
	}

	private void Run()
	{
		Vector3 newPosition = transform.position;
		newPosition = newPosition + (MoveDirection * Vector3.right * 4f * Time.fixedDeltaTime);

		if (MoveDirection == 1f)
		{
			newPosition.x = Mathf.Min(newPosition.x, MovePosition);
		}
		else if (MoveDirection == -1f)
		{
			newPosition.x = Mathf.Max(newPosition.x, MovePosition);
		}

		transform.position = newPosition;
	}
}

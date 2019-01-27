using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
	[SerializeField] private string sceneNameSwitchAfterDeath;
	
	Camera mainCamera;
	float MovePosition;
	float MoveDirection = 0f;

	private bool Dead;

	private List<Transform> transforms;
	private List<BodyAnimator> bodyAnimators;

	private class BodyAnimator
	{
		public BodyAnimator(Animator anim)
		{
			this.Animator = anim;
		}
		private Animator _animator;
		public Animator Animator
		{
			get
			{
				return _animator;
			}
			set
			{
				_animator = value;
				RunningHash = Animator.StringToHash("Running");
				DeadHash = Animator.StringToHash("Dead");
			}
		}
		public int RunningHash;
		public int DeadHash;
	}

	private void Awake()
	{
		bodyAnimators = new List<BodyAnimator>();

		mainCamera = Camera.main;
		MovePosition = transform.position.x;
		var animators = GetComponentsInChildren<Animator>();
		foreach (Animator anim in animators)
		{
			bodyAnimators.Add(new BodyAnimator(anim));
		}

	}

	private void FixedUpdate()
	{
		if (Dead) return;
		Run();
	}

	private void Update()
	{
		if (Dead) return;
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
			{
				MovePosition = hit.point.x;
				MoveDirection = transform.position.x < MovePosition ? 1f : -1f;
				foreach(Transform child in transform)
				{
					child.localScale = new Vector3(MoveDirection, child.localScale.y, child.localScale.z);
				}
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

		bool moving = transform.position != newPosition;
		
		foreach(BodyAnimator bodyAnim in bodyAnimators)
		{
			bodyAnim.Animator.SetBool(bodyAnim.RunningHash, moving);
		}

		transform.position = newPosition;
	}

	public void Die()
	{
		Dead = true;
		foreach (BodyAnimator bodyAnim in bodyAnimators)
		{
			bodyAnim.Animator.SetBool(bodyAnim.DeadHash, true);
		}
		
		Scene deathScreen = SceneManager.GetSceneByName(sceneNameSwitchAfterDeath);
		if (deathScreen == null)
		{
			Debug.LogWarning("No death screen.");
			return;
		}

		StartCoroutine(SwitchScene(sceneNameSwitchAfterDeath, 5f));
	}

	private IEnumerator SwitchScene(string sceneName, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(sceneName);
	}
}

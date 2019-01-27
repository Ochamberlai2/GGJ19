using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    private float transitionSpeed = 2f;

    [SerializeField]
    private SceneViews sceneViews;

    private int currentTransformIndex = 0;
    private bool currentlyTransitioning;

    public void Start()
    {
        if (sceneViews.SceneViewList.Count == 0)
            throw new System.Exception("There are no camera transform positions attributed to the camera");
		
		DialogController.Instance.OpenDialog(sceneViews.SceneViewList[0].DialogueIndex);
    }
    public void TransitionCamera()
    {
        int nextTransformIndex = currentTransformIndex + 1;

        if (nextTransformIndex > sceneViews.SceneViewList.Count)
        {
            ResetCamera();
            return;
        }


        float startTime = Time.time;
		SceneView sceneView1 = sceneViews.SceneViewList[currentTransformIndex];
		SceneView sceneView2 = sceneViews.SceneViewList[nextTransformIndex];

		Vector3 startPos = sceneView1.CameraTransform.position;
		Vector3 endPos = sceneView2.CameraTransform.position;

		float journeyLength = Vector3.Distance(startPos, endPos);
        if (currentlyTransitioning == false)
        {
            StartCoroutine(MoveCameraBetweenPoints(sceneView1, sceneView2, startTime, journeyLength));
        }
        currentTransformIndex = nextTransformIndex;

    }

    private IEnumerator MoveCameraBetweenPoints(SceneView sceneView1, SceneView sceneView2, float startTime, float journeyLength)
    {
        currentlyTransitioning = true;
        while (transform.position != sceneView2.CameraTransform.position)
        {
            float distanceCovered = (Time.time - startTime) * transitionSpeed;
            float fractionJourneyCompleted = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(sceneView1.CameraTransform.position, sceneView2.CameraTransform.position, fractionJourneyCompleted);
            yield return null;
        }
        currentlyTransitioning = false;
		// do stuff here

		DialogController.Instance.OpenDialog(sceneView2.DialogueIndex);
		if (sceneView2.OnEnterScene != null)
		{
			sceneView2.OnEnterScene.Raise();
		}
    }


    public void ResetCamera()
    {
        transform.position = sceneViews.SceneViewList[0].CameraTransform.position;
        currentTransformIndex = 0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    private float transitionSpeed = 2f;

    [SerializeField]
    private List<Transform> cameraTransforms;

    private int currentTransformIndex = 0;
    private bool currentlyTransitioning;

    public void Start()
    {
        if (cameraTransforms.Count == 0)
            throw new System.Exception("There are no camera transform positions attributed to the camera");
    }
    public void TransitionCamera()
    {

       

        int nextTransformIndex = currentTransformIndex + 1;

        if (nextTransformIndex > cameraTransforms.Count)
        {
            ResetCamera();
            return;
        }


        float startTime = Time.time;
        float journeyLength = Vector3.Distance(cameraTransforms[currentTransformIndex].position, cameraTransforms[nextTransformIndex].position);
        if (currentlyTransitioning == false)
        {
            StartCoroutine(MoveCameraBetweenPoints(cameraTransforms[currentTransformIndex], cameraTransforms[nextTransformIndex], startTime, journeyLength));
        }
        currentTransformIndex = nextTransformIndex;


    }

    private IEnumerator MoveCameraBetweenPoints(Transform startTransform, Transform destinationTransform, float startTime, float journeyLength)
    {
        currentlyTransitioning = true;
        while (transform.position != destinationTransform.position)
        {
            float distanceCovered = (Time.time - startTime) * transitionSpeed;
            float fractionJourneyCompleted = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startTransform.position, destinationTransform.position, fractionJourneyCompleted);
            yield return null;
        }
        currentlyTransitioning = false;
        yield return null;
    }


    public void ResetCamera()
    {
        transform.position = cameraTransforms[0].position;
        currentTransformIndex = 0;
    }
}
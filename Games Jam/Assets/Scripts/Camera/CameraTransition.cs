using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    private float transitionSpeed = 2f;

    [SerializeField]
    private TransformGroup cameraTransforms;

    private int currentTransformIndex = 0;
    private bool currentlyTransitioning;

    public void TransitionCamera()
    {
        int nextTransformIndex = currentTransformIndex + 1;

        if (nextTransformIndex > cameraTransforms.Transforms.Count)
        {
            ResetCamera();
            return;
        }


        float startTime = Time.time;
        float journeyLength = Vector3.Distance(cameraTransforms.Transforms[currentTransformIndex].position, cameraTransforms.Transforms[nextTransformIndex].position);
        if(currentlyTransitioning == false)
        {
            StartCoroutine(MoveCameraBetweenPoints(cameraTransforms.Transforms[currentTransformIndex], cameraTransforms.Transforms[nextTransformIndex], startTime, journeyLength));
        }
        currentTransformIndex = nextTransformIndex;


    }

    private IEnumerator MoveCameraBetweenPoints(Transform startTransform, Transform destinationTransform, float startTime, float journeyLength)
    {
        currentlyTransitioning = true;
        while(transform.position != destinationTransform.position)
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
        transform.position = cameraTransforms.Transforms[0].position;
        currentTransformIndex = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countryMarkerBehaviour : MonoBehaviour
{

    public int interPolationFramesCount = 30;
    int elapsedFrames = 0;
    private Vector3 startingScale = new Vector3(1, 1, 1);
    private Vector3 endingScale = new Vector3(2, 2, 2);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.z < 1.99f)
        {
            float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
            transform.localScale = Vector3.Lerp(startingScale, endingScale, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
            elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        }
        else if (transform.localScale.z >= 1.99f)
        {
            float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
            transform.localScale = Vector3.Lerp(endingScale, startingScale, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
            elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        }
        }
}

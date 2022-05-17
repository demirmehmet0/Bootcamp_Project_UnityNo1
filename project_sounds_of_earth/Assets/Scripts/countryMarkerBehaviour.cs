using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countryMarkerBehaviour : MonoBehaviour
{

    private int interPolationFramesCount = 200;
    private float localScaleUpperbound = 1.99f;
    private float localScaleLowerbound = 1.02f;
    int elapsedFrames = 0;
    bool _timeToIncreaseSize = true;

    private Vector3 startingScale = new Vector3(1, 1, 1);
    private Vector3 endingScale = new Vector3(2, 2, 2);
   

    // Update is called once per frame
    void Update()
    {
        changeSize();
    }

    void changeSize()
    {
        if (transform.localScale.z < localScaleUpperbound && _timeToIncreaseSize)
        {
            increaseLocalScale();

        }
        else if (transform.localScale.z >= localScaleLowerbound && !_timeToIncreaseSize)
        {
            decreaseLocalScale();
        }
    }

    void increaseLocalScale()
    {
        float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
        transform.localScale = Vector3.Lerp(startingScale, endingScale, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
        elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        if(transform.localScale.z > localScaleUpperbound)
        {
            elapsedFrames = 0;
            _timeToIncreaseSize = false;
        }
    }

    void decreaseLocalScale()
    {
        float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
        transform.localScale = Vector3.Lerp(endingScale, startingScale, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
        elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        if (transform.localScale.z < localScaleLowerbound)
        {
            elapsedFrames = 0;
            _timeToIncreaseSize = true;
        }
    }
}

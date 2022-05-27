using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countryMarkerBehaviour : MonoBehaviour
{

    private int interPolationFramesCount = 200;
    private float localScaleUpperbound = 1.49f;
    private float localScaleLowerbound = 1.01f;
    int elapsedFrames = 0;
    float tempMiddleVectorMagnitude = 0;
    bool _timeToIncreaseSize = true;
    bool _newScaleSizeCalculated = false;

    private Vector3 startingScale = new Vector3(1, 1, 1);
    private Vector3 endingScale = new Vector3(1.1f, 1.1f, 1.1f);
    selectCountries _selectCountries;

    private void Start()
    {
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
    }
 
    void Update()
    {
        if (!_newScaleSizeCalculated)
        {
            tempMiddleVectorMagnitude = _selectCountries.magnitudeOfcombinationVector;
            calculatedEndScaleAndUpperBound();
        }

        DetectChangeinQuestionPosition();
        changeSize();
    }

    void changeSize()
    {


        if (transform.localScale.z < localScaleUpperbound && _timeToIncreaseSize)
        {
            increaseLocalScale();

        }
        else if (transform.localScale.z > localScaleLowerbound && !_timeToIncreaseSize)
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

    void calculatedEndScaleAndUpperBound()
    {
        if (tempMiddleVectorMagnitude > 78)
        {
            endingScale = startingScale * 1.4f;
        }
        else if (tempMiddleVectorMagnitude <= 78 && tempMiddleVectorMagnitude > 76)
        {
            endingScale = startingScale * 1.6f;
        }
        else if (tempMiddleVectorMagnitude <= 76 && tempMiddleVectorMagnitude > 74)
        {
            endingScale = startingScale * 1.8f;
        }
        else if (tempMiddleVectorMagnitude <= 74 && tempMiddleVectorMagnitude > 72)
        {
            endingScale = startingScale * 2.0f;
        }
        else if (tempMiddleVectorMagnitude <= 72 && tempMiddleVectorMagnitude > 70)
        {
            endingScale = startingScale * 2.2f;
        }
        else
        {
            endingScale = startingScale * 2.4f;
        }

        localScaleUpperbound = endingScale.x -0.01f;

        //Debug.Log("Magnitude of comb vector: "+ _selectCountries.magnitudeOfcombinationVector+ "ending scale: " + endingScale + " localScaleBOund: " + localScaleUpperbound) ;

        _newScaleSizeCalculated = true;
    }

    void DetectChangeinQuestionPosition()
    {
        if(_selectCountries.magnitudeOfcombinationVector != tempMiddleVectorMagnitude)
        {
            _newScaleSizeCalculated = false;
           
        }      
                                         
    }
    
}

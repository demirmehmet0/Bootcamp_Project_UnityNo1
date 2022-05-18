using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int interPolationFramesCount = 120;
    int elapsedFrames = 0;
    Vector3 endPosition = new Vector3(0, 0, 0);
    Vector3 endPosRotation = new Vector3(0, 0, 0);
    Vector3 focalPoint = new Vector3(0, 0, 0);
    float cameraDistanceMultiplier = 3;
    bool positionSet = false;


    Vector3 cameraOffsetVector = new Vector3(35, 10, 0);
    selectCountries _selectCountries;
    // Start is called before the first frame update
    void Start()
    {
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        changeCameraPosition();
        idleCameraMovement();
    }

    void changeCameraPosition()
    {
        focalPoint = _selectCountries.middleVector;
        endPosition = focalPoint * cameraDistanceMultiplier;
        //camera rotation ayarlanacak. Muhtemelen Zelda OOT'den beri kullanýlan Z-Target mekaniði araþtýrýlýp entegre edilecek.


        //Offseti de conditional yapacaðým. Prototipleme için bu
        if (transform.position != endPosition && !positionSet)
        {
            float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
            transform.position = Vector3.Lerp(transform.position, endPosition, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
            elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        }

        if(transform.position == endPosition)
            positionSet = true;
    }


    void idleCameraMovement()
    {

    }
}

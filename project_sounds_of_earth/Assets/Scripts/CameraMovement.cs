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
    Vector3 earthOrigin = new Vector3(0, 0, 0);
    float cameraDistanceMultiplier = 3;
     selectCountries _selectCountries;

    public float rotSpeed = 3;
    private float minimum = 0.1f;
    private float maximum = 0.5f;
    private float yPos;
    private float bounceSpeed = 3;
    bool randomIdleNumbersSet = false;

    float randAmpX = 1;
    float randAmpY = 1;
    float randAmpZ = 1;
    float randPhasorX = 0;
    float randPhasorY = 0;
    float randPhasorZ = 0;

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


        // changeCameraPositionforTheNextQuestions();//þu an Lateupdate'de ama normalde soru geçme kondisyon karþýlanýnca aktive olacak
        SetRandomValuesforIdleCameraMovement();
        idleCameraMovement(randAmpX, randAmpY, randAmpZ, randPhasorX, randPhasorY, randPhasorZ);
    }

    void changeCameraPositionforTheNextQuestions()
    {
        
        if (transform.position != endPosition)
        {
            focalPoint = _selectCountries.middleVector;
            endPosition = focalPoint * cameraDistanceMultiplier;//camera disctance multiplier "countryFinder" collider'ýnýn büyüklüðüne göre kondisyon alacak. 
            transform.LookAt(focalPoint);
            float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
            transform.position = Vector3.Lerp(transform.position, endPosition, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
            elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        }

    }


    void idleCameraMovement(float ampX, float ampY, float ampZ, float phasorX, float phasorY, float phasorZ)
    {
     

        float sinValueX= ampX* Mathf.Sin(Time.time + phasorX);

        float sinValueY= ampY* Mathf.Sin(Time.time + phasorY);

        float sinValueZ= ampZ* Mathf.Sin(Time.time + phasorZ); 

        
        focalPoint = _selectCountries.middleVector;
        endPosition = focalPoint * cameraDistanceMultiplier;
        transform.LookAt(focalPoint);
        transform.position = new Vector3(endPosition.x + sinValueX, endPosition.y + sinValueY, endPosition.z + sinValueZ);

    }

    void SetRandomValuesforIdleCameraMovement()
    {
        if (!randomIdleNumbersSet)
        {
            randAmpX = GetRandomAmpituteMultiplier();
            randAmpY = GetRandomAmpituteMultiplier();
            randAmpZ = GetRandomAmpituteMultiplier();
            randPhasorX = GetRandomPhasor();
            randPhasorY = GetRandomPhasor();
            randPhasorZ = GetRandomPhasor();
            randomIdleNumbersSet = true;
        }

    }

    float GetRandomAmpituteMultiplier()
    {
        return Random.Range(0.70f, 1.1f);
    }

    float GetRandomPhasor()
    {
        return Random.Range(0, 6.28f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 endPosition = new Vector3(0, 0, 0);
    Vector3 focalPoint = new Vector3(0, 0, 0);
    Vector3 earthFocalPoint = new Vector3(0, 6, 0);

    //oyunun baþlangýç ekranýndaki pozisyonlar için
    Vector3 startScreenInitialPos = new Vector3(80, 6, 0);

    int cameraLerpDeltaTimeMultiplier = 10000000;
    float cameraDistanceMultiplier = 4;
    selectCountries _selectCountries;
    gameManager gameManager;


    public bool randomIdleNumbersSet = false;

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
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (!gameManager._isGameActive)
        {
            startScreenGetToInitialPose();

        }

        if (gameManager._isGameActive)
        {
           
            changeCameraPositionforTheNextQuestions();//þu an Lateupdate'de ama normalde soru geçme kondisyon karþýlanýnca aktive olacak
           // SetRandomValuesforIdleCameraMovement();
           // idleCameraMovement(randAmpX, randAmpY, randAmpZ, randPhasorX, randPhasorY, randPhasorZ);

        }

    }

    void startScreenGetToInitialPose()
    {
        if (transform.position != startScreenInitialPos)
        {
            transform.position = Vector3.Lerp(transform.position, startScreenInitialPos, Time.deltaTime);
            transform.LookAt(earthFocalPoint);
           // SmoothLookAt(earthFocalPoint);
        }

    }



    void changeCameraPositionforTheNextQuestions()
    {

        calculateCameraDistanceMultiplier();
        focalPoint = _selectCountries.middleVector;
        endPosition = focalPoint * cameraDistanceMultiplier;
        SmoothLookAt(-1 * focalPoint);
        //Debug.Log("Camera Distance Multiplier: " + cameraDistanceMultiplier);

        if (transform.position != endPosition)
        {
           
            //transform.LookAt(focalPoint);
            transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime );
        }
        // transform.LookAt(focalPoint);   
      
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
            //randomAmp'leri 125 ile çarpýnca çok güzel bi dönüþ animasyonu oluþuyor.
            Debug.Log("X amp:" + randAmpX + " Y amp: " + randAmpY + " Z amp: " + randAmpZ);
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

    void calculateCameraDistanceMultiplier()
    {
        if (_selectCountries.magnitudeOfcombinationVector > 78)
        {
            cameraDistanceMultiplier = 2;
        } else if (_selectCountries.magnitudeOfcombinationVector <=78 && _selectCountries.magnitudeOfcombinationVector >= 68)
        { //78'le 68 arasýný 2 ve 4 arasý bir sayýya eþleyen denklem
            cameraDistanceMultiplier = 15.5f * (68/_selectCountries.magnitudeOfcombinationVector) - 11.5f ; 
        } 
        else
        {
            cameraDistanceMultiplier = 4;
        }
        
    }

    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection),  Time.deltaTime );
    }
}

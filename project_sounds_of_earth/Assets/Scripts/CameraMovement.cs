using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 endPosition = new Vector3(0, 0, 0);
    Vector3 focalPoint = new Vector3(0, 0, 0);
    Vector3 earthFocalPoint = new Vector3(0, 6, 0);

    //oyunun ba?lang?? ekran?ndaki pozisyonlar i?in
    Vector3 startScreenInitialPos = new Vector3(80, 6, 0);

    float cameraDistanceMultiplier = 4;
    float cameraSpeed = 1;
    float CameraShakeSpeed = 1000;
    selectCountries _selectCountries;
    gameManager gameManager;
     
    public bool setToQuestionPosition = false;
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
        float h = Display.main.systemHeight;
        float w = Display.main.systemWidth;
        float w_h = w/h;
        if (w_h >= 0.56f)
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
        else if (w_h <= 0.43f)
            this.gameObject.GetComponent<Camera>().fieldOfView = 70;
        else
            this.gameObject.GetComponent<Camera>().fieldOfView = (float)(-74.62f*(w/h) + 101.9);
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (!gameManager._isGameActive)
        {
            startScreenGetToInitialPose();

        }

        if (gameManager._isGameActive && !setToQuestionPosition)
        {

            changeCameraPositionforTheNextQuestions();//?u an Lateupdate'de ama normalde soru ge?me kondisyon kar??lan?nca aktive olacak



        }
        else if (gameManager._isGameActive && setToQuestionPosition)
        {
            SetRandomValuesforIdleCameraMovement();
            idleCameraMovement(randAmpX, randAmpY, randAmpZ, randPhasorX, randPhasorY, randPhasorZ);

        }


    }

    void startScreenGetToInitialPose()
    {
        if (transform.position != startScreenInitialPos)
        {
            transform.position = Vector3.Lerp(transform.position, startScreenInitialPos, cameraSpeed * Time.deltaTime);
            transform.LookAt(earthFocalPoint);
            // SmoothLookAt(earthFocalPoint);
        }

    }


    void q(object s) { }
    void changeCameraPositionforTheNextQuestions()
    {

        calculateCameraDistanceMultiplier();
        focalPoint = _selectCountries.middleVector;
        endPosition = focalPoint * cameraDistanceMultiplier;
        SmoothLookAt(-1 * focalPoint);
        //q("Camera Distance Multiplier: " + cameraDistanceMultiplier);

        if (transform.position != endPosition && !setToQuestionPosition)
        {

            //transform.LookAt(focalPoint);
            transform.position = Vector3.Lerp(transform.position, endPosition, cameraSpeed * Time.deltaTime);
            q(setToQuestionPosition);
        }
        if (Vector3.Distance(transform.position, endPosition) < 0.25f)
        {
            setToQuestionPosition = true;
            q(setToQuestionPosition);
        }
        // transform.LookAt(focalPoint);   

    }



    void idleCameraMovement(float ampX, float ampY, float ampZ, float phasorX, float phasorY, float phasorZ)
    {
        focalPoint = _selectCountries.middleVector;
        // endPosition = focalPoint * cameraDistanceMultiplier;
        transform.LookAt(focalPoint);

        float sinValueX = ampX * Mathf.Sin(Time.time + phasorX);

        float sinValueY = ampY * Mathf.Sin(Time.time + phasorY);

        float sinValueZ = ampZ * Mathf.Sin(Time.time + phasorZ);

        Vector3 velocity = Vector3.zero;
        //movetowards yerine smooth damp ekleyece?im.
        Vector3 followPosition = new Vector3(endPosition.x + sinValueX, endPosition.y + sinValueY, endPosition.z + sinValueZ);
        transform.position = Vector3.Lerp(transform.position, followPosition, (cameraSpeed * Time.deltaTime));

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
            //randomAmp'leri 125 ile ?arp?nca ?ok g?zel bi d?n?? animasyonu olu?uyor.
            q("X amp:" + randAmpX + " Y amp: " + randAmpY + " Z amp: " + randAmpZ);
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


    //16.9 ekranlar i?in uygun. 20.9 ekranlar i?in farkl? bir versiyon yaz?lacak. 
    void calculateCameraDistanceMultiplier()
    {
        if (_selectCountries.magnitudeOfcombinationVector > 78)
        {
            cameraDistanceMultiplier = 2;
        }
        else if (_selectCountries.magnitudeOfcombinationVector <= 78 && _selectCountries.magnitudeOfcombinationVector >= 68)
        { //78'le 68 aras?n? 2 ve 4 aras? bir say?ya e?leyen denklem
            cameraDistanceMultiplier = 15.5f * (68 / _selectCountries.magnitudeOfcombinationVector) - 11.5f;
        }
        else
        {
            cameraDistanceMultiplier = 4;
        }

    }

    public void rightAnswerCameraMovement()
    { //idleCamera'y? repurpose ederek bunu yapmak m?mk?n. randomize efekt almak i?in 150'lerin baz?lar? - yap?labilir, 2.1, 4.2, 0 phasorleri yer de?i?tirilebilir.
      //do?ru ??k se?ildikten sonraya entegre edilecek.
        idleCameraMovement(150, 150, 150, 2.1f, 4.2f, 0);
    }

    public void wrongAnswerCameraMovement()
    { //yanl?? cevap yapt?ktan sorna bu tarz bi titre?im verilebilir.
        float AngleAmount = (Mathf.Cos(Time.time * CameraShakeSpeed) * 180) / Mathf.PI * 0.5f;
        AngleAmount = Mathf.Clamp(AngleAmount, -15, 15);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + AngleAmount), 1f);
    }

    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), cameraSpeed * Time.deltaTime);
    }
}

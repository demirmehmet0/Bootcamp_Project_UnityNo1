using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System.IO;
using System;

public class uiHandler : MonoBehaviour
{
    gameManager gameManager;
    selectCountries _selectCountries;
    CameraMovement cameraMovement;
    countryFinder countryFinder;

    public GameObject StartScreen;
    public GameObject playModeUi;
    [SerializeField] GameObject SFX;
    [SerializeField] GameObject ScoreScreenUI;
    [SerializeField] GameObject CreditsPopup;
    [SerializeField] GameObject OptionsPopup;
    [SerializeField] public GameObject WrongAnswerPopup;
    [SerializeField] GameObject useYourHeadphones;
    [SerializeField] TMP_Text useYourheadphonesCounter;
    float startscreenTimer = 5;
    float wrongTimer = 5;
    private void Awake()
    {
        StartCoroutine(timerforCloseHeadphonesNotice());
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        wrongTimer -= Time.deltaTime;
        if (wrongTimer < 0 && WrongAnswerPopup.activeInHierarchy)
        { closeWrongWindow(); gameManager.goToNextQuestion(); }
        if (useYourHeadphones.activeSelf == true)
        {
            startscreenTimer -= Time.deltaTime;
            useYourheadphonesCounter.text = "" + Mathf.Ceil(startscreenTimer);
        }

        if (gameManager._isGameActive)
        {

        }

    }

    public void AnswerButton_Click(Button button)
    {
        StartCoroutine(SFXPlay("clickswoosh"));
        if (button.GetComponentInChildren<TMP_Text>().text == gameManager.rightAnswer)
        {
            q("Do?ru cevap");
            StartCoroutine(SFXPlay("correct-answer"));
            gameManager.increasePlayerScore(gameManager.questionTimerRemainder); //kalan zaman filan eklenecek.
            gameManager.increaseOrResetChain(true);
            gameManager.calculateScoreMultiplier();
            // gameManager.nextQuestionButton.gameObject.SetActive(true); 
            Array.Clear(gameManager.questionResult, 0, gameManager.questionResult.Length);
            gameManager.goToNextQuestion();
        }
        else
        {
            showWorngWindow();
            TMP_Text[] texts = WrongAnswerPopup.GetComponentsInChildren<TMP_Text>();
            foreach (TMP_Text text in texts)
            {
                if (text.name == "Answer")
                {
                    text.text = gameManager.rightAnswerEng + "\n" + gameManager.rightAnswer;
                }
            }
            q("Yanl?? Cevap!");

        }
        //burada yanl?? cevap, do?ru cevap animasyonlar? devreye girecek. Askphase a??ld?ktan sonra biraz couroutine ile s?re tan?nabilir ??nk? oyun donma yap?yor.
        //Bu da mp3 indirme s?reci ile ilgili olsa gere. Genel oalrak d?zeltilecek. 
        //cevaba t?kland???nda da 10 soruyu ge?mi?se skor ekran?na atmal?



    }
    public void showOptionsWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        OptionsPopup.SetActive(true);
        gameManager.GetComponent<AudioSource>().Stop();
    }
    public void showWorngWindow()
    {
        StartCoroutine(SFXPlay("wrong-answer"));
        wrongTimer = 5;
        WrongAnswerPopup.SetActive(true);
    }

    public void closeOptionsWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        OptionsPopup.SetActive(false);
    }

    public void closeWrongWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        gameManager.questionTimerRemainder = 20;
        gameManager.increasePlayerScore(0);
        gameManager.increaseOrResetChain(false);
        gameManager.calculateScoreMultiplier();
        WrongAnswerPopup.SetActive(false);
        gameManager.goToNextQuestion();
    }

    public void showCreditsWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        CreditsPopup.SetActive(true);
    }

    public void closeCreditsWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        CreditsPopup.SetActive(false);
    }

    public void closeUseYourHeadphonesNotice()
    {
        useYourHeadphones.SetActive(false);
    }

    IEnumerator timerforCloseHeadphonesNotice()
    {
        yield return new WaitForSeconds(5f);
        closeUseYourHeadphonesNotice();
    }

    public void StartTheGame()
    {
        GameObject music = GameObject.Find("Music");
        music.GetComponent<AudioSource>().clip = music.GetComponent<SFXController>().audios[0];
        music.GetComponent<AudioSource>().Play();
        StartCoroutine(SFXPlay("clicksnap"));
        print("TESTq");
        gameManager.GetComponent<AudioSource>().volume = 1;
        gameManager.ResetAlltoInitialCondition();
        gameManager._isGameActive = true;
        gameManager.askPhase = true;
        _selectCountries.inSelectionPhase = true;
        StartScreen.SetActive(false);
        playModeUi.SetActive(true);
    }

    public void ExitPlayMode()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        gameManager.GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<AudioSource>().volume = 0;
        gameManager.ResetAlltoInitialCondition();
        _selectCountries.disableMeshAndScriptForSelected();
        gameManager._isGameActive = false;
        StartScreen.SetActive(true);
        playModeUi.SetActive(false);
        ScoreScreenUI.SetActive(false);
        gameManager.ResetAlltoInitialCondition();

    }

    public void sliderChanged(Slider slider)
    {
        if (slider.name == "SFXSlider")
        {
            GameObject.Find("SFX").GetComponent<AudioSource>().volume=slider.value;
            GameObject.Find("GameManager").GetComponent<AudioSource>().volume = slider.value;
        }
        else if (slider.name == "MusicSlider")
        {
            GameObject.Find("Music").GetComponent<AudioSource>().volume = slider.value;
        }
    }

    public void NextQuestion()
    {
        _selectCountries.disableMeshAndScriptForSelected();
        cameraMovement.randomIdleNumbersSet = false; //random idle numbler'? unutmu?tum, next question ?eyine cevap vererek girince de eklenmeli.
        cameraMovement.setToQuestionPosition = false;
        _selectCountries.inSelectionPhase = true;


    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    /*
    void SFXMenuButton()
    {
        AudioClip[] clips = SFX.GetComponent<SFXController>().audios;
        foreach(AudioClip clip in clips)
            if (clip.name.Contains("clicksnap")) { SFX.GetComponent<AudioSource>().PlayOneShot(clip); }
    }
    void SFXAnswerButton()
    {
        AudioClip[] clips = SFX.GetComponent<SFXController>().audios;
        foreach (AudioClip clip in clips)
            if (clip.name.Contains("clickswoosh")) { SFX.GetComponent<AudioSource>().PlayOneShot(clip); }
    }
    void SFXWrongAnswer()
    {
        AudioClip[] clips = SFX.GetComponent<SFXController>().audios;
        foreach (AudioClip clip in clips)
            if (clip.name.Contains("wrong-answer")) { SFX.GetComponent<AudioSource>().PlayOneShot(clip); }
    }
    void SFXCorrextAnswer()
    {
        AudioClip[] clips = SFX.GetComponent<SFXController>().audios;
        foreach (AudioClip clip in clips)
            if (clip.name.Contains("wrong-answer")) { SFX.GetComponent<AudioSource>().PlayOneShot(clip); }
    }
    */
    IEnumerator SFXPlay(string clipName)
    {
        yield return null;
        AudioClip[] clips = SFX.GetComponent<SFXController>().audios;
        foreach (AudioClip clip in clips)
            if (clip.name.Contains(clipName))
            {
                SFX.GetComponent<AudioSource>().PlayOneShot(clip);
            }
    }
    void q(string s) { }
}


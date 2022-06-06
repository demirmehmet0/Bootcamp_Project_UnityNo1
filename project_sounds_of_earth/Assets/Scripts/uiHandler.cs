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
    [SerializeField] public GameObject AnswerPopup;
    [SerializeField] GameObject useYourHeadphones;
    [SerializeField] TMP_Text useYourheadphonesCounter;
    float startscreenTimer = 5;
    float wrongTimer = 5;

    public static float sfx = 0, music = 0, speech = 0;
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

    void Update()
    {
        wrongTimer -= Time.deltaTime;
        if (wrongTimer < 0 && AnswerPopup.activeInHierarchy)
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

    public static void ChangeButtonStatus(bool status)
    {
        try
        {
            Button[] buttons = new Button[] { GameObject.Find("answerButton1").GetComponent<Button>(), GameObject.Find("answerButton2").GetComponent<Button>(), GameObject.Find("answerButton3").GetComponent<Button>(), GameObject.Find("answerButton4").GetComponent<Button>() };
            foreach (Button btn in buttons)
                btn.enabled = status;
        }
        catch { }

    }

    public void AnswerButton_Click(Button button)
    {
        ChangeButtonStatus(false);
        StartCoroutine(SFXPlay("clickswoosh"));
        if (button.GetComponentInChildren<TMP_Text>().text == gameManager.rightAnswer)
        {
            var colors = button.colors;
            colors.normalColor = Color.green;
            button.colors = colors;
            showRightAnswerWindow();
            Text[] texts = AnswerPopup.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Answer")
                {
                    text.text = gameManager.rightAnswerEng.Replace("NULL","") + "\n" + gameManager.rightAnswer;
                }
            }
            q("Do?ru cevap");
        }
        else
        {
            showWorngWindow();
            Text[] texts = AnswerPopup.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Answer")
                {
                    text.text = gameManager.rightAnswerEng.Replace("NULL", "") + "\n" + gameManager.rightAnswer;
                }
            }
            q("Yanl?? Cevap!");
            var colors = button.colors;
            colors.normalColor = Color.red;
            button.colors = colors;
        }

    }
    public void showOptionsWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        OptionsPopup.SetActive(true);
        Debug.Log(sfx);
        Debug.Log(speech);
        Debug.Log(music);

        GameObject.Find("SFXSlider").GetComponent<Slider>().value = sfx;
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = music;
        GameObject.Find("SpeechSlider").GetComponent<Slider>().value = speech;
        gameManager.GetComponent<AudioSource>().Stop();
    }
    public void showWorngWindow()
    {
        StartCoroutine(SFXPlay("wrong-answer"));
        wrongTimer = 5;
        AnswerPopup.SetActive(true);
    }

    public void showRightAnswerWindow()
    {
        StartCoroutine(SFXPlay("correct-answer"));
        wrongTimer = 5;
        AnswerPopup.SetActive(true);
    }

    public void closeRightAnswerWindow()
    {
        StartCoroutine(SFXPlay("clickswoosh"));
        gameManager.increasePlayerScore(gameManager.questionTimerRemainder);
        gameManager.increaseOrResetChain(true);
        gameManager.calculateScoreMultiplier();
        Array.Clear(gameManager.questionResult, 0, gameManager.questionResult.Length);
        gameManager.goToNextQuestion();
    }

    public void closeOptionsWindow()
    {
        StartCoroutine(SFXPlay("clicksnap"));
        OptionsPopup.SetActive(false);
    }

    public void closeWrongWindow()
    {
        StartCoroutine(SFXPlay("clickswoosh"));
        gameManager.questionTimerRemainder = 20;
        gameManager.increasePlayerScore(0);
        gameManager.increaseOrResetChain(false);
        gameManager.calculateScoreMultiplier();
        AnswerPopup.SetActive(false);
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
        Array.Clear(gameManager.questionResult, 0, gameManager.questionResult.Length);
        StartCoroutine(SFXPlay("clicksnap"));
        GameObject music = GameObject.Find("Music");
        music.GetComponent<AudioSource>().Stop();
        music.GetComponent<AudioSource>().clip = music.GetComponent<SFXController>().audios[1];
        music.GetComponent<AudioSource>().Play();
        gameManager.GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<AudioSource>().clip = null;
        gameManager.GetComponent<AudioSource>().volume = 0; 
        gameManager.questionTimerRemainder = 20;
        gameManager.increasePlayerScore(0);
        gameManager.increaseOrResetChain(false);
        gameManager.calculateScoreMultiplier();
        gameManager.goToNextQuestion();
        AnswerPopup.SetActive(false);
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
            GameObject.Find("SFX").GetComponent<AudioSource>().volume = slider.value;
            uiHandler.sfx = GameObject.Find("SFXSlider").GetComponent<Slider>().value;
        }
        else if (slider.name == "MusicSlider")
        {
            GameObject.Find("Music").GetComponent<AudioSource>().volume = slider.value;
            uiHandler.music = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
        }
        else if (slider.name == "SpeechSlider")
        {
            GameObject.Find("GameManager").GetComponent<AudioSource>().volume = slider.value;
            uiHandler.speech = GameObject.Find("SpeechSlider").GetComponent<Slider>().value;
        }
        gameManager.SaveSettings(speech, music, sfx);
    }

    public void NextQuestion()
    {
        _selectCountries.disableMeshAndScriptForSelected();
        cameraMovement.randomIdleNumbersSet = false;
        cameraMovement.setToQuestionPosition = false;
        _selectCountries.inSelectionPhase = true;
    }

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


    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void q(string s) { }
}
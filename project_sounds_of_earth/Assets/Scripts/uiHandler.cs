using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System.IO;

public class uiHandler : MonoBehaviour
{
    gameManager gameManager;
    selectCountries _selectCountries;
    CameraMovement cameraMovement;
    countryFinder countryFinder;

    public GameObject StartScreen;
    public GameObject playModeUi;
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
        if (button.GetComponentInChildren<TMP_Text>().text == gameManager.rightAnswer)
        {
            Debug.Log("Do?ru cevap");

            gameManager.increasePlayerScore(gameManager.questionTimerRemainder); //kalan zaman filan eklenecek.
            gameManager.increaseOrResetChain(true);
            gameManager.calculateScoreMultiplier();
            // gameManager.nextQuestionButton.gameObject.SetActive(true); 
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
            Debug.Log("Yanl?? Cevap!");

        }
        //burada yanl?? cevap, do?ru cevap animasyonlar? devreye girecek. Askphase a??ld?ktan sonra biraz couroutine ile s?re tan?nabilir ??nk? oyun donma yap?yor.
        //Bu da mp3 indirme s?reci ile ilgili olsa gere. Genel oalrak d?zeltilecek. 
        //cevaba t?kland???nda da 10 soruyu ge?mi?se skor ekran?na atmal?



    }
    public void showOptionsWindow()
    {
        OptionsPopup.SetActive(true);
        gameManager.GetComponent<AudioSource>().Stop();
    }
    public void showWorngWindow()
    {
        wrongTimer = 5;
        WrongAnswerPopup.SetActive(true);
    }

    public void closeOptionsWindow()
    {
        OptionsPopup.SetActive(false);
    }

    public void closeWrongWindow()
    {
        gameManager.questionTimerRemainder = 20;
        gameManager.increasePlayerScore(0);
        gameManager.increaseOrResetChain(false);
        gameManager.calculateScoreMultiplier();
        WrongAnswerPopup.SetActive(false);
        gameManager.goToNextQuestion();
    }

    public void showCreditsWindow()
    {
        CreditsPopup.SetActive(true);
    }

    public void closeCreditsWindow()
    {
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
        gameManager.GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<AudioSource>().volume=0;
        gameManager.ResetAlltoInitialCondition();
        _selectCountries.disableMeshAndScriptForSelected();
        gameManager._isGameActive = false;
        StartScreen.SetActive(true);
        playModeUi.SetActive(false);
        ScoreScreenUI.SetActive(false);
        gameManager.ResetAlltoInitialCondition();

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

}


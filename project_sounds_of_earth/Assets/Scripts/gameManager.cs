using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System;

public class gameManager : MonoBehaviour
{
    //FIELDS - OZGEN 

    public bool _isGameActive = false;
    public bool inAnswerPhase = false; 
    public float playerScore = 0;
    public float questionTimerRemainder = 10;
    int RightAnswerChain = 0;
    int questionCounter = 1;
    public int QuestionAudioPlayCounter = 0;
    float scoreMultiplier = 1;
    CameraMovement cameraMovement;
    selectCountries _selectCountries;



    public TMP_Text countdownText;
    [SerializeField] TMP_Text questionNumberDisplay;
    [SerializeField] TMP_Text ingameScoreDisplayText;
    [SerializeField] TMP_Text ingameMultiplierText;
    [SerializeField] TMP_Text ingameTimerDisplay;
    public AudioClip audioclipDeneme;
    private AudioSource gameAudioSource;

    //API FUELDS 
    const string Host = "https://soundsofearth.space/";
    const string API = Host + "web/api/";

    //BUTTONS -ANSWERS etc
    public TMP_Text questionText;
   // public Button[] buttonAnswers;
    public string rightAnswer = "";
    public string[] questionResult;
    bool gettingQuestionFromAPI = false;
    public bool askPhase = true;
    public bool gotAnswerFromApi = false;

    public string[] CountriesWLanguages =
   {
        //Google text to speech desteklemeyen ama oyunda bulunan ülkeler
        "??;Afghanistan\nPashto",
        "??;Albania\nAlbanian",
        "??;Armenia\nArmenian",
        "??;Azerbaijan\nAzerbaijani",
        "??;Belarus\nBelarusian",
        "??;Bhutan\nDzongkha",
        "??;Bosnia and Herzegovina\nBosnian",
        "??;Cambodia\nKhmer",
        "??;Central African Republic\nSango",
        "??;Croatia\nCroatian",
        "??;Eritrea\nTigrinya",
        "??;Estonia\nEstonian",
        "??;Ethiopia\nAmharic",
        "??;Georgia\nGeorgian",
        "??;Holy See\nLatin",
        "??;Iran\nPersian",
        "??;Isle of Man\nManx",
        "??;Israel\nHebrew",
        "??;Kazakhstan\nKazakh",
        "??;Kenya\nSwahili",
        "??;Laos\nLao",
        "??;Lithuania\nLithuanian",
        "??;Macedonia\nMacedonian",
        "??;Madagascar\nMalagasy",
        "??;Maldives\nDhivehi",
        "??;Malta\nMaltese",
        "??;Mongolia\nMongolian",
        "??;Montenegro\nMontenegrin",
        "??;Myanmar\nBurmese",
        "??;Nepal\nNepali",
        "??;New Zealand\nM?ori",
        "??;Pakistan\nUrdu",
        "??;Slovenia\nSlovene",
        "??;Somalia\nSomali",
        "??;Swaziland\nSwazi",
        "??;Tajikistan\nTajik",
        "??;Uzbekistan\nUzbek",
        //API'de bulunan Dil kodlarý
        "ca-ES;Andorra\nCatalan",
        "en-AU;Australia\nAustralian English",
        "bn-IN;Bangladesh\nBengali",
        "pt-BR;Brazil\nBrazilian Portuguese",
        "bg-BG;Bulgaria\nBulgarian",
        "fr-CA;Canada\nCanadian French",
        "cmn-CN;China\nMandarin Chinese",
        "cs-CZ;Czechia\nCzech",
        "da-DK;Denmark\nDanish",
        "fi-FI;Finland\nFinnish",
        "fr-FR;France\nFrench",
        "de-DE;Germany\nGerman",
        "el-GR;Greece\nGreek",
        "hu-HU;Hungary\nHungarian",
        "is-IS;Iceland\nIcelandic",
        "hi-IN;India\nHindi",
        "id-ID;Indonesia\nIndonesian",
        "it-IT;Italy\nItalian",
        "ja-JP;Japan\nJapanese",
        "ko-KR;South Korea\nKorean",
        "lv-LV;Latvia\nLatvian",
        "ms-MY;Malaysia\nMalay",
        "es-US;Mexico\nMexican Spanish",
        "nl-NL;Netherlands\nDutch",
        "nb-NO;Norway\nNorwegian",
        "fil-PH;Philippines\nFilipino",
        "pl-PL;Poland\nPolish",
        "pt-PT;Portugal\nPortuguese",
        "ro-RO;Romania\nRomanian",
        "ru-RU;Russian Federation\nRussian",
        "ar-XA;Saudi Arabia\nArabic",
        "sr-RS;Serbia\nSerbian",
        "sk-SK;Slovakia\nSlovak",
        "af-ZA;South Africa\nAfrikaans",
        "es-ES;Spain\nSpanish",
        "sv-SE;Sweden\nSwedish",
        "th-TH;Thailand\nThai",
        "tr-TR;Turkey\nTurkish",
        "uk-UA;Ukraine\nUkrainian",
        "en-GB;United Kingdom\nBritish English",
        "en-US;United States of America\nAmerican English",
        "vi-VN;Vietnam\nViatnamese",
    };
    private void Awake()
    {
        gameAudioSource = GetComponent<AudioSource>();
        
    }
    private void Start()
    {
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
        CheckNetworkReachablility();
        // gameAudioSource.PlayOneShot(audioclipDeneme, 5f);
       // GetComponent<AudioSource>().PlayOneShot(audioclipDeneme, 5f);
    }


    private void Update()
    {
       if(_isGameActive && inAnswerPhase)
        {
           
        }

        if (_isGameActive  && askPhase)//isStarted eklenmeli? //cameraMovement.setToQuestionPosition bu and operatordan çýkartýldý.
        {
            
            if (!gettingQuestionFromAPI) StartCoroutine(CoroutineUpdate());
        }

        //CountdownBeforeQuestion();
        playAudioClip();
        timerCalculationsAndDisplay();

    }

    void timerCalculationsAndDisplay()
    {
        if(questionTimerRemainder >= 0)
        {
            questionTimerRemainder -= Time.deltaTime;
            ingameTimerDisplay.text = "Time: " + questionTimerRemainder;
        }
        else
        {
            increasePlayerScore(0);
            increaseOrResetChain(false);
            calculateScoreMultiplier();
            goToNextQuestion();
        }
    }

    public void increaseOrResetChain(bool answer)
    {
        if (answer)
            RightAnswerChain++;
        else
            RightAnswerChain = 0;
    }

    public void increasePlayerScore(float remainingSeconds)
    {
        playerScore += remainingSeconds * scoreMultiplier;
        ingameScoreDisplayText.text = "Score: " + playerScore;
    }

    public void calculateScoreMultiplier()
    {
        scoreMultiplier = Mathf.Pow(1.5f, RightAnswerChain);
        ingameMultiplierText.text = "Chain: " + RightAnswerChain + " - Multiplier: " + scoreMultiplier + "x";
    }

    public void ResetAlltoInitialCondition()
    {
       RightAnswerChain = 0;
       scoreMultiplier = 1;
       playerScore = 0;
       questionCounter = 1;
    }

    void CheckNetworkReachablility()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            //Error fonksiyonu eklenmeli, ekrana bir textbox atýlmalý.
        }
        else
        {   
           // Debug.Log("Internet connection: No error!");
        }
    }

    public void goToNextQuestion()
    {
      
        if (questionCounter < 10)
        {
            questionCounter++;
            questionNumberDisplay.text = "Q." + questionCounter;

            QuestionAudioPlayCounter = 4;
            gotAnswerFromApi = false;
            askPhase = true;
            _selectCountries.disableMeshAndScriptForSelected();
            _selectCountries.changeSelectedCountryName();
            _selectCountries.SetCountryFinderLocation();
            _selectCountries.inSelectionPhase = true;


            questionTimerRemainder = 10;
            _selectCountries.buttonAnswersReset();
            cameraMovement.setToQuestionPosition = false;

        }
      
    }

    //QUestion text scriptine çekilecek. zamanlamasý ayarlanacak. 
    void CountdownBeforeQuestion()
    {
        countdownText.text = "Get Ready!";
        if (cameraMovement.setToQuestionPosition)
        {
            countdownText.text = "3 2 1 !";
        }
           
    }


    //KADIR KOD

    private void LoadQuestion()
    {
       // questionText.text = "Bu dil hangi ülkenin?";
        Debug.ClearDeveloperConsole();
        // Button[] _Answers = buttonAnswers;
        // int randomButtonIndex = UnityEngine.Random.Range(0, 4);
        // Button selectedButton = buttonAnswers[randomButtonIndex];//Doðru cevap  
        //_Answers[randomButtonIndex] = null;
        Debug.Log(questionResult[0] + "=>" + questionResult[1] + "=>" + questionResult[2] + "=>" + questionResult[3]);
        string res = Array.Find(CountriesWLanguages, ele => ele.Contains(questionResult[2]));
        Debug.Log(questionResult[0] + "=>" + questionResult[1] + "=>" + questionResult[2] + "=>" + questionResult[3]);
        rightAnswer = res.Split(';')[1];
        Debug.Log(questionResult[0] + "=>" + questionResult[1] + "=>" + questionResult[2] + "=>" + questionResult[3]);
        gotAnswerFromApi = true;

        /*
        List<string> _CountriesWLanguages = new List<string>();
        _CountriesWLanguages.Add(res.Split(';')[1]);


        for (int i = 0; i < 4; i++)
        {
            if (_Answers[i] != null)
            {
            getNewCountry: int randomCountryIndex = UnityEngine.Random.Range(0, CountriesWLanguages.Length);
                if (_CountriesWLanguages.Contains(CountriesWLanguages[randomCountryIndex].Split(';')[1]))
                {
                    goto getNewCountry;
                }
                else
                {
                    buttonAnswers[i].GetComponentInChildren<TMP_Text>().text = CountriesWLanguages[randomCountryIndex].Split(';')[1];
                    _CountriesWLanguages.Add(CountriesWLanguages[randomCountryIndex].Split(';')[1]);
                }
            }
        }
        
        buttonAnswers[randomButtonIndex] = selectedButton;
        */

        askPhase = false; gettingQuestionFromAPI = false;
    }
    void playAudioClip()
    {
        if (GetComponent<AudioSource>().clip != null && !GetComponent<AudioSource>().isPlaying && QuestionAudioPlayCounter<4)
        {
            
            if(QuestionAudioPlayCounter %2 == 0)
            {
                gameAudioSource.pitch = 1;
                GetComponent<AudioSource>().Play(50000);   
            } else
            {
                gameAudioSource.pitch = 0.8f;
                GetComponent<AudioSource>().Play(50000);
            }
            QuestionAudioPlayCounter++;
            Debug.Log("played");
        }
    }

    IEnumerator DownloadAndPlay(string url)
    {
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;
        while (!www.isDone) { if (!string.IsNullOrEmpty(www.error)) { Debug.Log("DownloadPlayError"); break; } }
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = www.GetAudioClip(false, false); 
        QuestionAudioPlayCounter = 0;
        //  audio.Play();

    }

    IEnumerator CoroutineUpdate()
    {
        gettingQuestionFromAPI = true;
        yield return StartCoroutine(API_GetQuestion());
    }

    IEnumerator API_GetQuestion()//string entryId = result[0]; string text = result[1]; string country = result[2]; string textonly = result[3]
    {
        gettingQuestionFromAPI = true;
        UnityWebRequest www = UnityWebRequest.Get(API + "random");
        yield return www.Send();
        while (!www.isDone) { if (!www.isHttpError || !www.isNetworkError) { Debug.Log("GetQuestionError"); break; } }
        if (!www.isHttpError || !www.isNetworkError)
        {
            string[] result = www.downloadHandler.text.Split(';');
            questionResult = result;
            StartCoroutine(DownloadAndPlay(Host + questionResult[1]));
            while (GetComponent<AudioSource>().isPlaying) { if (false/*Hata sorgusu*/) { Debug.Log("GetQuestionError"); break; } }
            if (!www.isHttpError || !www.isNetworkError) LoadQuestion(); else { Debug.Log("Hata"); }
        }
        else { Debug.Log("GetQuestionError"); }
    }
}

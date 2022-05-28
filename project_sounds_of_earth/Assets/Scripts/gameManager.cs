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
    float questionTimerRemainder = 10;
    int RightAnswerChain = 0;
    float scoreMultiplier = 1;
    CameraMovement cameraMovement; 

    //API FUELDS 
    const string Host = "https://soundsofearth.space/";
    const string API = Host + "web/api/";

    //BUTTONS -ANSWERS etc
    public TMP_Text questionText;
    public Button[] buttonAnswers;
    public string rightAnswer = "";
    string[] questionResult;
    bool gettingQuestionFromAPI = false;
    bool askPhase = true;

    string[] CountriesWLanguages =
   {
        "af-ZA;South Africa",
        "ar-XA;United Arab Emirates",
        "bg-BG;Bulgaria",
        "bn-IN;India",
        "ca-ES;Spain",
        "cmn-CN;China",
        "cmn-TW;China",
        "cs-CZ;Czech Republic",
        "da-DK;Denmark",
        "de-DE;Germany",
        "el-GR;Greece",
        "en-AU;Australia",
        "en-GB;UK",
        "en-IN;India",
        "en-US;US",
        "es-ES;Spain",
        "es-US;Spain",
        "fi-FI;Finland",
        "fil-PH;Philippines",
        "fr-CA;Canada",
        "fr-FR;France",
        "gu-IN;India",
        "hi-IN;India",
        "hu-HU;Hungary",
        "id-ID;Indonesia",
        "is-IS;Iceland",
        "it-IT;Italy",
        "ja-JP;Japan",
        "kn-IN;India",
        "ko-KR;South Korea",
        "lv-LV;Latvia",
        "ml-IN;India",
        "ms-MY;Malaysia",
        "nb-NO;Norway",
        "nl-BE;Belgium",
        "nl-NL;Netherlands",
        "pa-IN;India",
        "pl-PL;Poland",
        "pt-BR;Brazil",
        "pt-PT;Portugal",
        "ro-RO;Romania",
        "ru-RU;Russia",
        "sk-SK;Slovakia",
        "sr-RS;Cyrillic",
        "sv-SE;Sweden",
        "ta-IN;India",
        "te-IN;India",
        "th-TH;Thailand",
        "tr-TR;Turkey",
        "uk-UA;Ukraine",
        "vi-VN;Vietnam",
        "yue-HK;China"
    };

    private void Start()
    {
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        CheckNetworkReachablility();
    }


    private void Update()
    {
       if(_isGameActive && inAnswerPhase)
        {
          questionTimerRemainder -= Time.deltaTime;
        }

        if (_isGameActive && cameraMovement.setToQuestionPosition && askPhase)//isStarted eklenmeli?
        {
            if (!gettingQuestionFromAPI) StartCoroutine(CoroutineUpdate());
        }


    }

    void increaseOrResetChain()
    {
        // if correct answer
        RightAnswerChain++;
        // if wrong answer or if no answer
        RightAnswerChain = 0;
    }

    void increasePlayerScore(float remainingSeconds, float scoreMultiplier)
    {
        playerScore += remainingSeconds * scoreMultiplier;
    }

    void calculateScoreMultiplier(int chain)
    {
        scoreMultiplier = Mathf.Pow(1.5f, chain);
    }

    void ResetAlltoInitialCondition()
    {
       RightAnswerChain = 0;
       scoreMultiplier = 1;
       playerScore = 0;
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
            Debug.Log("Internet connection: No error!");
        }
    }


    //KADIR KOD

    private void LoadQuestion()
    {
       // questionText.text = "Bu dil hangi ülkenin?";
        Debug.ClearDeveloperConsole();
        Button[] _Answers = buttonAnswers;
        int randomButtonIndex = UnityEngine.Random.Range(0, 4);
        Button selectedButton = buttonAnswers[randomButtonIndex];//Doðru cevap  
        _Answers[randomButtonIndex] = null;
        string res = Array.Find(CountriesWLanguages, ele => ele.Contains(questionResult[2]));
        selectedButton.GetComponentInChildren<TMP_Text>().text = res.Split(';')[1];
        rightAnswer = res.Split(';')[1];
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
        Debug.Log(questionResult[0] + "=>" + questionResult[1] + "=>" + questionResult[2] + "=>" + questionResult[3]);
        buttonAnswers[randomButtonIndex] = selectedButton;
        askPhase = false; gettingQuestionFromAPI = false;
    }

    IEnumerator DownloadAndPlay(string url)
    {
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;
        while (!www.isDone) { if (!string.IsNullOrEmpty(www.error)) { Debug.Log("DownloadPlayError"); break; } }
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = www.GetAudioClip(false, false);
        audio.Play();
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

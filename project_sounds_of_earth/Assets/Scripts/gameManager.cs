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
                //Google text to speech desteklemeyen ama bulunan ülkeler
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



        //apide zaten bulunanlar
        "ca-ES;Andorra\nCatalan",
        "en-AU;Australia\nEnglish",
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

        //bu da çýkartýlacak
        "en-IN;India\nIndian English",
        /*listeden çýkartýlmalýlar
        "cmn-TW;China",
        "yue-HK;China",
        "kn-IN;India",
        "ml-IN;India",
        "ta-IN;India",
        "pa-IN;India",
        "te-IN;India",
         "gu-IN;India",
        "nl-BE;Belgium",*/
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

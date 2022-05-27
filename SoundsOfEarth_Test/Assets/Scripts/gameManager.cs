using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System;

public class gameManager : MonoBehaviour
{
    //VARIABLES AudioSource audioSource; AudioClip myClip;


    public GameObject earthModel;
    public GameObject PlayUI;
    public TMP_Text Soru;
    public Button nextQuestionButton;
    public Button[] Answers;
    public bool startGame = false;
    public bool _isGameActive = false;
    public bool _isGameReadyToStart = true;
    public bool gettingQuestion = false;
    public bool ask; 
    public float animMultiplier = 10;
    //public float playerScore = 0;
    float questionTimer = 10;
    public string rightAnswer = "";


    string[] questionResult;
    const string API = Host + "web/api/";
    const string Host = "https://soundsofearth.space/";
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
    //VARIABLES 
    private void Start()
    {
        //int waitTimerTest = 0;
        //while (waitTimerTest < 1000) { waitTimerTest++; if (waitTimerTest == 1000) { Debug.Log("waitTimerTestError"); break; } }
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            //Error fonksiyonu eklenmeli
        }
        else
        {
            //startable olmalı
        }
    }

    private void Update()
    {
        Vector3 currentEarthPos = new Vector3(earthModel.transform.position.x, earthModel.transform.position.y, earthModel.transform.position.z);

        if (startGame && currentEarthPos.y < 22)
        {
            earthModel.transform.position = new Vector3(currentEarthPos.x, currentEarthPos.y + animMultiplier * Time.deltaTime, currentEarthPos.z);
            PlayUI.SetActive(true);
        }
        else if (startGame && currentEarthPos.y >= 22 && ask)//isStarted eklenmeli?
        {
            if (!gettingQuestion) StartCoroutine(CoroutineUpdate());
        }
    }


    //FUNCTIONS
    IEnumerator CoroutineUpdate()
    {
        gettingQuestion = true;
        yield return StartCoroutine(API_GetQuestion());
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

    private void LoadQuestion()
    {
        Soru.text = "Bu dil hangi ülkenin?";
        Debug.ClearDeveloperConsole();
        Button[] _Answers = Answers;
        int randomButtonIndex = UnityEngine.Random.Range(0, 4);
        Button selectedButton = Answers[randomButtonIndex];//Doğru cevap  
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
                    Answers[i].GetComponentInChildren<TMP_Text>().text = CountriesWLanguages[randomCountryIndex].Split(';')[1];
                    _CountriesWLanguages.Add(CountriesWLanguages[randomCountryIndex].Split(';')[1]);
                }
            }
        }
        Debug.Log(questionResult[0] + "=>" + questionResult[1] + "=>" + questionResult[2] + "=>" + questionResult[3]);
        Answers[randomButtonIndex] = selectedButton;
        ask = false; gettingQuestion = false;
    }
    IEnumerator API_GetQuestion()//string entryId = result[0]; string text = result[1]; string country = result[2]; string textonly = result[3]
    {
        gettingQuestion = true;
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

    /*void increasePlayerScore(float scoreMultiplier)
    {
        //playerScore = remainingSeconds * scoreMultiplier;
    }*/
    //FUNCTIONS
}

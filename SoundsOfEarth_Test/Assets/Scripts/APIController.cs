using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 
using UnityEngine.UI;
using TMPro;
using System; 

public class APIController : MonoBehaviour
{
    //VARIABLES
    const string API = "https://soundsofearth.space/web/api/";
    string[] questionResult;
    public bool gettingQuestion = false;
    public bool ask;
    public Button[] Answers;
    public string[] CountriesWLanguages =
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
    void Start()
    {
        Debug.Log("Starting");
    } 
    void Update()
    {
        LoadQuestion();
    }


    //FUNCTIONS
    IEnumerator CoroutineUpdate()
    {
        gettingQuestion = true;
        yield return StartCoroutine(API_GetQuestion());
    }

    private void LoadQuestion()
    {
        if (!gettingQuestion) StartCoroutine(CoroutineUpdate());
        else if (ask && gettingQuestion)
        {
            Debug.ClearDeveloperConsole();
            Button[] _Answers = Answers;
            int randomButtonIndex = UnityEngine.Random.Range(0, 4);
            Button selectedButton = Answers[randomButtonIndex];
            _Answers[randomButtonIndex] = null;
            string res = Array.Find(CountriesWLanguages, ele => ele.Contains(questionResult[2]));
            selectedButton.GetComponentInChildren<TMP_Text>().text = res.Split(';')[1];
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
    }
    IEnumerator API_GetQuestion()
    {
        gettingQuestion = true;
        UnityWebRequest www = UnityWebRequest.Get(API + "random");
        yield return www.Send(); 
        if (www.isDone)
        {
            string[] result = www.downloadHandler.text.Split(';');
            questionResult = result;
            //string entryId = result[0]; string text = result[1]; string country = result[2]; string textonly = result[3
        }
    }
    //FUNCTIONS
}

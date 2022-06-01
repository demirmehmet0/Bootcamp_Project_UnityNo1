using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class selectCountries : MonoBehaviour
{
    countryFinder _countryfinder;
    gameManager gameManager;
    public Button[] buttonAnswers;
    public bool inSelectionPhase = true;
    string selectedCountryName = null;
    string country1name = null;
    string country2name = null;
    string country3name = null;
    string[] wrongAnswerCountries = { "", "", ""};
    public float magnitudeOfcombinationVector = 0;
    private string tempCountry;
    int radiusOfEarth = 20;
    Vector3 countryVector1 = new Vector3(0, 0, 0);
    Vector3 countryVector2 = new Vector3(0, 0, 0);
    Vector3 countryVector3 = new Vector3(0, 0, 0);
    Vector3 countryVector4 = new Vector3(0, 0, 0);
    public Vector3 middleVector = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        _countryfinder = GameObject.FindGameObjectWithTag("countryFinder").GetComponent<countryFinder>();
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager._isGameActive && inSelectionPhase && gameManager.gotAnswerFromApi)
        {
           
            changeSelectedCountryName();
            //showCountryList();
            
                SetCountryFinderLocation();
            
               
            if (_countryfinder.countryList.Count > 4)
            {
                selectRemainingCountries();
                enableMeshAndScriptForSelected();
                setRemainingCountriesToButtons();
                findMiddleVector();
                inSelectionPhase = false;
            }
            
            
        }
       // showCountryList();
    }



    //bu iki fonksiyon birleþtirilip bir for döngüsü ve selected country arrayi ile 2-3 satýra kadar indirilebilir ama þimdilik böyle býraktým. 
    void enableMeshAndScriptForSelected()
    {
        transform.Find((string)selectedCountryName).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)wrongAnswerCountries[0]).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)wrongAnswerCountries[1]).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)wrongAnswerCountries[2]).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)selectedCountryName).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)wrongAnswerCountries[0]).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)wrongAnswerCountries[1]).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)wrongAnswerCountries[2]).GetComponent<countryMarkerBehaviour>().enabled = true;
    }

    public void disableMeshAndScriptForSelected()
    {
        transform.Find((string)selectedCountryName).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)wrongAnswerCountries[0]).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)wrongAnswerCountries[1]).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)wrongAnswerCountries[2]).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)selectedCountryName).GetComponent<countryMarkerBehaviour>().enabled = false;
        transform.Find((string)wrongAnswerCountries[0]).GetComponent<countryMarkerBehaviour>().enabled = false;
        transform.Find((string)wrongAnswerCountries[1]).GetComponent<countryMarkerBehaviour>().enabled = false;
        transform.Find((string)wrongAnswerCountries[2]).GetComponent<countryMarkerBehaviour>().enabled = false;
    }

    void findMiddleVector()
    {
        countryVector2 = transform.Find((string)wrongAnswerCountries[0]).GetComponent<Transform>().position;
        countryVector3 = transform.Find((string)wrongAnswerCountries[1]).GetComponent<Transform>().position;
        countryVector4 = transform.Find((string)wrongAnswerCountries[2]).GetComponent<Transform>().position;
        magnitudeOfcombinationVector = (countryVector1 + countryVector2 + countryVector3 + countryVector4).magnitude; //for camera distance calculation
        // Debug.Log("magnitude of combination vector: " + magnitudeOfcombinationVector);
        middleVector = (countryVector1 + countryVector2 + countryVector3 + countryVector4).normalized * radiusOfEarth;
        
        // Debug.Log(middleVector);
    }

    public void changeSelectedCountryName()
    {
        if (gameManager.gotAnswerFromApi)
        {
            selectedCountryName = gameManager.rightAnswer.Split('\n')[0];  // Normalde bu metod içinde baþka bir scriptten gelecek seçilmiþ ülke verisine eþlenecek;
            Debug.Log(selectedCountryName);
            countryVector1 = transform.Find((string)selectedCountryName).GetComponent<Transform>().position;
        }
    }

   

    public void SetCountryFinderLocation()
    {

        if(_countryfinder.countryList.Count <= 4)
        {
            if (UnityEngine.Random.Range(1, 3) % 2 == 0)
            {
                _countryfinder.transform.position = countryVector1 + new Vector3(UnityEngine.Random.Range(2, 5), UnityEngine.Random.Range(2, 10), UnityEngine.Random.Range(2, 5));

            }
            else
            {
                _countryfinder.transform.position = countryVector1 + new Vector3(UnityEngine.Random.Range(-5, -2), UnityEngine.Random.Range(-10, -2), UnityEngine.Random.Range(-5, -2));
            }
            // Debug.Log("CountryFinderLOc: " + _countryfinder.transform.position);
        }
    }

    public void selectRemainingCountries()
    {
       
            _countryfinder.countryList.Remove(selectedCountryName);
            ShuffleCountryList();
            wrongAnswerCountries[0]= (string)_countryfinder.countryList[0];
            wrongAnswerCountries[1]= (string)_countryfinder.countryList[1];
            wrongAnswerCountries[2]= (string)_countryfinder.countryList[2];

        //Debug.Log("Country1: " + country1name + " Country2: " + country2name + " Country3 : " + country3name);

    }

    void setRemainingCountriesToButtons()
    {
        int randomButtonIndexForRightAnswer = UnityEngine.Random.Range(0, 4);

        buttonAnswersReset();

        Debug.Log(wrongAnswerCountries[0]  + " " + wrongAnswerCountries[1] + " " + wrongAnswerCountries[2]);
        for (int i = 0; i < wrongAnswerCountries.Length; i++)
        {
            if (i != randomButtonIndexForRightAnswer && buttonAnswers[i].GetComponentInChildren<TMP_Text>().text == "")
            {
                string buttonFalseAnswer = Array.Find(gameManager.CountriesWLanguages, find => find.Contains(wrongAnswerCountries[i]));
                buttonAnswers[i].GetComponentInChildren<TMP_Text>().text = buttonFalseAnswer.Split(';')[1];

            } else {
                string buttonFalseAnswer = Array.Find(gameManager.CountriesWLanguages, eleme => eleme.Contains(wrongAnswerCountries[i]));
                buttonAnswers[i + 1].GetComponentInChildren<TMP_Text>().text = buttonFalseAnswer.Split(';')[1];
            }
           
        }
        buttonAnswers[randomButtonIndexForRightAnswer].GetComponentInChildren<TMP_Text>().text = gameManager.rightAnswer;
    }

    public void buttonAnswersReset()
    {
        for (int i = 0; i < buttonAnswers.Length; i++)
            buttonAnswers[i].GetComponentInChildren<TMP_Text>().text = "";
    }
     

    public void ShuffleCountryList()
    {
        for (int i = 0; i < _countryfinder.countryList.Count; i++)
        {
            int rnd = UnityEngine.Random.Range(0, _countryfinder.countryList.Count);
            tempCountry = (string)_countryfinder.countryList[rnd];
            _countryfinder.countryList[rnd] = _countryfinder.countryList[i];
            _countryfinder.countryList[i] = tempCountry;
        }
    }

    //tamamen debug amaçlarýyla yaptýðým bir fonksiyon. Diðer scriptten aldýðým veriyi doðru aldým mý kontrol etmek için yazdýrýyorum.
    void showCountryList()
    {
            foreach (string value in _countryfinder.countryList)
            {
                print(value);
            }
    }

    public void emptyCountryList()
    {
        _countryfinder.ListCleaner();
    }
}

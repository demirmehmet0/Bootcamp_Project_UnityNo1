using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class selectCountries : MonoBehaviour
{
    countryFinder _countryfinder;
    gameManager gameManager;
    bool inSelectionPhase = true;
    bool finderLocSet = false;
    string selectedCountryName = null;
    string country1name = null;
    string country2name = null;
    string country3name = null;
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

        if (!gameManager._isGameActive && inSelectionPhase)
        {
            changeSelectedCountryName();
            if(_countryfinder.countryList.Count >= 1)
            {
                selectRemainingCountries();
                enableMeshForSelected();
                findMiddleVector();
                inSelectionPhase = false;
            }
            
            
        }
        showCountryList();
    }

    void enableMeshForSelected()
    {
        transform.Find((string)selectedCountryName).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)country1name).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)country2name).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)country3name).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)selectedCountryName).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)country1name).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)country2name).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)country3name).GetComponent<countryMarkerBehaviour>().enabled = true;
    }

    void findMiddleVector()
    {
        countryVector2 = transform.Find((string)country1name).GetComponent<Transform>().position;
        countryVector3 = transform.Find((string)country2name).GetComponent<Transform>().position;
        countryVector4 = transform.Find((string)country3name).GetComponent<Transform>().position;
        middleVector = (countryVector1 + countryVector2 + countryVector3 + countryVector4).normalized * radiusOfEarth;
        // Debug.Log(middleVector);
    }

    void changeSelectedCountryName()
    {
        if (!finderLocSet)
        {
            selectedCountryName = "Germany"; // Normalde bu metod içinde baþka bir scriptten gelecek seçilmiþ ülke verisine eþlenecek;
            countryVector1 = transform.Find((string)selectedCountryName).GetComponent<Transform>().position;
            if(Random.Range(1,3) % 2 == 0)
            {
                _countryfinder.transform.position = countryVector1 + new Vector3(Random.Range(1, 3), Random.Range(2, 10), Random.Range(1, 3));
               
            }else
            {
                _countryfinder.transform.position = countryVector1 + new Vector3(Random.Range(-3, -1), Random.Range(-10, -2), Random.Range(-3, -1));
            }
            finderLocSet = true;
           // Debug.Log("CountryFinderLOc: " + _countryfinder.transform.position);
        }
        
       // selectRemainingCountries();
    }

   
    void selectRemainingCountries()
    {
        if(_countryfinder.countryList.Count >= 1)
        {
            _countryfinder.countryList.Remove(selectedCountryName);
            ShuffleCountryList();
            country1name = (string)_countryfinder.countryList[1];
            country2name = (string)_countryfinder.countryList[2];
            country3name = (string)_countryfinder.countryList[3];
            //Debug.Log("Country1: " + country1name + " Country2: " + country2name + " Country3 : " + country3name);
        }
      

        
    }

    public void ShuffleCountryList()
    {
        for (int i = 0; i < _countryfinder.countryList.Count; i++)
        {
            int rnd = Random.Range(0, _countryfinder.countryList.Count);
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
}

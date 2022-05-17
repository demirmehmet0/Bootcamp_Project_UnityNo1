using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class selectCountries : MonoBehaviour
{
    countryFinder _countryfinder;
    bool _listShown = false;
    bool inSelectionPhase = true;
    string selectedCountryName = null;
    string country1name = null;
    string country2name = null;
    string country3name = null;
    private string tempCountry;

    // Start is called before the first frame update
    void Start()
    {
        _countryfinder = GameObject.FindGameObjectWithTag("countryFinder").GetComponent<countryFinder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inSelectionPhase)
        {
            changeSelectedCountryName();
            delistSelectedCountry();
            selectRemainingCountries();
            inSelectionPhase = false;
        }
       
    }

    void changeSelectedCountryName()
    {
        selectedCountryName = "Algeria"; // Normalde bu metod içinde baþka bir scriptten gelecek seçilmiþ ülke verisine eþlenecek;
    }


    void delistSelectedCountry()
    {
        _countryfinder.countryList.Remove(selectedCountryName);
        showCountryList();
    }


    void selectRemainingCountries()
    {
        ShuffleCountryList();
        country1name = (string)_countryfinder.countryList[1];
        country2name = (string)_countryfinder.countryList[2];
        country3name = (string)_countryfinder.countryList[3];

        //Debug.Log("Country1: " + country1name + "Country2: " + country2name + "Country3 : " + country3name);
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
        if (!_listShown)
        {
            foreach (string value in _countryfinder.countryList)
            {
                print(value);
            }

            _listShown = true;
        }
    }
}

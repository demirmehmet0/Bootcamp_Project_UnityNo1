using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countryFinder : MonoBehaviour
{
    public ArrayList countryList = new ArrayList();
    selectCountries selectCountries;
   
    // Start is called before the first frame update
    void Start()
    {
        selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectCountries.inSelectionPhase)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }

        if (!selectCountries.inSelectionPhase)
        {
           gameObject.GetComponent<Collider>().enabled = false;
            ListCleaner();
        }
    }

    public void ListCleaner()
    {
        countryList.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (countryList.Contains(collision.gameObject.name))
        {

        }
        else
        {
           // Debug.Log(collision.gameObject.name);
            countryList.Add(collision.gameObject.name);
        }
    }
 


}

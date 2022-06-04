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
            gameObject.transform.localScale += new Vector3(1, 1, 1);
        }

        if (!selectCountries.inSelectionPhase)
        {
           gameObject.GetComponent<Collider>().enabled = false;
            ListCleaner();
        }
    }

    public void ListCleaner()
    {
        gameObject.transform.localScale = new Vector3(20, 20, 20);
        countryList.Clear(); 
    }
    void q(string s) { }
    private void OnCollisionEnter(Collision collision)
    {
        if (countryList.Contains(collision.gameObject.name))
        {

        }
        else
        {
           // q(collision.gameObject.name);
            countryList.Add(collision.gameObject.name);
        }
    }
 


}

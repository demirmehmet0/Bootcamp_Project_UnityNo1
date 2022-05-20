using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countryFinder : MonoBehaviour
{
    public ArrayList countryList = new ArrayList();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ListCleaner()
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

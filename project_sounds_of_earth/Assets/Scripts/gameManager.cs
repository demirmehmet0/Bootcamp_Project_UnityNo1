using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public bool _isGameActive = false;
   

    private void Start()
    {
        if (_isGameActive)
         transform.Find("EarthModelv1").GetComponent<SpinFree>().enabled = false;
 
    }


}

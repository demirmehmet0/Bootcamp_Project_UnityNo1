using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public bool _isGameActive = false;
    public float playerScore = 0;
    float questionTimer = 10;

    private void Start()
    {
        if (_isGameActive)
         transform.Find("EarthModelv1").GetComponent<SpinFree>().enabled = false;
 
    }


  


    void increasePlayerScore(float scoreMultiplier)
    {
        //playerScore = remainingSeconds * scoreMultiplier;
    }


}

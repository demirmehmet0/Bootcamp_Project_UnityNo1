using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public bool _isGameActive = false;
    public bool _isGameReadyToStart = true; 
    public float playerScore = 0;
    float questionTimer = 10;

    private void Start()
    {
       
    }


  


    void increasePlayerScore(float scoreMultiplier)
    {
        //playerScore = remainingSeconds * scoreMultiplier;
    }


}

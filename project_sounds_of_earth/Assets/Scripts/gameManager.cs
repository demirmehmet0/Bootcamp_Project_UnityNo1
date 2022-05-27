using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public bool _isGameActive = false;
    public bool inAnswerPhase = false; 
    public float playerScore = 0;
    float questionTimerRemainder = 10;
    int RightAnswerChain = 0;
    float scoreMultiplier = 1;

    private void Start()
    {
       
    }


    private void Update()
    {
       if(_isGameActive && inAnswerPhase)
        {
          questionTimerRemainder -= Time.deltaTime;
        }


    }

    void increaseOrResetChain()
    {
        // if correct answer
        RightAnswerChain++;
        // if wrong answer or if no answer
        RightAnswerChain = 0;
    }

    void increasePlayerScore(float remainingSeconds, float scoreMultiplier)
    {
        playerScore += remainingSeconds * scoreMultiplier;
    }

    void calculateScoreMultiplier(int chain)
    {
        scoreMultiplier = Mathf.Pow(1.5f, chain);
    }

    void ResetAlltoInitialCondition()
    {
       RightAnswerChain = 0;
       scoreMultiplier = 1;
       playerScore = 0;
    }


}

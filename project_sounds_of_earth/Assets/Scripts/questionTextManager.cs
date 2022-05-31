using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questionTextManager : MonoBehaviour
{
    gameManager gameManager;

    [SerializeField] TMP_Text questionOGText;
    [SerializeField] TMP_Text questionLatinText;
    [SerializeField] TMP_Text questionEnglishMeaning;
    [SerializeField] TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetNewQuestionText();
    }

    void CountdownBeforeQuestion()
    {
        countdownText.text = "Get Ready!";
        if (true)//ready for next question
        {
            countdownText.text = "3 2 1 !";
        }

    }

    void SetNewQuestionText()
    {
        if(gameManager.questionResult != null && gameManager.gotAnswerFromApi == true)
        {
            questionOGText.text = "OG text: " + gameManager.questionResult[3];
            questionLatinText.text = "Latin text: " + gameManager.questionResult[4];
            questionEnglishMeaning.text = "Eng meaning: " + gameManager.questionResult[5];
        }
        
    }

}

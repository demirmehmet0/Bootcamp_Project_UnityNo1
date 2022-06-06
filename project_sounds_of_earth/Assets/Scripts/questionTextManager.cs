using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class questionTextManager : MonoBehaviour
{
    gameManager gameManager;

    [SerializeField] Text questionOGText;
    [SerializeField] Text questionLatinText;
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
            questionLatinText.text = "Text: " + gameManager.questionResult[4];
        }
             
    }

}

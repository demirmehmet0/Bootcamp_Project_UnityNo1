using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionTextManager : MonoBehaviour
{
    gameManager gameManager;

    [SerializeField] Text questionLatinText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    void Update()
    {
        SetNewQuestionText();
    }
    /// <summary>
    /// Normalde bu scriptte ekran üstüne yazdýrýlan textlerin tamamýnýn kontrolü planlanmýþtý.
    /// Örneðin sorudan önce gelen bi countdown texti de bu script deðiþtirecekti. Ama develpment sýrasýnda iþlevsiz kaldý
    /// </summary>
    void SetNewQuestionText()
    {
        if(gameManager.questionResult != null && gameManager.gotAnswerFromApi == true)
        {
            questionLatinText.text = "Text: " + gameManager.questionResult[4];
        }
             
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using TMPro;

public class uiHandler : MonoBehaviour
{
    gameManager gameManager;
    selectCountries _selectCountries;
    CameraMovement cameraMovement;

    public AudioSource questionSound;
    public GameObject Main;
    public GameObject Game;
    public GameObject Options;
    List<GameObject> menus = new List<GameObject>();
    
    void Start()
    {
        menus.Add(Main);
        menus.Add(Game);
        menus.Add(Options);
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager._isGameActive)
        {

        }

    }


    public void StartTheGame()
    {
        //gameManager._isGameActive = true;
        //_selectCountries.inSelectionPhase = true;
        gameManager.startGame = true;
        Main.SetActive(false);
        Game.SetActive(true);
    }

    public void ExitPlayMode()
    {
        _selectCountries.disableMeshAndScriptForSelected();
        gameManager._isGameActive = false;
        Main.SetActive(true);
        Game.SetActive(false);

    }

    public void AnswerButton_Click(Button button)
    {
        if (button.GetComponentInChildren<TMP_Text>().text == gameManager.rightAnswer)
        {
            if (questionSound.isPlaying) questionSound.Stop();
            Debug.Log("Doğru cevap");
            gameManager.nextQuestionButton.gameObject.SetActive(true);
        }
    }
    public void Option()
    {
        Main.SetActive(false);
        Game.SetActive(false);
        Options.SetActive(true);
    }
    public void Back(string page)
    {
        foreach (GameObject obj in menus)
            obj.SetActive(false);
        foreach (GameObject obj in menus)
        {
            if (obj.name == page) obj.SetActive(true);

        }
    }
    public void NextQuestion()
    {
        /*_selectCountries.disableMeshAndScriptForSelected();
        cameraMovement.randomIdleNumbersSet = false;
        _selectCountries.inSelectionPhase = true;*/
        gameManager.ask = true;
        gameManager.nextQuestionButton.gameObject.SetActive(false); 
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}


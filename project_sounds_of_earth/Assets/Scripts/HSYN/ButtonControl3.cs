using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ButtonControl3 : MonoBehaviour
{

    public GameObject button;
    public GameObject canvas;
    public void Start()
    {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject newButton = Instantiate(button) as GameObject;
        newButton.transform.SetParent(newCanvas.transform, true);
        //buton.GetComponent<Button>().onClick.AddListener();
    }
    public void OnButtonClick()
    {
        Debug.Log(button.transform.Find("Text").GetComponent<Text>().text);
        /*if (buton.transform.Find("Text").GetComponent<Text>().text=="Almanya")
        {
            Debug.Log("You Have The correcct answer");
        }
        else
        {
            Debug.Log("You have the wrong answeer");
        }*/
    }
}
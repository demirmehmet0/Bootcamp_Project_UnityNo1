using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class ButtonControl : MonoBehaviour
{

    public GameObject button;
    public GameObject canvas;
    public int countrynumber;
    public GameObject EarthModel;
    public GameObject GameObjectlereErisim;
    GameObject[] ulkeler;
    int i;
    
    string ulke;



    public ArrayList countryler = new ArrayList();

    public void Start()
    {

        EarthModel = this.gameObject;
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject newButton = Instantiate(button) as GameObject;
        newButton.transform.SetParent(newCanvas.transform, true);
        ulkeler = GameObjectlereErisim.GetComponent<GameObjectlereErisim>().country;
        countryler.Add(ulkeler);
    }

    public void Update()
    {
    
    }

    public void OnButtonClick()
    {

        countrynumber = Random.Range(0, 250);// if the answer eithr true or false, produce a random number. if answer is true, we use this number in if parantezleri, if answer is false the we use this number in else parantezleri.

        if (button.transform.Find("Text").GetComponent<Text>().text=="Germany".ToUpper())
        {

            //foreach(string ulke in)
            //{
                Debug.Log(countryler);
                
            //}
            //Debug.Log(((Countries)Countries.TR).AsString(EnumFormat.Description));//in this line, we should read a new country and the old txrt should be disappeared
        }
        else
        {
            Debug.Log("s");//in this line, we should read a new country and the old txrt should be disappeared
            Debug.Log("You have the wrong answeer");
        }
    }
}


/*Butona basýldýðýnda cevabýn doðru mu yanlýþ mý olduðunu söyleyen script yazýldý. 4 buton içinden biri doðru cevap olacak, bu doðru cevap olan ülkenin müziði çekilecek ses olarak ve 
 bu ülke þýklardan birine random olarak atanacak.(button .text=sdlkghslg) gbii. bu atama yapýldýktan sonra 250 ülke içerisinden random 3 ülke seçilip kalan 3 butona atanacak text olarak.
ve her seçim yapýldýðýnda doðru cevap gibi bir geri dönüþ yapýlýp butnlara yeni atama yapýlacak ve yeni ülkenin müzipi ayný þekilde çekilecek 
*/
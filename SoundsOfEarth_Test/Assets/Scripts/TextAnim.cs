using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextAnim : MonoBehaviour
{
    private TMP_Text _Text;
    private bool isUp = true;
    private bool isLoading = false;
    private bool is3Dot = false;
    public int AnimVal = 0;

    private void Awake()
    {
        _Text = GetComponent<TMP_Text>();
        if (_Text.text == "Oyun Bekleniyor")
        { isLoading = true; StartCoroutine("Loading"); }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator Loading()
    {
    start:
        yield return new WaitForSeconds(0.3f);
        if (_Text.text.Contains("Oyun Bekleniyor") && _Text.text != "Oyun Bekleniyor..." && !is3Dot)
            _Text.text += ".";
        else
        {
            if (_Text.text.Contains("Oyun Bekleniyor"))
            {
                _Text.text = _Text.text.Remove(_Text.text.Length - 1);
                is3Dot = true;
                if (_Text.text == "Oyun Bekleniyor") is3Dot = false;
            } 
        }
        goto start;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLoading)
        {
            if (_Text.fontSize >= 32 && isUp) { isUp = false; }
            else if (_Text.fontSize <= 28 && !isUp) { isUp = true; }

            if (isUp)
            {
                _Text.fontSize += AnimVal * Time.deltaTime;
            }
            else
            {
                _Text.fontSize -= AnimVal * Time.deltaTime;
            }
        }
    }
}

using System.Collections;
using UnityEngine;

public class LoadFile : MonoBehaviour
{

    public string urlString;
    public GameObject progressBar;
    string url;
    WWW www;
    AudioClip clip;
    AudioSource _audioSource;
    AudioClip _audioClip;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioClip = GetComponent<AudioClip>();
    }
    void Update()
    {
        if(www != null)
        {
            progressBar.transform.localScale = new Vector3(www.progress, 1, 1);
        }
    }

    IEnumerator LoadURL()
    {
        url = urlString;
        www = new WWW(url);
        clip = www.GetAudioClip(false, false);//in this line the false means the 2d music because it is background and the true means the stream music. you can change if you dont want to play a 2d music or a stream music

        while (!www.isDone)
        {
            yield return www;

        }
        if (www.error == null)
            {
                Debug.Log("You have a good code that has no error");
                _audioSource.clip = clip;
                _audioSource.PlayOneShot(_audioClip);
                
            if (_audioSource.clip.isReadyToPlay == true)
            {
                Debug.Log("it is ready to play");
                _audioSource.Play();
            }
            else
            {
                Debug.Log("it is not ready toý play");
            }

            }
            if (www.error != null)
            {
                Debug.Log("Error happened. you should load an OGG OR WAV file");
            }
            yield return 0;
        
    }


    private void OnGUI()
    {
        urlString = GUI.TextField(new Rect(10, 10, 200, 20), urlString, 100);//you can use textare instead of textfield here to enter multiple url'S
        if (GUI.Button(new Rect(10, 40, 200, 50),"Load Url"))
        {
            //when you click the button, the things will occur according to this area
            StartCoroutine(LoadURL());
        }
    }
}

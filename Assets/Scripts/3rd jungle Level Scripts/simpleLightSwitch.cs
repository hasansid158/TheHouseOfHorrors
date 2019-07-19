using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class simpleLightSwitch : MonoBehaviour
{

    Light lite;
    public AudioClip lightOn, lightOff;
    public GameObject img;
    public Image OnImg, offImg;

    void Start() 
    {
        lite = gameObject.GetComponent<Light>();
    }

    public void lighter()
    {

        lite.enabled = !lite.enabled;

        if (lite.enabled)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().PlayOneShot(lightOn, 1);
            img.GetComponent<Image>().sprite = OnImg.sprite;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().PlayOneShot(lightOff, 1);
            img.GetComponent<Image>().sprite = offImg.sprite;
        }
    }
}

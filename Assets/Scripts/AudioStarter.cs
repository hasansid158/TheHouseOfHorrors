using UnityEngine;
using System.Collections;

public class AudioStarter : MonoBehaviour
{
    public GameObject audioS;
    public AudioClip BgSound, cricketA;

    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = cricketA;
        gameObject.GetComponent<AudioSource>().volume = 0.4f;
        gameObject.GetComponent<AudioSource>().Play();
        audioS.GetComponent<AudioSource>().clip = BgSound;
        audioS.GetComponent<AudioSource>().Play();
    }
}
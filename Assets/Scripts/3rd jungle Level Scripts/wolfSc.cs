using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSc : MonoBehaviour
{
    public GameObject wolfSoundCont;
    public AudioClip wolfHowl;
    bool once;

    void Start()
    {
        wolfSoundCont.GetComponent<AudioSource>().PlayOneShot(wolfHowl, 0.8f);
    }

    void Update()
    {
        if (!wolfSoundCont.GetComponent<AudioSource>().isPlaying && !once)
        {
            once = true;
            StartCoroutine(wolfSoundWait());
        }
    }

    IEnumerator wolfSoundWait()
    {
        yield return new WaitForSeconds(Random.Range(4, 10));
        wolfSoundCont.GetComponent<AudioSource>().PlayOneShot(wolfHowl, 0.8f);
        once = false;
    }
}

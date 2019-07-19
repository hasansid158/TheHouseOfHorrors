using UnityEngine;
using System.Collections;

public class fireOff : MonoBehaviour
{
    public GameObject fireOffCol, fire1, fire2, bgSound2, heartBeatObj, flashLight;
    public AudioClip fireOut1, fireOut2, heartBeatSound;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == fireOffCol)
        {
            fire1.GetComponent<ParticleSystem>().Stop();
            fire1.GetComponent<AudioSource>().PlayOneShot(fireOut1, 1);

            fire2.GetComponent<ParticleSystem>().Stop();
            fire2.GetComponent<AudioSource>().PlayOneShot(fireOut2, 1);

            bgSound2.GetComponent<AudioSource>().volume = 0.02f;
            StartCoroutine("playSoundTime");
            fireOffCol.SetActive(false);
        }
    }

    IEnumerator playSoundTime() 
    {
        heartBeatObj.GetComponent<AudioSource>().PlayOneShot(heartBeatSound, 1);

        yield return new WaitForSeconds(2);
        heartBeatObj.GetComponent<AudioSource>().volume = 0.8f;

        yield return new WaitForSeconds(2);
        heartBeatObj.GetComponent<AudioSource>().volume = 0.5f;

        flashLight.GetComponent<LightFlicker>().fliker = true;

        yield return new WaitForSeconds(2);
        heartBeatObj.GetComponent<AudioSource>().volume = 0.2f;

        yield return new WaitForSeconds(1);
        heartBeatObj.GetComponent<AudioSource>().Stop();
    }
}

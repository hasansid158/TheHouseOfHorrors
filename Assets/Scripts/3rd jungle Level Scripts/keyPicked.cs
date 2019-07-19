using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPicked : MonoBehaviour
{
    public GameObject objText, farmGate, gateText, soundCont;
    public AudioClip keySound;

    public keyRay keyRaySc;
    int keyNum = 0;

    public void pickKey()
    {
        soundCont.GetComponent<AudioSource>().PlayOneShot(keySound, 1);
        keyRaySc.key.SetActive(false);
        keyRaySc.keyPickUpBut.SetActive(false);
        keyNum++;
        objText.GetComponent<Text>().text = "keys found " + keyNum + "|5";

        if(keyNum == 3)
        {
            got3();
        }
    }

    void got3()
    {
        gateText.SetActive(false);
        farmGate.transform.eulerAngles = new Vector3(90, 0, 238);
    }
}

using UnityEngine;
using System.Collections;

public class mainGateOpener : MonoBehaviour {

    public GameObject mainDoor2, lockPickBut;
    public AudioClip openingDoor;
    bool startSound = true;

    void Update () {

        if (lockPickBut.GetComponent<LockPicking>().openDoor)
        {
            if (startSound)
            {
                playSound();
            }
            startSound = false;

            Quaternion OpenDoorRot1 = Quaternion.Euler(0, 80, 0);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, OpenDoorRot1, 0.6f * Time.deltaTime);

            Quaternion OpenDoorRot2 = Quaternion.Euler(0, -80, 0);
            mainDoor2.transform.rotation = Quaternion.Slerp(mainDoor2.transform.rotation, OpenDoorRot2, 0.5f * Time.deltaTime);            
        }
    }

    void playSound() 
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(openingDoor, 1);
        mainDoor2.GetComponent<AudioSource>().PlayOneShot(openingDoor, 1);
    }
}

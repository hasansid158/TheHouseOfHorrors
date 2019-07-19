using UnityEngine;
using System.Collections;

public class DoorClosed : MonoBehaviour 
{
    public GameObject DoorCloseCol;
    bool DoorCloser;
    public GameObject door1, door2;
    public bool KeyNow;
    public AudioClip twoDoorsClosed;
    public static bool DoorsOpen;
    public GameObject keyIcon, keyBut;
    public GameObject gateSound;
    public GameObject swingStopCol;
    public GameObject swing,SoundStarter;

	void Update () {

        if (DoorCloser)
        {
            if (!KeyandLockPick.haveKey2)
            {
                Quaternion OpenDoorRot1 = Quaternion.Euler(90, 0, 90);
                door1.transform.rotation = Quaternion.Slerp(door1.transform.rotation, OpenDoorRot1, 2.5f * Time.deltaTime);

                Quaternion OpenDoorRot2 = Quaternion.Euler(90, 0f, -90);
                door2.transform.rotation = Quaternion.Slerp(door2.transform.rotation, OpenDoorRot2, 3 * Time.deltaTime);
            }
            else if(DoorsOpen) 
            {
                keyIcon.SetActive(false);
                keyBut.SetActive(false);

                Quaternion OpenDoorRot1 = Quaternion.Euler(90, 0, 180);
                door1.transform.rotation = Quaternion.Slerp(door1.transform.rotation, OpenDoorRot1, 1f * Time.deltaTime);

                Quaternion OpenDoorRot2 = Quaternion.Euler(90, 0f, -180);
                door2.transform.rotation = Quaternion.Slerp(door2.transform.rotation, OpenDoorRot2, 1.5f * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == DoorCloseCol)
        {
            gateSound.GetComponent<AudioSource>().PlayOneShot(twoDoorsClosed, 0.9f);
            DoorCloser = true;
            StartCoroutine(gameObject.GetComponent<ObjectHint>().DoorCloser());
            Destroy(DoorCloseCol);
            KeyNow = true;
            swingStopCol.SetActive(true);
            swing.GetComponent<AudioSource>().Play();
            swing.GetComponent<Animator>().SetFloat("startSwing", 1);
            SoundStarter.SetActive(true);
        }

        if (col.gameObject == swingStopCol)
        {
            swing.GetComponent<Animator>().SetFloat("startSwing", -1);
            swing.GetComponent<AudioSource>().Stop();
        }
    }
}

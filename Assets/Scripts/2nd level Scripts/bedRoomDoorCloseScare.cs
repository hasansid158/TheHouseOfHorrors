using UnityEngine;
using System.Collections;

public class bedRoomDoorCloseScare : MonoBehaviour
{
    public GameObject door1, door2, door1Sound;
    public GameObject cldr;
    public bool doorClose;
    public AudioClip room2DoorsClose;

    void OnTriggerEnter(Collider col) 
    { 
        if(col.gameObject == cldr) 
        {
            door1.GetComponent<Animation>().Play();
            door2.GetComponent<Animation>().Play();
            door1Sound.GetComponent<AudioSource>().PlayOneShot(room2DoorsClose, 1);
            cldr.SetActive(false);
            doorClose = true;
            door1.GetComponent<BedRoomDoorOpener>().bed1DoorCol.SetActive(true);
            door1.GetComponent<BedRoomDoorOpener>().keyBed1Picked = true;
        }
    }
}

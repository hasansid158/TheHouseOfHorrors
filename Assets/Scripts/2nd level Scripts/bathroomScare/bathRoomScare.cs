using UnityEngine;
using System.Collections;

public class bathRoomScare : MonoBehaviour
{

    public GameObject bathroomDoor, bathroomCol;
    public AudioClip doorClose;
    
    IEnumerator soundOn () 
    {
        yield return new WaitForSeconds(0.2f);
        bathroomDoor.GetComponent<AudioSource>().PlayOneShot(doorClose, 1);
    }

    void OnTriggerEnter(Collider cl) 
    { 
        if(cl.gameObject == bathroomCol) 
        {
            bathroomCol.SetActive(false);
            bathroomDoor.GetComponent<Animation>().Play("bathroomDoorAnim");
            StartCoroutine(soundOn());
        }
    }
}

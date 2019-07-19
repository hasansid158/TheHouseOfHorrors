using UnityEngine;
using System.Collections;

public class bathRoomDoorOpener : MonoBehaviour
{
    bool openDoor = false;
    public AudioClip doorSound;
    public GameObject doorCol, doorBut;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.2f)) 
        { 
            if(hit.collider.gameObject == doorCol) 
            {
                doorBut.SetActive(true);
            }
            else
            {
                doorBut.SetActive(false);
            }
        }
        else 
        {
            doorBut.SetActive(false);
        }
        
        if (openDoor)
        {
            Quaternion OpenDoorRot3 = Quaternion.Euler(90, 0, 8);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, OpenDoorRot3, 1.2f * Time.deltaTime);
        }
    }

    public void openBath()
    {
        openDoor = true;
        gameObject.GetComponent<AudioSource>().pitch = 0.8f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorSound, 1);
        doorCol.SetActive(false);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CabinDoorOpener : MonoBehaviour {

    Quaternion DorRot;
    bool openDoor;
    public GameObject talkTXT, keyIcon;
    public AudioClip lockedDoor, openedDoor;
	
    void Start() 
    {
        DorRot = Quaternion.Euler(90f, 0f, 5f);
    }

	void Update () {

        if (openDoor)
        {
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, DorRot, 2 * Time.deltaTime);
        }	
	}

    IEnumerator CabinDoorTXT() 
    {        
        talkTXT.GetComponent<Text>().text = "The door is locked\nI can't open it..";
        yield return new WaitForSeconds(5);
        talkTXT.GetComponent<Text>().text = "";
    }

    public void CabinOpen()
    {
        if (KeyandLockPick.haveKey)        
        {
            openDoor = true;
            keyIcon.SetActive(false);
            gameObject.GetComponent<AudioSource>().pitch = 1.15f;
            gameObject.GetComponent<AudioSource>().PlayOneShot(openedDoor, 0.7f);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        else
        {
            gameObject.GetComponent<AudioSource>().pitch = 1;
            gameObject.GetComponent<AudioSource>().PlayOneShot(lockedDoor, 0.7f);
            StartCoroutine(CabinDoorTXT());
        }
    }
}

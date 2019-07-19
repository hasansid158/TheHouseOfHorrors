using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SmallRoomKeyPickup : MonoBehaviour
{
    public GameObject key, keyCol, keyButton, keyIcon, keySoundObj, talkText, objText, chair;
    public AudioClip keyPickedSound;
    public bool openDoor;
    
    IEnumerator keyText() 
    {
        objText.transform.parent.gameObject.SetActive(false);
        talkText.GetComponent<Text>().text = "A key was in the safe, it must belong to that last locked door";

        yield return new WaitForSeconds(7);

        talkText.GetComponent<Text>().text = "";
        objText.transform.parent.gameObject.SetActive(true);
        objText.GetComponent<Text>().text = "Find the treasure in the house";
    }

    public void keyPicker() 
    {
        keySoundObj.GetComponent<AudioSource>().PlayOneShot(keyPickedSound, 1);
        key.SetActive(false);
        keyIcon.SetActive(true);
        openDoor = true;
        StartCoroutine("keyText");
        chair.transform.position = new Vector3(81.82f, 2.25f, 234.56f);
    }

    void Update() 
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 1.2f)) 
        { 
            if(hit.collider.gameObject == keyCol) 
            {
                keyButton.SetActive(true);
            }
            else 
            {
                keyButton.SetActive(false);
            }
        }
        else
        {
            keyButton.SetActive(false);
        }
    }
}

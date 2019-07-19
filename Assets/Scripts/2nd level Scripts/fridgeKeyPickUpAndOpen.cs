using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fridgeKeyPickUpAndOpen : MonoBehaviour
{

    public GameObject keyModel, fridgeDoor, keyIcon, doorWithSound, drawer, talkText;
    public bool openFridge = false, gotFridgeKey = false;
    public AudioClip keySound, drawerSound;

    IEnumerator keyTalk() 
    {
        talkText.GetComponent<Text>().text = "Another key, which door will it open?";
        yield return new WaitForSeconds(5);
        talkText.GetComponent<Text>().text = "";
    }

    public void keyPicked()
    {
        keyIcon.SetActive(true);
        keyModel.SetActive(false);
        gotFridgeKey = true;
        doorWithSound.GetComponent<AudioSource>().pitch = 1;
        doorWithSound.GetComponent<AudioSource>().PlayOneShot(keySound, 1);
        drawer.GetComponent<Animation>().Play("DrossClose");
        drawer.GetComponent<AudioSource>().PlayOneShot(drawerSound, 1);

        StartCoroutine("keyTalk");
    }

    void Update()
    {
        if (openFridge)
        {
            Quaternion OpenDoorRot1 = Quaternion.Euler(-90, 0, 90);
            fridgeDoor.transform.rotation = Quaternion.Slerp(fridgeDoor.gameObject.transform.rotation, OpenDoorRot1, 1f * Time.deltaTime);
        }
    }
}

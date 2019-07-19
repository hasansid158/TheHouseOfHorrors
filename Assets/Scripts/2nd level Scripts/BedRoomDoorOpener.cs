using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BedRoomDoorOpener : MonoBehaviour
{

    public GameObject keyIcon,
    keyBed1Mod,
    Door2,
    Door3,
    talkText,
    bed1DoorCol,
    bed2DoorCol,
    pl,
    fridgeCol,
    fridgeDoor,
    keyBed2Col,
    keyBed2Mod,
    fLight,
    smallRoomDoor,
    SmallRoomDoorCol,
    rockingChair,
    rockingChairSound,
    roomGhost,
    ghostRayCol;

    public bool openDoorsBed1 = false,
    keyBed1Picked = false,
    keyBed2Picked = false,
    openBed2Door = false,
    smallDoorOpened;
    public AudioClip doorLocked, openingDoor, keyPickSound, fridgeDoorSound;

    void Update()
    {
        if (openDoorsBed1)
        {
            Quaternion OpenDoorRot1 = Quaternion.Euler(90, 0, 90);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, OpenDoorRot1, 1f * Time.deltaTime);

            Quaternion OpenDoorRot2 = Quaternion.Euler(90, 0, 90);
            Door2.transform.rotation = Quaternion.Slerp(Door2.transform.rotation, OpenDoorRot2, 1.2f * Time.deltaTime);
            
            keyBed1Picked = false;
        }

        if (openBed2Door)
        {
            Quaternion OpenDoorRot3 = Quaternion.Euler(90, 0, 270);
            Door3.transform.rotation = Quaternion.Slerp(Door3.transform.rotation, OpenDoorRot3, 0.8f * Time.deltaTime);
        }
    }

    public void keyPickUp()
    {
        keyBed1Picked = true;
        keyIcon.SetActive(true);
        keyBed1Mod.SetActive(false);
        StartCoroutine("key1Picked");
        gameObject.GetComponent<AudioSource>().PlayOneShot(keyPickSound, 1);
    }

    public void keyPickUp2Bed() 
    {
        keyBed2Picked = true;
        keyIcon.SetActive(true);
        keyBed2Mod.SetActive(false);
        StartCoroutine("key2Picked");
        gameObject.GetComponent<AudioSource>().PlayOneShot(keyPickSound, 1);
    }

    IEnumerator key1Picked()
    {
        talkText.GetComponent<Text>().text = "Where does this key belong too?";

        yield return new WaitForSeconds(5);

        talkText.GetComponent<Text>().text = "";
    }

    IEnumerator key2Picked()
    {
        talkText.GetComponent<Text>().text = "Another key";

        yield return new WaitForSeconds(4);

        talkText.GetComponent<Text>().text = "";
    }

    IEnumerator bed1Closed()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorLocked, 1);
        talkText.GetComponent<Text>().text = "The door is locked";

        yield return new WaitForSeconds(5);

        talkText.GetComponent<Text>().text = "";
    }

    IEnumerator fridgeClosed()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorLocked, 1);
        talkText.GetComponent<Text>().text = "It's locked or jammed";

        yield return new WaitForSeconds(5);

        talkText.GetComponent<Text>().text = "";
    }

    public void doorBed1Button()
    {
        if (keyBed1Picked)
        {
            pl.GetComponent<bedRoomDoorCloseScare>().doorClose = false;
            bed1DoorCol.SetActive(false);
            openDoorsBed1 = true;
            keyIcon.SetActive(false);
            gameObject.GetComponent<AudioSource>().PlayOneShot(openingDoor, 1);
        }

        else
        {
            StopCoroutine("bed1Closed");
            StartCoroutine("bed1Closed");
        }
    }

    public void doorBed2Button()
    {
        if (keyBed2Picked)
        {
            ghostRayCol.SetActive(true);
            roomGhost.SetActive(true);
            openBed2Door = true;
            bed2DoorCol.SetActive(false);
            keyIcon.SetActive(false);
            Door3.GetComponent<AudioSource>().PlayOneShot(openingDoor, 1);
        }
        else
        {
            StopCoroutine("bed1Closed");
            StartCoroutine("bed1Closed");
        }
    }

    public void doorBed3Button()
    {
        if (pl.GetComponent<SmallRoomKeyPickup>().openDoor)
        {
            SmallRoomDoorCol.SetActive(false);
            smallRoomDoor.GetComponent<AudioSource>().Play();
            smallRoomDoor.GetComponent<Animation>().Play();
            keyIcon.SetActive(false);
            rockingChair.GetComponent<Animator>().enabled = true;
            rockingChairSound.GetComponent<AudioSource>().Play();
            smallDoorOpened = true;
        }
        else
        {
            StopCoroutine("bed1Closed");
            StartCoroutine("bed1Closed");
        }
    }

    public void fridgeButton()
    {
        if (pl.GetComponent<fridgeKeyPickUpAndOpen>().gotFridgeKey)
        {
            pl.GetComponent<fridgeKeyPickUpAndOpen>().openFridge = true;
            fridgeCol.SetActive(false);
            keyIcon.SetActive(false);
            fridgeDoor.GetComponent<AudioSource>().PlayOneShot(fridgeDoorSound, 1);
            keyBed2Col.SetActive(true);
        }

        else if (!pl.GetComponent<fridgeKeyPickUpAndOpen>().gotFridgeKey)
        {
            StopCoroutine("fridgeClosed");
            StartCoroutine("fridgeClosed");
        }
    }
}

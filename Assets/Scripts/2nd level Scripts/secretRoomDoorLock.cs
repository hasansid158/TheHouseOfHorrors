using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class secretRoomDoorLock : MonoBehaviour
{
    public GameObject strangeLock, lockButton, secretDoor, cam, room1Door, talkText, objText, keysPage, keysPageSound, keysPageBut, gun, gunPickBut, keysPageUI, rockChairScareCol, rockingChair, rockingChairSound, gunIcon;
    public GameObject[] UI;
    public bool gotGun, gotKeyPage;
    public AudioClip gunPickup;

    IEnumerator gunText() 
    { 
        if(gotKeyPage) 
        {
            talkText.GetComponent<Text>().text = "A pistol, it will help me in the forest from wild animals";
            yield return new WaitForSeconds(7);
            talkText.GetComponent<Text>().text = "";
            objText.GetComponent<Text>().text = "Go to the forest using the stairs and find all the keys";
        }
        else 
        {
            talkText.GetComponent<Text>().text = "A pistol, I'll take it, it will come in handy";
            yield return new WaitForSeconds(7);
            talkText.GetComponent<Text>().text = "";
        }
    }

    public void gunPicker() 
    {
        gun.SetActive(false);
        gotGun = true;
        gunIcon.SetActive(true);
        keysPageSound.GetComponent<AudioSource>().PlayOneShot(gunPickup, 1);

        StopAllCoroutines();
        StartCoroutine(gunText());
    }

    IEnumerator lockText()
    {
        talkText.GetComponent<Text>().text = "It's a very strange lock and it requires 5 keys to open it";
        yield return new WaitForSeconds(6);
        talkText.GetComponent<Text>().text = "";
    }

    public void strangeLockButton()
    {
        StopAllCoroutines();
        StartCoroutine("lockText");
    }

    public void keysPagePicker() 
    {
        keysPageSound.GetComponent<AudioSource>().Play();
        cam.GetComponent<TouchCamSwipe>().enabled = false;
        gameObject.GetComponent<PlayerControling>().enabled = false;
        foreach (GameObject uis in UI) 
        {
            uis.SetActive(false);
        }

        keysPage.SetActive(false);
        keysPageUI.SetActive(true);
    }

    IEnumerator keyPageText()
    {
        talkText.GetComponent<Text>().text = "I must get to the forest behind the house\nusing the stairs and find those keys!";
        objText.GetComponent<Text>().text = "Go to the forest using the stairs and find all the keys";
        yield return new WaitForSeconds(7);
        talkText.GetComponent<Text>().text = "";
    }

    public void closePageUI() 
    {
        gotKeyPage = true;
        cam.GetComponent<TouchCamSwipe>().enabled = true;
        gameObject.GetComponent<PlayerControling>().enabled = true;
        rockChairScareCol.SetActive(true);
        foreach (GameObject uis in UI)
        {
            uis.SetActive(true);
        }

        keysPageUI.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(keyPageText());
    }

    void Update()
    {
        if (room1Door.GetComponent<BedRoomDoorOpener>().smallDoorOpened)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1.2f))
            {
                if (hit.collider.gameObject == strangeLock)
                {
                    lockButton.SetActive(true);
                }

                else if (hit.collider.gameObject == keysPage) 
                {
                    keysPageBut.SetActive(true);
                }

                else if (hit.collider.gameObject == gun)
                {
                    gunPickBut.SetActive(true);
                }

                else
                {
                    lockButton.SetActive(false);
                    keysPageBut.SetActive(false);
                    gunPickBut.SetActive(false);
                }
            }
            else
            {
                lockButton.SetActive(false);
                keysPageBut.SetActive(false);
                gunPickBut.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider col) 
    { 
        if(col.gameObject == rockChairScareCol) 
        {
            rockChairScareCol.SetActive(false);
            rockingChairSound.GetComponent<AudioSource>().Stop();
            rockingChair.GetComponent<AudioSource>().Play();
            rockingChair.GetComponent<Animator>().SetInteger("chairScare", 1);
        }
    }
}

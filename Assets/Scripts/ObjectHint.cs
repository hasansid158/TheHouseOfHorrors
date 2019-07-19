using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectHint : MonoBehaviour
{

    public GameObject objTXT;
    public GameObject talkTXT;
    bool txtoff;
    public AudioClip GateLocked, DoorsOpening;
    public GameObject GhostInHouse;
    public GameObject DoorsSound, scriptSave, cam, CurrentQuality;

    void Start() 
    {
        StartCoroutine(talkEnd());

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("SavedQuality"));
        cam.GetComponent<TouchCamSwipe>().touchSensitivity = PlayerPrefs.GetInt("SavedLook");
        RenderSettings.ambientSkyColor = new Color(PlayerPrefs.GetInt("SavedVal"), PlayerPrefs.GetInt("SavedVal"), PlayerPrefs.GetInt("SavedVal"));

        if(PlayerPrefs.GetInt("SavedQuality") == 0) 
        {
            CurrentQuality.GetComponent<Text>().text = "Current Quality = Low";
        }

        else if (PlayerPrefs.GetInt("SavedQuality") == 1)
        {
            CurrentQuality.GetComponent<Text>().text = "Current Quality = Medium";
        }

        else if (PlayerPrefs.GetInt("SavedQuality") == 2)
        {
            CurrentQuality.GetComponent<Text>().text = "Current Quality = High";
        }
    }

    //FlashLight PickUp and Find your way Text
    public IEnumerator talkEnd()
    {
        talkTXT.GetComponent<Text>().text = "It's too dark here..\nI must get my flashlight from the car";
        yield return new WaitForSeconds(6);
        talkTXT.GetComponent<Text>().text = "";

        if (!txtoff)
        {
            objTXT.transform.GetChild(0).GetComponent<Text>().text = "Pick up the flastlight from the car";
            objTXT.SetActive(true);
        }
    }

    public IEnumerator HouseInObj()
    {
        talkTXT.GetComponent<Text>().text = "";
        objTXT.SetActive(false);
        yield return new WaitForSeconds(1);
        objTXT.SetActive(true);
        txtoff = true;
        objTXT.transform.GetChild(0).GetComponent<Text>().text = "Find your way to get inside the house";
    }

    IEnumerator TextClose()
    {
        yield return new WaitForSeconds(5);
        talkTXT.GetComponent<Text>().text = "";
    }

    public void Icall()
    {
        StartCoroutine(HouseInObj());
    }

    public void textON()
    {
        talkTXT.GetComponent<Text>().text = "";
        StartCoroutine(HouseInObj());
    }

    //Main house Door Closing Text

    public IEnumerator DoorCloser()
    {
        talkTXT.GetComponent<Text>().text = "The door just closed on it's own !?";
        yield return new WaitForSeconds(6);
        talkTXT.GetComponent<Text>().text = "";
    }

    IEnumerator MainHDoorClosed()
    {
        if (!KeyandLockPick.haveKey2)
        {
            if (!KeyandLockPick.haveKey)
            {
                objTXT.SetActive(false);
                talkTXT.GetComponent<Text>().text = "Door is locked now..\nMaybe I could find a key here somewhere";
                yield return new WaitForSeconds(5);
                talkTXT.GetComponent<Text>().text = "";
                objTXT.transform.GetChild(0).GetComponent<Text>().text = "Find a key to open the door";
                objTXT.SetActive(true);
            }

            else if (KeyandLockPick.haveKey)
            {
                objTXT.SetActive(false);
                talkTXT.GetComponent<Text>().text = "This key doesn't belong to this door\nAnd i can't open this door with the lockpick";
                yield return new WaitForSeconds(5);
                talkTXT.GetComponent<Text>().text = "";
                objTXT.transform.GetChild(0).GetComponent<Text>().text = "Find another key to open the door";
                objTXT.SetActive(true);
            }
        }
        else if (KeyandLockPick.haveKey2)
        {
            DoorClosed.DoorsOpen = true;
        }
    }

    public void HouseDoorClosed()
    {
        if (!KeyandLockPick.haveKey2)
        {
            DoorsSound.GetComponent<AudioSource>().PlayOneShot(GateLocked, 0.35f);
        }
        else if (KeyandLockPick.haveKey2)
        {
            DoorsSound.GetComponent<AudioSource>().PlayOneShot(DoorsOpening, 0.8f);
            gameObject.transform.GetChild(0).GetComponent<Cutscene>().StartCut();
        }
        StartCoroutine(MainHDoorClosed());
    }
}

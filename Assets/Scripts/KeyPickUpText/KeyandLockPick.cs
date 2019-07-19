using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyandLockPick : MonoBehaviour
{

    public GameObject talkText, ObjectText;
    public GameObject KeyButton, LockpickButton;
    public GameObject KeyMod, KeyIcon, LockMod, LockIcon;
    public static bool haveKey, key;
    public GameObject key2, key2But, key2Mod;
    public GameObject ghostDisabler, Flight;
    public AudioClip gotKey;
    public static bool haveKey2;

    IEnumerator keyPicked()
    {
        KeyMod.SetActive(false);
        LockMod.SetActive(false);
        KeyIcon.SetActive(true);
        LockIcon.SetActive(true);
        ObjectText.SetActive(false);
        talkText.GetComponent<Text>().text = "A key and a lockpick !\n Now i can open that door";
        yield return new WaitForSeconds(5);
        talkText.GetComponent<Text>().text = "";
        ObjectText.transform.GetChild(0).GetComponent<Text>().text = "Open the house door with the key";
        ObjectText.SetActive(true);
    }
    public void keyPicker()
    {
        gameObject.GetComponent<AudioSource>().pitch = 1f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(gotKey, 1);
        haveKey = true;
        StartCoroutine(keyPicked());
    }

    IEnumerator key_2Picked()
    {
        ghostDisabler.SetActive(true);
        key2Mod.SetActive(false);
        KeyIcon.SetActive(true);
        ObjectText.SetActive(false);
        talkText.GetComponent<Text>().text = "Another key,\nlets open the door with this one";
        yield return new WaitForSeconds(1);
        Flight.GetComponent<LightFlicker>().enabled = true;
        yield return new WaitForSeconds(4);
        talkText.GetComponent<Text>().text = "";
        ObjectText.transform.GetChild(0).GetComponent<Text>().text = "Open the house door with the key";
        ObjectText.SetActive(true);
    }
    public void key2Picked()
    {
        gameObject.GetComponent<AudioSource>().pitch = 1f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(gotKey, 1);
        StartCoroutine(key_2Picked());
        haveKey2 = true;
    }
}

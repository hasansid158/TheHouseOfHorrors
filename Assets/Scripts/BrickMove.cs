using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrickMove : MonoBehaviour
{

    public GameObject[] bricks;
    bool objFound = false;
    public GameObject Hammer;
    public GameObject InstructionText, brickbut, PickHambut;
    public Text txt;
    bool brickBreaked;
    public GameObject foundHam;
    public GameObject brickFall;
    public GameObject LockedDoor;
    public AudioClip HammerPicked;

    IEnumerator textTime()
    {
        gameObject.GetComponent<ObjectHint>().objTXT.SetActive(false);
        yield return new WaitForSeconds(5);
        txt.text = "";
        gameObject.GetComponent<ObjectHint>().objTXT.SetActive(true);
    }
    IEnumerator brickEnd()
    {
        yield return new WaitForSeconds(5);
        foreach (GameObject brick in bricks)
        {
            brick.SetActive(false);
        }
    }

    public void Brick_Breaker()
    {
        foreach (GameObject gObj in bricks)
        {
            if (objFound == false)
            {
                txt.text = "This wall here looks week,\nI can break it with something";
                InstructionText.SetActive(true);
                StartCoroutine("textTime");
                gameObject.GetComponent<ObjectHint>().objTXT.transform.GetChild(0).GetComponent<Text>().text =
                  "Find something to break the wall with";
            }
            else if (objFound == true)
            {
                gObj.GetComponent<Rigidbody>().isKinematic = false;
                gObj.GetComponent<Rigidbody>().AddForce(-250f, 0f, 0f, ForceMode.Force);
                StartCoroutine("brickEnd");
                brickBreaked = true;
                brickbut.SetActive(false);
                foundHam.SetActive(false);
                brickFall.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<ObjectHint>().objTXT.transform.GetChild(0).GetComponent<Text>().text =
        "Get inside the house and find the treasure";
            }
        }
    }

    public void HammerPickUp()
    {
        objFound = true;
        Destroy(Hammer);
        foundHam.SetActive(true);
        gameObject.GetComponent<AudioSource>().pitch = 0.5f;
        gameObject.GetComponent<AudioSource>().volume = 1f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(HammerPicked, 1);
        PickHambut.SetActive(false);
        gameObject.GetComponent<ObjectHint>().objTXT.transform.GetChild(0).GetComponent<Text>().text =
        "Break the wall with the hammer";
    }

    public void Locked_Main_Door()
    {
        txt.text = "The gate is locked...\nthere must be another way in";
        LockedDoor.GetComponent<AudioSource>().Play();

        if (brickBreaked == true)
        {
            txt.text = "The gate is locked";
        }

        InstructionText.SetActive(true);
        StartCoroutine("textTime"); ;
    }
}

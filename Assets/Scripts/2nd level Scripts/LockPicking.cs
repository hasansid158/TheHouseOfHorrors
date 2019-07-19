using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LockPicking : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool startPick = false, doPick = true, openDoor = false; 
    public GameObject lockAnim, gateCol, holdText, objText,LockpickIcon, fLight;
    public AudioClip Unlocked;

    public virtual void OnPointerDown(PointerEventData pData)
    {
        startPick = true;
        lockAnim.SetActive(true);
        holdText.SetActive(false);
    }

    public virtual void OnPointerUp(PointerEventData pData)
    {
        holdText.SetActive(true);
        startPick = false;
        doPick = true;
        lockAnim.SetActive(false);
        StopCoroutine("lockOpened");
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public IEnumerator lockOpened()
    {
        doPick = false;

        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
        lockAnim.GetComponent<Animation>().Play();        

        yield return new WaitForSeconds(7);

        gameObject.GetComponent<AudioSource>().PlayOneShot(Unlocked, 1);

        yield return new WaitForSeconds(1f);

        gateCol.SetActive(false);
        startPick = false;
        lockAnim.SetActive(false);
        openDoor = true;        
        doPick = true;
        LockpickIcon.SetActive(false);

        fLight.GetComponent<LightFlicker>().enabled = true;

        objText.GetComponent<Text>().text = "Find the treasure in the house";
    }

    void Update()
    {
        if (startPick)
        {
            if (doPick)
            {
                StartCoroutine("lockOpened");
            }
        }        
    }
}

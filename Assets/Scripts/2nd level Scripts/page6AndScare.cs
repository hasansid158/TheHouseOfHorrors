using UnityEngine;
using System.Collections;

public class page6AndScare : MonoBehaviour
{
    public GameObject ghostWindow, flashLight, page6, page6But, scare2Col, scareSoundObj, cam;
    bool fliker;
    public AudioClip jumpScareSound;

    IEnumerator lightOn()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        flashLight.GetComponent<Light>().intensity = 4.5f;

        if (fliker)
        {
            flashLight.GetComponent<Light>().intensity = 4.5f;
        }
        else
        {
            StartCoroutine(lightOn());
        }
    }

    IEnumerator lightOff()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        flashLight.GetComponent<Light>().intensity = 0.2f;

        if (fliker)
        {
            flashLight.GetComponent<Light>().intensity = 4.5f;
        }
        else
        {
            StartCoroutine(lightOff());
        }
    }

    IEnumerator ghostScare()
    {
        ghostWindow.SetActive(true);
        yield return new WaitForSeconds(1f);
        ghostWindow.SetActive(false);
        yield return new WaitForSeconds(1);
        fliker = true;
    }

    void Update()
    {
        if (gameObject.GetComponent<pageCollector>().page1Collected)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1.3f))
            {
                if (hit.collider.gameObject == page6)
                {
                    page6But.SetActive(true);
                }
                else
                {
                    page6But.SetActive(false);
                }
            }
            else
            {
                page6But.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == scare2Col)
        {
            scare2Col.SetActive(false);
            StartCoroutine(ghostScare());
            scareSoundObj.GetComponent<AudioSource>().PlayOneShot(jumpScareSound, 0.6f);
            StartCoroutine(lightOff());
            StartCoroutine(lightOn());
        }
    }
}

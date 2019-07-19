using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public GameObject ghost1;
    Vector3 rotTo;
    bool rotChecker1;
    public GameObject scareCont;
    public AudioClip scareSound, heartBeat;
    public GameObject flashLight;

    RaycastHit rayHit;
    Ray ray;
    float rayDist = 21;

    void Update()
    {
        if (!rotChecker1)
        {
            rotTo = gameObject.transform.position - ghost1.transform.position;
            ghost1.transform.rotation = Quaternion.LookRotation(-rotTo);
        }

        ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out rayHit, rayDist))
        {
            if (rayHit.collider.gameObject == ghost1)
            {
                ghost1.GetComponent<BoxCollider>().enabled = false;
                scareCont.GetComponent<AudioSource>().PlayOneShot(scareSound, 1);
                scareCont.GetComponent<AudioSource>().PlayOneShot(heartBeat, 1);
                flashLight.GetComponent<lightFlicking>().startFlick();
                StartCoroutine(ghostOff1());
            }
        }
    }

    IEnumerator ghostOff1()
    {
        yield return new WaitForSeconds(1.5f);
        ghost1.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(2);
        ghost1.SetActive(false);
        rotChecker1 = true;
        yield return new WaitForSeconds(2);
        flashLight.GetComponent<lightFlicking>().FlickOff = true;
    }
}

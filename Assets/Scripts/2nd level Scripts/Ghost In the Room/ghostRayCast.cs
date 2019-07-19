using UnityEngine;
using System.Collections;

public class ghostRayCast : MonoBehaviour
{
    RaycastHit hit;

    public GameObject cam, ghostRayCol, ghost, fLight;
    public AudioClip scareSound;

    IEnumerator disableGhost()
    {
        yield return new WaitForSeconds(0.5f);
        ghost.GetComponent<Animation>().Play("ghostRoomAnim");

        yield return new WaitForSeconds(0.4f);
        ghost.SetActive(false);

        yield return new WaitForSeconds(2);
        fLight.GetComponent<LightFlicker>().fliker = true;
    }

    void Update()
    {
        Vector3 lookTo = gameObject.transform.position - ghost.transform.position;
        ghost.transform.rotation = Quaternion.LookRotation(-lookTo);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.gameObject == ghostRayCol)
            {
                ghostRayCol.SetActive(false);
                ghost.SetActive(true);
                gameObject.GetComponent<AudioSource>().PlayOneShot(scareSound, 1);
                StartCoroutine("disableGhost");
                fLight.GetComponent<LightFlicker>().fliker = false;
                fLight.GetComponent<LightFlicker>().FlikOn = true;
                StartCoroutine(fLight.GetComponent<LightFlicker>().lighterflickerOn());
                StartCoroutine(fLight.GetComponent<LightFlicker>().lighterflickerOff());
            }
        }
    }
}

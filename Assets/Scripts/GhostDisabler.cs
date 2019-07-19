using UnityEngine;
using System.Collections;

public class GhostDisabler : MonoBehaviour
{
    public GameObject ghostDisabler;
    public GameObject ghost, Flight;
    public AudioClip SeenGhostSound;

    void Update() 
    {
        Vector3 lookTo = gameObject.transform.position - ghost.transform.position;
        ghost.transform.rotation = Quaternion.LookRotation(lookTo);
    }

    public IEnumerator endGhost()
    {
        yield return new WaitForSeconds(2f);
        ghost.SetActive(false);
        ghostDisabler.SetActive(false);
        yield return new WaitForSeconds(3);
        Flight.GetComponent<LightFlicker>().fliker = true;        
        
    }

    void OnTriggerEnter(Collider colides)
    {
        if (colides.gameObject == ghostDisabler)
        {
            seenGhost();
        }
    }

    public void seenGhost() 
    {
        gameObject.GetComponent<AudioSource>().pitch = 1f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(SeenGhostSound, 1f);
        ghost.SetActive(true);
        StartCoroutine(endGhost());
    }
}

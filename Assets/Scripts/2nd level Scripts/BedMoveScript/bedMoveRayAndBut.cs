using UnityEngine;
using System.Collections;

public class bedMoveRayAndBut : MonoBehaviour
{
    Ray ray;
    public GameObject bedMoveCol, page4Col;
    public GameObject bedMoveButton, page4But, pl, bed;
    public AudioClip moveSound;

    void Start() 
    {
    }

    void Update()
    {
        RaycastHit hit;

        if (pl.GetComponent<pageCollector>().page1Collected && Physics.Raycast(transform.position, transform.forward, out hit, 1.2f))
        {
            if (hit.collider.gameObject == bedMoveCol)
            {
                bedMoveButton.SetActive(true);
            }

            if (hit.collider.gameObject == page4Col)
            {
                page4But.SetActive(true);
            }
        }

        else
        {
            bedMoveButton.SetActive(false);
            page4But.SetActive(false);
        }
    }

    public void moveBed() 
    { 
        bed.GetComponent<Animation>().Play("bedMove");
        bed.GetComponent<AudioSource>().PlayOneShot(moveSound, 0.9f);
        bedMoveCol.SetActive(false);
    }
}

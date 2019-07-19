using UnityEngine;
using System.Collections;

public class waterScript : MonoBehaviour
{
    public GameObject water, waterCol, waterBut, paper5, paper5But;
    public AudioClip waterSound;
    bool takePaper = false;
    public bool waterOff = false;

    void Update()
    {
        if (transform.parent.GetComponent<pageCollector>().page1Collected)
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 1.8f))
            {
                if (hit.collider.gameObject == waterCol)
                {
                    waterBut.SetActive(true);
                }

                else if (takePaper)
                {
                    if (hit.collider.gameObject == paper5)
                    {
                        paper5But.SetActive(true);
                    }
                }
                else 
                {
                    waterBut.SetActive(false);
                    paper5But.SetActive(false);
                }
            }
            else
            {
                waterBut.SetActive(false);
                paper5But.SetActive(false);
            }            
        }
    }

    IEnumerator waterTime() 
    {
        yield return new WaitForSeconds(4);
        takePaper = true;
    }

    public void waterAnimStart()
    {
        waterCol.SetActive(false);
        waterOff = true;
        StartCoroutine(waterTime());
        water.GetComponent<AudioSource>().PlayOneShot(waterSound, 1);
        water.GetComponent<Animation>().Play("waterAnim");        
    }
}

using UnityEngine;
using System.Collections;

public class LampScare : MonoBehaviour {

    public GameObject lampOnCollider, lampOffCollider, lamp, lampLight;
    bool loopLight;
    public float lightSpeed;

	IEnumerator lightOnOff() 
    {
        lampLight.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(lightSpeed);
        lampLight.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(lightSpeed);

        if(loopLight) 
        {
            lampLight.SetActive(false);
        }
        else
        {
            StartCoroutine(lightOnOff());
        }
	}

    void OnTriggerEnter(Collider col) 
    { 
        if(col.gameObject == lampOnCollider) 
        {
            lampOnCollider.SetActive(false);
            lampOffCollider.SetActive(true);
            lampLight.SetActive(true);
            lamp.GetComponent<AudioSource>().Play();
            StartCoroutine("lightOnOff");
        }

        else if(col.gameObject == lampOffCollider) 
        {
            lampOffCollider.SetActive(false);
            loopLight = true;
            lamp.GetComponent<AudioSource>().Stop();
        }
    }
}

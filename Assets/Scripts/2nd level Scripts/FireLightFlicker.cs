using UnityEngine;
using System.Collections;

public class FireLightFlicker : MonoBehaviour
{

    public float min, min1, max, max1;
    public GameObject lite;

    IEnumerator FireFlick()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            gameObject.GetComponent<Light>().intensity = Random.Range(0.8f, 1.5f);
        }
    }

    IEnumerator FireFlick2() 
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min1, max1));
            lite.GetComponent<Light>().intensity = Random.Range(0.8f, 1.5f);
        }
    }

    void Start()
    {
        StartCoroutine(FireFlick());
        StartCoroutine(FireFlick2());
    }
}

using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public float min, max, min1, max1;
    public bool fliker, FlikOn = true;

    public IEnumerator lighterflickerOn()
    {
        while (FlikOn)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            gameObject.GetComponent<Light>().intensity = 4.5f;

            if(fliker) 
            {
                gameObject.GetComponent<Light>().intensity = 4.5f;
                FlikOn = false;
            }
        }
    }

    public IEnumerator lighterflickerOff()
    {
        while (FlikOn)
        {
            yield return new WaitForSeconds(Random.Range(min1, max1));
            gameObject.GetComponent<Light>().intensity = 0.2f;

            if (fliker)
            {
                gameObject.GetComponent<Light>().intensity = 4.5f;
                FlikOn = false;
            }
        }
    }

    void Start()
    {
        StartCoroutine(lighterflickerOn());
        StartCoroutine(lighterflickerOff());
    }
}

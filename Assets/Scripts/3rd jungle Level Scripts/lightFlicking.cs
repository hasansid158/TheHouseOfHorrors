using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicking : MonoBehaviour
{
    bool Flick = true;
    public bool FlickOff;

    public void startFlick()
    {
        FlickOff = false;
        StartCoroutine(lighterflickerOn());
        StartCoroutine(lighterflickerOff());
    }

    IEnumerator lighterflickerOn()
    {

        while (Flick)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            GetComponent<Light>().enabled = true;

            if (FlickOff)
            {
                Flick = false;
                GetComponent<Light>().enabled = true;
            }
        }
    }

    IEnumerator lighterflickerOff()
    {

        while (Flick)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            GetComponent<Light>().enabled = false;

            if (FlickOff)
            {
                Flick = false;
                GetComponent<Light>().enabled = true;
            }
        }
    }
}

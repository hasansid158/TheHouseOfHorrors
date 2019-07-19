using UnityEngine;
using System.Collections;

public class waterOnOff : MonoBehaviour
{
    public GameObject waterOn, waterOff, water, cam;

    void OnTriggerEnter(Collider col)
    {
        if (!cam.GetComponent<waterScript>().waterOff)
        {
            if (col.gameObject == waterOff)
            {
                water.SetActive(false);
            }

            else if (col.gameObject == waterOn)
            {
                water.SetActive(true);
            }
        }
    }
}

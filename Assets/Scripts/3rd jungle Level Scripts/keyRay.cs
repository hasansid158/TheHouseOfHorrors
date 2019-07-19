using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyRay : MonoBehaviour
{
    RaycastHit rayHit;
    Ray ray;
    public GameObject keyPickUpBut;

    [HideInInspector]
    public GameObject key;

    void Update()
    {
        ray = new Ray(gameObject.transform.position, transform.forward);
        
        if(Physics.Raycast(ray, out rayHit, 1.2f))
        {
            if(rayHit.collider.tag == "keys")
            {
                keyPickUpBut.SetActive(true);
                key = rayHit.collider.gameObject;
            }
            else
            {
                keyPickUpBut.SetActive(false);
            }
        }
        else
        {
            keyPickUpBut.SetActive(false);
        }
    }
}

using UnityEngine;
using System.Collections;

public class StartChildSound : MonoBehaviour {

    public GameObject SoundStarter;

    void OnTriggerEnter(Collider col) 
    { 
        if(col.gameObject == SoundStarter) 
        {
            SoundStarter.GetComponent<AudioSource>().Play();
            SoundStarter.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

using UnityEngine;
using System.Collections;

public class WolfScript : MonoBehaviour 
{
    public GameObject pl;
    	
	void Update () 
    {
        gameObject.transform.position = Vector3.MoveTowards(new Vector3( gameObject.transform.position.x, 1.174f, gameObject.transform.position.z), new Vector3(pl.transform.position.x, 1.174f, pl.transform.position.z), 2 * Time.deltaTime);

        Vector3 lookTo = pl.transform.position - gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.LookRotation(lookTo);
	}
}

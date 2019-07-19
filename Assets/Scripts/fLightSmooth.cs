using UnityEngine;
using System.Collections;

public class fLightSmooth : MonoBehaviour
{

    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Camera.main.transform.position, 18f * Time.deltaTime);
    }

    void LateUpdate() 
    {
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Camera.main.transform.rotation, 15f * Time.deltaTime);
    }
}

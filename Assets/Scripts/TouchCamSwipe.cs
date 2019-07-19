using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchCamSwipe : MonoBehaviour
{
    float touchY, touchX;
    public float touchSensitivity;
    public GameObject player;

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount >= MobileAnalog.tCount)
            {
                foreach (Touch tch in Input.touches)
                {
                    if (tch.position.x > Screen.width / 2.5)
                    {
                        touchX = tch.FixedTouchDelta().x * touchSensitivity * Time.deltaTime;
                        touchY += tch.FixedTouchDelta().y * touchSensitivity * Time.deltaTime;
                        touchY = Mathf.Clamp(touchY, -90, 90);

                        PlayerControling.mouseX = touchX;
                        PlayerControling.mouseY = touchY;

                        player.transform.Rotate(0f, touchX, 0f);
                        gameObject.transform.localRotation = Quaternion.Euler(-touchY, 0f, 0f);                        
                    }
                }
            }
        }
    }
}

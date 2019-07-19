using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchSprint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool Run;
    public GameObject PL;
    Vector3 sprinter, camPos;
    public GameObject cam;
    float a;

    public virtual void OnPointerDown(PointerEventData pData)
    {
        gameObject.GetComponent<AudioSource>().pitch = 1.55f;
        gameObject.GetComponent<AudioSource>().volume = 0.85f;
        gameObject.GetComponent<AudioSource>().Play();

        Run = true;
    }

    public virtual void OnPointerUp(PointerEventData pData)
    {
        gameObject.GetComponent<AudioSource>().Stop();
        Run = false;
    }

    void Start()
    {
        Run = false;
        camPos = new Vector3(0f, 0.68f, 0f);
    }

    void Update()
    {
        if (!PlayerControling.animStart)
        {
            if (Run)
            {
                if (a <= 1)
                {
                    a += 3f * Time.deltaTime;
                }

                cam.GetComponent<Animation>().Play("HeadBob");
            }

            else if (!Run)
            {
                if (a >= 0)
                {
                    a -= 2f * Time.deltaTime;
                }

                cam.GetComponent<Animation>().Stop("HeadBob");
                cam.transform.localPosition = camPos;
            }
        }

        sprinter = new Vector3(0, 0, a);
        sprinter = PL.transform.rotation * sprinter;

        if (a > 0)
        {
            PL.GetComponent<CharacterController>().SimpleMove(sprinter * 6);
        }
    }
}

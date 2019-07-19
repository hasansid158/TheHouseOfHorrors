using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileAnalog : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Image bgImage;
    Image jImage;
    public static int tCount;
    public static Vector3 analogMov;

    void Start()
    {
        bgImage = GetComponent<Image>();
        jImage = transform.GetChild(2).GetComponent<Image>();
        analogMov = Vector3.zero;
    }


    public virtual void OnDrag(PointerEventData pData)
    {
        //Making tounch count as 1 so we dont mix it with movement touches and the other touch will become 0 
        tCount = 1;

        //jPas is for joystick position and asigning it vector 0 so it starts from zero
        Vector2 jPos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform,
        pData.position,
        pData.pressEventCamera,
        out jPos))
        {
            //dividing and assigning the value from the size of analog UI image
            jPos.x = (jPos.x / bgImage.rectTransform.sizeDelta.x);
            jPos.y = (jPos.y / bgImage.rectTransform.sizeDelta.y);

            //Checking the position of UI image position and asining positive or negative value with addition of 3
            float posxx = (bgImage.rectTransform.pivot.x == 1) ? jPos.x * 3 + 1 : jPos.x * 3 - 1;
            float posyy = (bgImage.rectTransform.pivot.y == 1) ? jPos.y * 3 + 1 : jPos.y * 3 - 1;

            analogMov = new Vector3(posxx, 0, posyy);
            //checking if the magnitude of the analog is greater than 1 then we normalize it so it does not go out
            analogMov = (analogMov.magnitude > 1) ? analogMov.normalized : analogMov;

            //changing the position of analog front pad image with the value of analogMov and multipled by background image that is divided by 3 so that it stays in border
            jImage.rectTransform.anchoredPosition = new Vector3(analogMov.x * (bgImage.rectTransform.sizeDelta.x / 3),
            analogMov.z * (bgImage.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData pData)
    {
        gameObject.GetComponent<AudioSource>().pitch = 1f;
        gameObject.GetComponent<AudioSource>().volume = 0.5f;
        gameObject.GetComponent<AudioSource>().Play();

        OnDrag(pData);
    }

    public virtual void OnPointerUp(PointerEventData pData)
    {
        gameObject.GetComponent<AudioSource>().Stop();
        tCount = 0;
        analogMov = Vector3.zero;
        jImage.rectTransform.anchoredPosition = Vector3.zero;

    }
}

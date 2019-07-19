using UnityEngine;
using System.Collections;

public class paintAnimStarter : MonoBehaviour {

    public GameObject paint1Col, paint2, paint2Col, paint3, paint3Col, fL, code1Txt, code2Txt, page3Col;

    public void startAnim() 
    {
        gameObject.GetComponent<Animation>().Play("paitingAnim");
        paint1Col.SetActive(false);
    }

    public void startAnim2()
    {
        paint2.GetComponent<Animation>().Play("paintAnim2");
        paint2Col.SetActive(false);
    }

    IEnumerator pageColOn() 
    {
        yield return new WaitForSeconds(1);
        page3Col.SetActive(true);
    }

    public void startAnim3()
    {
        paint3.GetComponent<Animation>().Play("paintAnim3");
        paint3Col.SetActive(false);
        StartCoroutine("pageColOn");
    }
}

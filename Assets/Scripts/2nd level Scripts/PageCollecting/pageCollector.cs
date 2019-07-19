using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pageCollector : MonoBehaviour {

    public GameObject page1, page2, page3, page4, page5, page6, slab, pageSoundObj, slabButtonCol, bed1CloseCldr, bed1Door, lampOnCol, windowScareCol;
    public AudioClip slabSound, pageSound;
    public Text objText, talkText;
    public int pageNum = 1;
    public bool page1Collected, page4Collected;

    public void page1Picked()
    {
        pageSoundObj.GetComponent<AudioSource>().PlayOneShot(pageSound, 1);
        page1Collected = true;
        page1.SetActive(false);
        StartCoroutine("pageTxt");
        bed1CloseCldr.SetActive(true);
        bed1Door.GetComponent<BedRoomDoorOpener>().openDoorsBed1 = false;
        windowScareCol.SetActive(true);
    }

    IEnumerator pageTxt() 
    {
        objText.text = "Find and collect all pages  " + pageNum + "/6";

        talkText.text = "This is a torn up page which contain some numbers\nMaybe it contains the safe code";
        yield return new WaitForSeconds(6);
        talkText.text = "";
    }

    public void moveSlab() 
    {
        slabButtonCol.SetActive(false);
        slab.GetComponent<Animation>().Play("kitchenSlabAnim");
        slab.GetComponent<AudioSource>().PlayOneShot(slabSound,0.8f);
    }

    public void page2Picked() 
    {
        if (page1Collected)
        {
            pageSoundObj.GetComponent<AudioSource>().PlayOneShot(pageSound, 1);
            pageNum++;
            objText.text = "Find and collect all pages  " + pageNum + "/6";

            page2.SetActive(false);

            if (pageNum == 6)
            {
                StartCoroutine("gotAllPages");
            }
        }
    }

    public void page3Picked()
    {
        if (page1Collected)
        {
            pageSoundObj.GetComponent<AudioSource>().PlayOneShot(pageSound, 1);
            pageNum++;
            objText.text = "Find and collect all pages  " + pageNum + "/6";

            page3.SetActive(false);

            if (pageNum == 6)
            {
                StartCoroutine("gotAllPages");
            }
        }
    }

    public void page4Picked()
    {
        if (page1Collected)
        {
            page4Collected = true;
            pageSoundObj.GetComponent<AudioSource>().PlayOneShot(pageSound, 1);
            pageNum++;
            objText.text = "Find and collect all pages  " + pageNum + "/6";

            page4.SetActive(false);
            lampOnCol.SetActive(true);

            if (pageNum == 6)
            {
                StartCoroutine("gotAllPages");
            }
        }
    }

    public void page5Picked()
    {
        if (page1Collected)
        {
            pageSoundObj.GetComponent<AudioSource>().PlayOneShot(pageSound, 1);
            pageNum++;
            objText.text = "Find and collect all pages  " + pageNum + "/6";

            page5.SetActive(false);

            if(pageNum == 6) 
            {
                StartCoroutine("gotAllPages");
            }
        }
    }

    public void page6Picked()
    {
        if (page1Collected)
        {
            pageSoundObj.GetComponent<AudioSource>().PlayOneShot(pageSound, 1);
            pageNum++;
            objText.text = "Find and collect all pages  " + pageNum + "/6";

            page6.SetActive(false);

            if (pageNum == 6)
            {
                StartCoroutine("gotAllPages");
            }
        }
    }

    public IEnumerator gotAllPages() 
    {
        talkText.text = "Only 2 digits number was in those pages,\nI have to find the other 2 digits.";
        objText.gameObject.transform.parent.gameObject.SetActive(false);

        yield return new WaitForSeconds(7);

        objText.gameObject.transform.parent.gameObject.SetActive(true);
        objText.text = "Code found is 6 and 3 find Other 2 digits and open the save.";
        talkText.text = "";
    }
}

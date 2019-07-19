using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goingToLadder : MonoBehaviour
{
    public GameObject ladderCol, ladderBut, cam, talkText, objText, loading;

    IEnumerator ladderText()
    {
        talkText.GetComponent<Text>().text = "I need to find a gun first before I go in the forest";
        yield return new WaitForSeconds(7);
        objText.GetComponent<Text>().text = "find a gun and then use the ladder";
        talkText.GetComponent<Text>().text = "";
    }

    IEnumerator loadNext()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
    }

    public void toLadder()
    {
        if (gameObject.GetComponent<secretRoomDoorLock>().gotGun)
        {
            ladderCol.SetActive(false);
            StartCoroutine(loadNext());
        }
        else
        {
            StopCoroutine(ladderText());
            StartCoroutine(ladderText());
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<secretRoomDoorLock>().gotKeyPage)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1.2f))
            {
                if (hit.collider.gameObject == ladderCol)
                {
                    ladderBut.SetActive(true);
                }
                else
                {
                    ladderBut.SetActive(false);
                }
            }
            else
            {
                ladderBut.SetActive(false);
            }
        }
    }
}

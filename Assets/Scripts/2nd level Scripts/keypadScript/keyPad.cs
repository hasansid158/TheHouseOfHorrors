using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class keyPad : MonoBehaviour
{
    public Text digit1, digit2, digit3, digit4;
    public GameObject wrong, right, keyPadObject, cam, talkText, objText, safeDoor, colKepad, smallRoomKey;
    public GameObject[] UI;
    public AudioClip beep;

    bool runOnce = true;

    public void button1()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "1";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "1";
            }

            else if (digit3.text == "")
            {
                digit3.text = "1";
            }

            else if (digit4.text == "")
            {
                digit4.text = "1";
            }
        }
    }

    public void button2()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "2";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "2";
            }

            else if (digit3.text == "")
            {
                digit3.text = "2";
            }

            else if (digit4.text == "")
            {
                digit4.text = "2";
            }
        }
    }

    public void button3()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "3";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "3";
            }

            else if (digit3.text == "")
            {
                digit3.text = "3";
            }

            else if (digit4.text == "")
            {
                digit4.text = "3";
            }
        }
    }

    public void button4()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "4";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "4";
            }

            else if (digit3.text == "")
            {
                digit3.text = "4";
            }

            else if (digit4.text == "")
            {
                digit4.text = "4";
            }
        }
    }

    public void button5()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "5";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "5";
            }

            else if (digit3.text == "")
            {
                digit3.text = "5";
            }

            else if (digit4.text == "")
            {
                digit4.text = "5";
            }
        }
    }

    public void button6()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "6";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "6";
            }

            else if (digit3.text == "")
            {
                digit3.text = "6";
            }

            else if (digit4.text == "")
            {
                digit4.text = "6";
            }
        }
    }

    public void button7()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "7";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "7";
            }

            else if (digit3.text == "")
            {
                digit3.text = "7";
            }

            else if (digit4.text == "")
            {
                digit4.text = "7";
            }
        }
    }

    public void button8()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "8";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "8";
            }

            else if (digit3.text == "")
            {
                digit3.text = "8";
            }

            else if (digit4.text == "")
            {
                digit4.text = "8";
            }
        }
    }

    public void button9()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "9";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "9";
            }

            else if (digit3.text == "")
            {
                digit3.text = "9";
            }

            else if (digit4.text == "")
            {
                digit4.text = "9";
            }
        }
    }

    public void button0()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        if (digit1.text == "")
        {
            digit1.text = "0";
        }
        else if (digit1.text != "")
        {
            if (digit2.text == "")
            {
                digit2.text = "0";
            }

            else if (digit3.text == "")
            {
                digit3.text = "0";
            }

            else if (digit4.text == "")
            {
                digit4.text = "0";
            }
        }
    }

    IEnumerator rightCode()
    {
        gameObject.GetComponent<AudioSource>().pitch = 1.1f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);
        yield return new WaitForSeconds(0.12f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);
        yield return new WaitForSeconds(0.12f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);


        yield return new WaitForSeconds(1);
        keyPadObject.SetActive(false);

        digit1.text = "";
        digit2.text = "";
        digit3.text = "";
        digit4.text = "";
        wrong.SetActive(false);
        right.SetActive(false);

        foreach (GameObject uis in UI)
        {
            uis.SetActive(true);
        }
        cam.GetComponent<TouchCamSwipe>().enabled = true;
        gameObject.GetComponent<PlayerControling>().enabled = true;
        safeDoor.GetComponent<AudioSource>().Play();
        safeDoor.GetComponent<Animation>().Play();
        smallRoomKey.SetActive(true);
    }

    IEnumerator wrongCode()
    {
        yield return new WaitForSeconds(0.4f);
        wrong.SetActive(true);

        gameObject.GetComponent<AudioSource>().pitch = 0.6f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(beep, 1);

        yield return new WaitForSeconds(2);
        gameObject.GetComponent<AudioSource>().pitch = 1f;

        keyPadObject.SetActive(false);

        digit1.text = "";
        digit2.text = "";
        digit3.text = "";
        digit4.text = "";
        wrong.SetActive(false);
        right.SetActive(false);

        foreach (GameObject uis in UI)
        {
            uis.SetActive(true);
        }
        cam.GetComponent<TouchCamSwipe>().enabled = true;
        gameObject.GetComponent<PlayerControling>().enabled = true;

        if (gameObject.GetComponent<pageCollector>().pageNum == 6)
        {
            StartCoroutine(gameObject.GetComponent<pageCollector>().gotAllPages());
        }
        else if(gameObject.GetComponent<pageCollector>().page1Collected)
        {
            talkText.GetComponent<Text>().text = "I don't know the code yet,\nmaybe the save contain the treasure I am searching for.";
        }
        else
        {
            talkText.GetComponent<Text>().text = "I don't know the code yet,\nmaybe the save contain the treasure I am searching for.";
            objText.GetComponent<Text>().text = "Find the safe code";
        }

        yield return new WaitForSeconds(6);
        talkText.GetComponent<Text>().text = "";
    }

    void Update()
    {
        if (digit1.text != "" && digit2.text != "" && digit3.text != "" && digit4.text != "")
        {
            if (runOnce && digit1.text == "6" && digit2.text == "3" && digit3.text == "0" && digit4.text == "7" && gameObject.GetComponent<pageCollector>().pageNum == 6)
            {
                colKepad.SetActive(false);
                right.SetActive(true);
                StartCoroutine("rightCode");
                runOnce = false;
            }

            else
            {
                if (runOnce)
                {
                    StopCoroutine("wrongCode");
                    StartCoroutine("wrongCode");
                    runOnce = false;
                }
            }
        }
    }

    public void startKeypad()
    {
        foreach (GameObject uis in UI)
        {
            uis.SetActive(false);
        }
        cam.GetComponent<TouchCamSwipe>().enabled = false;
        gameObject.GetComponent<PlayerControling>().enabled = false;
        talkText.GetComponent<Text>().text = "";

        keyPadObject.SetActive(true);
        runOnce = true;
    }
}

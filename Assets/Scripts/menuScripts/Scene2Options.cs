using UnityEngine;
using System.Collections;

public class Scene2Options : MonoBehaviour {

    public GameObject brightMenu, touchMenu, analog, pl, sprint, cam, lightButton, talkTxt, ObjectTxt, pauseBut, QualitySet, Blur;

    public void OptionOn()
    {
        gameObject.SetActive(true);
        Blur.SetActive(true);

        analog.SetActive(false);
        sprint.SetActive(false);
        lightButton.SetActive(false);
        talkTxt.SetActive(false);
        ObjectTxt.SetActive(false);
        pauseBut.SetActive(false);
        pl.GetComponent<PlayerControling>().enabled = false;
        cam.GetComponent<TouchCamSwipe>().enabled = false;

        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void OptionOff()
    {
        gameObject.SetActive(false);
        Blur.SetActive(false);

        analog.SetActive(true);
        sprint.SetActive(true);
        lightButton.SetActive(true);
        talkTxt.SetActive(true);
        ObjectTxt.SetActive(true);
        pauseBut.SetActive(true);
        pl.GetComponent<PlayerControling>().enabled = true;
        cam.GetComponent<TouchCamSwipe>().enabled = true;

        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    public void BrightOn()
    {
        brightMenu.SetActive(true);
        Blur.SetActive(false);
    }

    public void BrightOff()
    {
        Blur.SetActive(true);
        brightMenu.SetActive(false);
    }

    public void TouchOn()
    {
        touchMenu.SetActive(true);
    }

    public void TouchOff()
    {
        touchMenu.SetActive(false);
    }

    public void QualityOn()
    {
        QualitySet.SetActive(true);
    }

    public void QualityOff()
    {
        QualitySet.SetActive(false);
    }
}

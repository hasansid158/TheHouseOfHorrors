using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StandAnimStarter : MonoBehaviour
{

    public GameObject[] ui;
    public GameObject pl, Speaktxt, fLight, bgSound2, flikerSound, CurrentQuality, fadder;
    bool doFade = true;

    IEnumerator fadeWait() 
    {
        yield return new WaitForSeconds(1.5f);
        doFade = false;
        fadder.SetActive(false);
    }

    void Update()
    {
        if (doFade)
        {
            fadder.GetComponent<Image>().CrossFadeAlpha(0, 16 * Time.deltaTime, false);
        }
    }

    void Start()
    {
        StartCoroutine(fadeWait());

        AudioListener.pause = false;
        StartCoroutine(Starting());
        fLight.GetComponent<flashLightOnOF>().Scene2 = true;
        bgSound2.GetComponent<AudioSource>().Play();
        flikerSound.GetComponent<AudioSource>().Play();

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("SavedQuality"));
        gameObject.GetComponent<TouchCamSwipe>().touchSensitivity = PlayerPrefs.GetInt("SavedLook");
        RenderSettings.ambientSkyColor = new Color(PlayerPrefs.GetInt("SavedVal"), PlayerPrefs.GetInt("SavedVal"), PlayerPrefs.GetInt("SavedVal"));

        if (PlayerPrefs.GetInt("SavedQuality") == 0)
        {
            CurrentQuality.GetComponent<Text>().text = "Current Quality = Low";
        }

        else if (PlayerPrefs.GetInt("SavedQuality") == 1)
        {
            CurrentQuality.GetComponent<Text>().text = "Current Quality = Medium";
        }

        else if (PlayerPrefs.GetInt("SavedQuality") == 2)
        {
            CurrentQuality.GetComponent<Text>().text = "Current Quality = High";
        }
    }

    IEnumerator Starting()
    {
        gameObject.GetComponent<TouchCamSwipe>().enabled = false;
        pl.GetComponent<PlayerControling>().enabled = false;
        gameObject.GetComponent<Animation>().Play("standAnim");

        yield return new WaitForSeconds(5);

        foreach (GameObject uis in ui)
        {
            uis.SetActive(true);
            gameObject.GetComponent<TouchCamSwipe>().enabled = true;
            pl.GetComponent<PlayerControling>().enabled = true;
        }

        yield return new WaitForSeconds(1);

        Speaktxt.GetComponent<Text>().text = "Something just threw me out of the house !";
        yield return new WaitForSeconds(4f);
        Speaktxt.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1f);

        Speaktxt.GetComponent<Text>().text = "I need to get inside the house somehow.";
        yield return new WaitForSeconds(5f);
        Speaktxt.GetComponent<Text>().text = "";

        Speaktxt.SetActive(true);
    }
}

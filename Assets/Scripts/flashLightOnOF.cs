using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class flashLightOnOF : MonoBehaviour
{

    Light lite;
    public GameObject img, lightModel, litebut, light1, Objtxt, flickerSound, lightspark, bulbBreakSound;
    public Image offImg;
    public Image OnImg;
    public static bool haveLight;
    bool Flick = true, FlickOff;
    public bool Scene2 = false, lightpicked = false;
    public AudioClip lightOn, lightOff, lightpickedSound, lightPop;

    void Start()
    {
        lite = gameObject.GetComponent<Light>();
        StartCoroutine(lighterflickerOn());
        StartCoroutine(lighterflickerOff());
    }

    IEnumerator lighterflickerOn()
    {
        if (Scene2)
        {
            while (Flick)
            {

                yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
                light1.SetActive(true);


                if (FlickOff)
                {
                    Flick = false;
                    light1.SetActive(false);
                }
            }
        }
    }

    IEnumerator lighterflickerOff()
    {
        if (Scene2)
        {
            while (Flick)
            {


                yield return new WaitForSeconds(Random.Range(0.1f, 1f));
                light1.SetActive(false);


                if (FlickOff)
                {
                    Flick = false;
                    light1.SetActive(false);
                }
            }
        }
    }

    IEnumerator StreetOff()
    {
        yield return new WaitForSeconds(1);
        lightpicked = true;
        flickerSound.GetComponent<AudioSource>().Stop();
        lightspark.GetComponent<ParticleSystem>().Play();
        bulbBreakSound.GetComponent<AudioSource>().Play();
        FlickOff = true;

    }

    public void lightPicked()
    {
        Destroy(lightModel);
        litebut.SetActive(false);
        gameObject.GetComponent<AudioSource>().PlayOneShot(lightpickedSound, 1);
        haveLight = true;
        img.SetActive(true);
        if (Scene2)
        {
            StartCoroutine(StreetOff());

            Objtxt.GetComponent<Text>().text = "Get inside the house again";
        }
    }

    public void lighter()
    {
        if (haveLight)
        {
            lite.enabled = !lite.enabled;


            if (lite.enabled)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                gameObject.GetComponent<AudioSource>().PlayOneShot(lightOn, 1);
            }
            else
            {
                gameObject.GetComponent<AudioSource>().Stop();
                gameObject.GetComponent<AudioSource>().PlayOneShot(lightOff, 1);
            }
        }
    }

    void Update()
    {
        if (haveLight)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                lite.enabled = !lite.enabled;

                if (lite.enabled)
                {
                    gameObject.GetComponent<AudioSource>().Stop();
                    gameObject.GetComponent<AudioSource>().PlayOneShot(lightOn, 1);
                }
                else
                {
                    gameObject.GetComponent<AudioSource>().Stop();
                    gameObject.GetComponent<AudioSource>().PlayOneShot(lightOff, 1);
                }
            }

            img.GetComponent<Image>().enabled = true;
        }
        else if (!haveLight)
        {
            img.GetComponent<Image>().enabled = false;
            lite.enabled = false;
        }

        if (!lite.enabled)
        {
            img.GetComponent<Image>().sprite = offImg.sprite;
        }
        else if (lite.enabled)
        {
            img.GetComponent<Image>().sprite = OnImg.sprite;
        }
    }
}

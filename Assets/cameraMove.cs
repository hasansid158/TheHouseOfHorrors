using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cameraMove : MonoBehaviour
{

    public GameObject obj1;
    public GameObject obj2, loadSc, blood;
    int starter = 0;
    public AudioClip nextSound;
    public AudioClip backSound;
    public Light light1, light2;
    public float min, max, min1, max1;

    void Start()
    {


        AudioListener.pause = false;
        loadSc.SetActive(false);
        gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
        StartCoroutine(lighterflickerOn());
        StartCoroutine(lighterflickerOff());
    }

    public void CamMove()
    {
        gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(nextSound, 1);
        starter = 1;
    }

    public void CamBack()
    {
        gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(backSound, 1);
        starter = 2;
    }

    IEnumerator lighterflickerOn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            light1.enabled = true;
            light2.enabled = true;
            blood.SetActive(true);
        }
    }

    IEnumerator lighterflickerOff()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min1, max1));
            light1.enabled = false;
            light2.enabled = false;
            blood.SetActive(false);

        }
    }

    void Update()
    {
        if (starter == 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, obj1.transform.rotation, Time.deltaTime * 1.4f);
            transform.position = Vector3.Lerp(transform.position, obj1.transform.position, Time.deltaTime * 1.4f);
        }

        if (starter == 2)
        {
            transform.position = Vector3.Lerp(transform.position, obj2.transform.position, Time.deltaTime * 1.8f);
            transform.rotation = Quaternion.Lerp(transform.rotation, obj2.transform.rotation, Time.deltaTime * 1.8f);
        }
    }

    IEnumerator startLoad() 
    {
        yield return new WaitForSeconds(0.5f);
        loadSc.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }

    public void newGame()
    {
        StartCoroutine("startLoad");
    }
}

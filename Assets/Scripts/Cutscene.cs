using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{

    public GameObject GhostPos, PlayerControls, sound;
    public GameObject[] UI;
    public AudioClip end, creditSound, scareSoundWomen;
    public AudioSource bgAudio;
    public GameObject pl, loadingSC;
    bool StartStop, startGhost;
    float speed;

    public void StartCut()
    {
        StartStop = true;
        PlayerControls.GetComponent<PlayerControling>().enabled = false;
        gameObject.GetComponent<TouchCamSwipe>().enabled = false;
        gameObject.GetComponent<Animation>().enabled = false;
        bgAudio.Stop();
        sound.SetActive(false);

        Vector3 pos = pl.transform.position - GhostPos.transform.position;
        GhostPos.transform.rotation = Quaternion.LookRotation(-pos);

        StartCoroutine(CutSceneStarter());
    }

    void Update()
    {        
        if (StartStop)
        {
            foreach (GameObject ui in UI)
            {
                ui.SetActive(false);
            }
        }
        if(startGhost) 
        {
            GhostPos.transform.position = Vector3.MoveTowards(GhostPos.transform.position, pl.transform.position, 17 * Time.deltaTime);
        }
    }

    IEnumerator CutSceneStarter()
    {
        gameObject.GetComponent<AudioSource>().volume = 1f;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(creditSound, 1);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.LookAt(GhostPos.transform);
        yield return new WaitForSeconds(1);
        GhostPos.SetActive(true);
        startGhost = true;
        gameObject.GetComponent<AudioSource>().PlayOneShot(scareSoundWomen, 1);
        yield return new WaitForSeconds(0.6f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(end, 1);
        gameObject.GetComponent<Animation>().enabled = true;
        gameObject.GetComponent<Animation>().Play("DyingAnimation");
        yield return new WaitForSeconds(1.7f);
        loadingSC.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(2);
    }
}

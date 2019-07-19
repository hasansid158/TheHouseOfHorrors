using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour {

	public GameObject cam, camMovePos, playText, playBut, balls, basket, allCanvas, soundCont;
	public bool started,fade, startPressed;
	public AudioClip buttonSound;

	IEnumerator startedTimer()
	{
		fade = true;
		balls.GetComponent<Animation> ().Play ("startBallsAnim");
		yield return new WaitForSeconds (1);
		playBut.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		balls.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		started = true;
		startPressed = true;
		allCanvas.SetActive (true);
		yield return new WaitForSeconds (1f);
		basket.SetActive (false);
	}

	void Update()
	{
		if (fade) 
		{
			playText.GetComponent<Text> ().CrossFadeAlpha (0, 5 * Time.deltaTime, false);
		}
		
		if (started) {
			cam.transform.position = Vector3.Lerp (cam.transform.position, camMovePos.transform.position, 4f * Time.deltaTime);
			cam.transform.rotation = Quaternion.Lerp (cam.transform.rotation, camMovePos.transform.rotation, 4f * Time.deltaTime);
		}
	}

	public void startBut()
	{
		soundCont.GetComponent<AudioSource> ().PlayOneShot (buttonSound, 1);
		StartCoroutine (startedTimer ());
	}
}

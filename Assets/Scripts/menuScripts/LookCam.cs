using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LookCam : MonoBehaviour {

    public float Value = 10f;
    public Text Btxt;
    public GameObject cam, sliderCam;

    void Start() 
    {
        Value = PlayerPrefs.GetFloat("SavedLook");

        if (Value == 0) 
        {
            Value = 10f;
        }

        sliderCam.GetComponent<Slider>().value = Value;
    }

    void Update()
    {
        Value = sliderCam.GetComponent<Slider>().value;

        PlayerPrefs.SetFloat("SavedLook", Value);

        Btxt.text = Value.ToString("0");

        cam.GetComponent<TouchCamSwipe>().touchSensitivity = Value;
    }

    public void defaultValue()
    {
        sliderCam.GetComponent<Slider>().value = 10f;
    }
}

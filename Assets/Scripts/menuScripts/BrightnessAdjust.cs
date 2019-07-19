using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrightnessAdjust : MonoBehaviour
{
    public float Value;
    public Text Btxt;
    public GameObject sliderBright;

    void Start() 
    {
        Value = PlayerPrefs.GetFloat("SavedVal");

        if (Value == 0)
        {
            Value = 0.05f;
        }

        sliderBright.GetComponent<Slider>().value = Value;
    }

    void Update()
    {
        Value = sliderBright.GetComponent<Slider>().value;

        PlayerPrefs.SetFloat("SavedVal", Value);

        Btxt.text = Value.ToString("0.00");

        RenderSettings.ambientSkyColor = new Color(Value, Value, Value);
    }

    public void defaultBright()
    {
        sliderBright.GetComponent<Slider>().value = 0.1f;
    }
}



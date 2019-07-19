using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QualitySetting : MonoBehaviour {

    public int DefaultSet;
    public GameObject CurrentQualty;

    public void SetHigh() 
    {
        QualitySettings.SetQualityLevel(2);
        CurrentQualty.GetComponent<Text>().text = "Current Quality = High";

        DefaultSet = 2;
        PlayerPrefs.SetInt("SavedQuality", DefaultSet);
    }

    public void SetMed()
    {
        QualitySettings.SetQualityLevel(1);
        CurrentQualty.GetComponent<Text>().text = "Current Quality = Medium";

        DefaultSet = 1;
        PlayerPrefs.SetInt("SavedQuality", DefaultSet);
    }

    public void SetLow()
    {
        QualitySettings.SetQualityLevel(0);
        CurrentQualty.GetComponent<Text>().text = "Current Quality = Low";

        DefaultSet = 0;
        PlayerPrefs.SetInt("SavedQuality", DefaultSet);
    }

    void Start()
    {
        DefaultSet = PlayerPrefs.GetInt("SavedQuality");

        if(DefaultSet == 0) 
        {
            DefaultSet = 1;
        }

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("SavedQuality"));     
    }
}

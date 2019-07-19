using UnityEngine;
using System.Collections;

public class OptionsOn : MonoBehaviour {

    public GameObject brightMenu;


    public void OptionOn() 
    {
        gameObject.SetActive(true);
    }

    public void OptionOff()
    {
        gameObject.SetActive(false);
    }

    public void BrightOn() 
    {
        brightMenu.SetActive(true);  
    }

    public void BrightOff()
    {
        brightMenu.SetActive(false);
    }
}

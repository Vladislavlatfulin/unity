using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private Slider slider;
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Speed", 1);
    }

    public void Close ()
    {
        this.gameObject.SetActive(false);
    }

    public void Open ()
    {
        gameObject.SetActive(true);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log("Name: " + name);
    }

    public void OnSpeedValue(float speed)
    {
        Debug.Log("Speed: " + speed);
        PlayerPrefs.SetFloat("Speed", speed);
    }
}

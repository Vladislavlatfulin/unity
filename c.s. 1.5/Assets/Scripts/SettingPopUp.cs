using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopUp : MonoBehaviour
{
    [SerializeField] private Slider slider; 

    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Speed", 1);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void OnSubmitName (string name)
    {
        Debug.Log("Name: " + name);
    }

    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
        PlayerPrefs.SetFloat("Speed", speed);
    }
}

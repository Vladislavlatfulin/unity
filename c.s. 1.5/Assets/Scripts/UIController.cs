using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreLabel;
    [SerializeField] private SettingsMenu menu;

    void Start()
    {
        menu.Close();
    }

   

    public void OnOpenSettings ()
    {
        menu.Open();
    } 
}

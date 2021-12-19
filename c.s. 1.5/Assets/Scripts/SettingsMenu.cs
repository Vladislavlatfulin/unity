using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void Close ()
    {
        this.gameObject.SetActive(false);
    }

    public void Open ()
    {
        gameObject.SetActive(true);
    }
}

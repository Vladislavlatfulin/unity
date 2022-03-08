using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in doors)
        {
            item.SendMessage("Active");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var item in doors)
        {
            item.SendMessage("Deactive");
        }
    }
}

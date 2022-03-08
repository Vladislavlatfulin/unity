using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 closeDoorVector;

    private bool _isOpen;

    public void Operate()
    {
        if (_isOpen)
        {
            Vector3 pos = transform.position + closeDoorVector;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position - closeDoorVector;
            transform.position = pos;
        }

        _isOpen = !_isOpen;
    }


    public void Active()
    {
        if (!_isOpen)
        {
            Vector3 pos = transform.position + closeDoorVector;
            transform.position = pos;
            _isOpen = true;
        }
    }

    public void Deactive()
    {
        if (_isOpen)
        {
            Vector3 pos = transform.position - closeDoorVector;
            transform.position = pos;
            _isOpen = false;
        }
    }


}

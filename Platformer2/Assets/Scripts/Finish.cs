using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool _isActived = false;

    public void FinishLevel()
    {
        if (_isActived)
        {
            gameObject.SetActive(false);
        }
    }

    public void Activate()
    {
        _isActived = true;
    }
}

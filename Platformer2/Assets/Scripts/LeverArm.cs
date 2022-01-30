using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    private Finish _finish;

    private void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }

    public void ActivateLeverArm()
    {
        _finish.Activate();
    }
}

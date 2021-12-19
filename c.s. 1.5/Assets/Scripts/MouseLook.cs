using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;
    public float maxVer = 45.0f;
    public float minVer = -45.0f;
    private float _rotationX;

    public enum RotationAxes
    {
        mouseX = 0,
        mouseY = 1,
        mouseYandX = 2
    }
    public RotationAxes axes = RotationAxes.mouseX;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.mouseX)
        {
            transform.Rotate(0, sensitivityHor * Input.GetAxis("Mouse X"), 0);
        }
        else if (axes == RotationAxes.mouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVer, maxVer);
            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }

        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVer, maxVer);
            float delta = sensitivityHor * Input.GetAxis("Mouse X");
            float _rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float verticalMin = -45f;
    [SerializeField] private float verticalMax = 45f;
    [SerializeField] private float sensitivity = 9f;
    [SerializeField] RotationMouse axis = RotationMouse.rotationX;

    private float _rotationX = 0;

    private enum RotationMouse
    {
        rotationX = 0,
        rotationY = 1,
        rotationXandY = 2
    }

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    private void Update()
    {
        if (axis == RotationMouse.rotationX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }

        else if (axis == RotationMouse.rotationY)
        {
            _rotationX -= transform.localEulerAngles.y + Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, verticalMin, verticalMax);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        }

        else if (axis == RotationMouse.rotationXandY)
        {
            _rotationX -= transform.localEulerAngles.y + Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, verticalMin, verticalMax);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float rotationY = transform.localEulerAngles.x + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }




}

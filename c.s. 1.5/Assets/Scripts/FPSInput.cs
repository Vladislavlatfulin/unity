using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public const float baseSpeed = 6.0f;

    private CharacterController _characterController;
    private float _gravity = -9.8f;


    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDestroy()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 moving = new Vector3(deltaX, 0, deltaY);

        moving = Vector3.ClampMagnitude(moving, speed);
        moving.y = _gravity;
        moving *= Time.deltaTime;
        moving = transform.TransformDirection(moving);

        _characterController.Move(moving);

    }
}

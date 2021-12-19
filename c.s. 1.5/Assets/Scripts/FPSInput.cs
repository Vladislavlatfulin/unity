using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    public float speed = 5.0f;
    CharacterController character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = Input.GetAxis("Horizontal") * speed;
        float speedY = Input.GetAxis("Vertical") * speed;
        Vector3 moment = new Vector3(speedX, 0, speedY);
        moment = Vector3.ClampMagnitude(moment, speed);
        float graity = -9.8f;
        moment.y = graity;
        moment *= Time.deltaTime;
        moment = transform.TransformDirection(moment);
        character.Move(moment);

    }
}

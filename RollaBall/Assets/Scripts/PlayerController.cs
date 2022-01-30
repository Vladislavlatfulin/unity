using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject finishText;
 
    private Rigidbody _body;
    private int _count;
    private float _movementX;
    private float _movementY;
    
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _count = 0;
        SetTextCout();
        finishText.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        _body.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            ++_count;
            SetTextCout();
        }
    }

    private void SetTextCout()
    {
        countText.text = "Count text: " + _count.ToString();
        if (_count >= 12)
        {
            finishText.SetActive(true);
        }
    }
}

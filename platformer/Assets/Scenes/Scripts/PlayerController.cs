using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// распознавание поверхностей 
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 250f;
    [SerializeField] private float jumpForce = 12f;

    private Rigidbody2D _body;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        _animator.SetFloat("Speed", Mathf.Abs(deltaX));
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}

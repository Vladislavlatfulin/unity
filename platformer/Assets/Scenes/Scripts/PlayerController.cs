using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 250f;
    [SerializeField] private float jumpForce = 12f;

    private Rigidbody2D _body;
    private Animator _animator;
    private CapsuleCollider2D _capsule;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        _capsule = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
       
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        Vector3 max = _capsule.bounds.max;
        Vector3 min = _capsule.bounds.min;
        Vector3 corner1 = new Vector3(max.x, min.y - 0.1f);
        Vector3 corner2 = new Vector3(min.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);


        bool grounded = false;
        MovingPlatform platform = null;
        if (hit != null)
        {
            grounded = true;
            platform = hit.GetComponent<MovingPlatform>();
        }

        if (platform != null)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }

        _animator.SetFloat("Speed", Mathf.Abs(deltaX));

        Vector3 pScale = Vector3.one;

        if (platform != null)
        {
            pScale = platform.transform.localScale;
        }

        if (deltaX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX) / pScale.x, 1/pScale.y, 1);
        }



        _body.gravityScale = grounded && deltaX == 0 ? 0 : 1;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}

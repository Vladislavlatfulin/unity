using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 300f;
    private Rigidbody2D body;
    private Animator _anim;
    public float jumpForce = 12f;
    private CapsuleCollider2D _box;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {


        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        body.velocity = new Vector2(deltaX, body.velocity.y);

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);

        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }

        body.gravityScale = grounded && deltaX == 0 ? 0 : 1;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        _anim.SetFloat("Speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float jumpSpeed = 15.0f;
    [SerializeField] private float _rotSpeed = 10.0f;
    [SerializeField] private float _moveSpeed = 6.0f;
    [SerializeField] private float pushForce = 3f;

    private Animator _animator;
    private float _gravity = -9.8f;
    private float _terminalVelocity = -10f;
    private float _minFall = -1.5f;
   

    private float _vertSpeed;
    private CharacterController _characterController;
    private ControllerColliderHit _contact;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _vertSpeed = _minFall;

    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * _moveSpeed;
            movement.z = vertInput * _moveSpeed;
            movement = Vector3.ClampMagnitude(movement, _moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, _rotSpeed * Time.deltaTime);
        }

        

        bool hitGround = false;
        RaycastHit hit;
        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_characterController.height + _characterController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }

        _animator.SetFloat("Speed", movement.sqrMagnitude);
        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = _minFall;
                _animator.SetBool("Jump", false);
                
            }
        } else
        {
            _vertSpeed += _gravity * 5 * Time.deltaTime;
            if (_vertSpeed <= _terminalVelocity)
            {
                _vertSpeed = _terminalVelocity;
            }

            if (_contact != null)
            {
                _animator.SetBool("Jump", true);
            }

            if (_characterController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * _moveSpeed;
                }
                else
                {
                    movement += _contact.normal * _moveSpeed;
                }
            }
        }

        movement.y = _vertSpeed;


        movement *= Time.deltaTime;
        _characterController.Move(movement);

        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;

        Rigidbody body = hit.collider.attachedRigidbody;

        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}

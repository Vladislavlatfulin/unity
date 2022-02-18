using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    private Vector3 _finishPos = Vector3.zero;
    private Vector3 _startPos;
    private float _trackPercent = 0;
    private int _direction = 1;


    void Start()
    {
        _startPos = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        _trackPercent += speed * _direction * Time.deltaTime;
        float x = (_finishPos.x - _startPos.x) * _trackPercent + _startPos.x;
        float y = (_finishPos.y - _startPos.y) * _trackPercent + _startPos.y;
        transform.position = new Vector3(x, y, _startPos.z);

        if ((_direction == 1 && _trackPercent > 0.9f) || (_direction == -1 && _trackPercent < 0.1f))
        {
            _direction *= -1;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, _finishPos);
    }
}

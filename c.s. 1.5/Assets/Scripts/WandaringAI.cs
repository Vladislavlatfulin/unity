using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandaringAI : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float obstancleRange = 5f;
    [SerializeField] private GameObject fireBallPrefab;
    private GameObject _fireBall;
    public const float baseSpeed = 3.0f;

    private bool _alive = true;

    public bool Alive { get => _alive; }

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

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject player = hit.transform.gameObject;
                if (player.GetComponent<PlayerController>()) 
                {
                    if (_fireBall == null)
                    {
                        _fireBall = Instantiate(fireBallPrefab) as GameObject;
                        _fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireBall.transform.rotation = transform.rotation;
                       
                    }
                }
                else if (hit.distance < obstancleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
               
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
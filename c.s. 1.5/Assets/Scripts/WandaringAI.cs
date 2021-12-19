using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandaringAI : MonoBehaviour
{

    public float speed = 3.0f;
    public float obstacleRange = 5f;
    [SerializeField] GameObject fireBallPrevabs;
    private GameObject fireBall;
    private bool _alive;

    private void Start()
    {
        _alive = true;
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
                    if (fireBall == null)
                    {
                        fireBall = Instantiate(fireBallPrevabs) as GameObject;
                        fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireBall.transform.rotation = transform.rotation;
                    }
                    
                }
                else if (hit.distance < obstacleRange)
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

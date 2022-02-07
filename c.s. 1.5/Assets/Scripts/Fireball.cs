using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
   
    [SerializeField] private float speed = 5.0f;

    void Update()
    {
        transform.Translate(0, 0, speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Hurt(1);
        }
        Destroy(gameObject);
    }
}

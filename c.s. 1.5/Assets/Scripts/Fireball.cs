using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;

    // Update is called once per frame
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
        Destroy(this.gameObject);
    }
}

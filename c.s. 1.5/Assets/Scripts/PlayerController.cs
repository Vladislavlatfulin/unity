using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health = 10;

    public void Hurt (int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }
}

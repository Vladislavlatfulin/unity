using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void RediceHealth(float damage)
    {
        health -= damage;
        _animator.SetTrigger("TakeDamage");
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

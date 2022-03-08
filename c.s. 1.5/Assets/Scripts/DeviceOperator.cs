using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    [SerializeField] private float radius = 1.5f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Collider[] hitCollider = Physics.OverlapSphere(transform.position, radius);

            foreach (var collider in hitCollider)
            {
                Vector3 direction = collider.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.5f) 
                {
                    collider.SendMessage("Operate", SendMessageOptions.RequireReceiver);
                }
            }
        }
    }
}

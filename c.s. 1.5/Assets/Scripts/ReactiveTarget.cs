using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public void ReactToHit()
    {
        WandaringAI AI = GetComponent<WandaringAI>();
        if (AI != null)
        {
            AI.SetAlive(false);
        }

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(75, 0, 0);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

}

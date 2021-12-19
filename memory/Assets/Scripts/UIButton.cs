using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{

    [SerializeField] GameObject targerObgect;
    [SerializeField] string targetMassage;



    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.yellow;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.6f, 0.6f, 1);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        if (targerObgect != null)
        {
            targerObgect.SendMessage(targetMassage);
        }
    }
}

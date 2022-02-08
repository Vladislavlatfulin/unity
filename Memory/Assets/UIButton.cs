using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    [SerializeField] private Color color = Color.cyan;

    private void OnMouseEnter()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }

    private void OnMouseExit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(2.7f, 2.7f, 2.7f);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject backCard;
    [SerializeField] private Sprite image;
    [SerializeField] private SceneController controller;

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    private void OnMouseDown()
    {
        if (backCard.activeSelf && controller.CanReveal())
        {
            backCard.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        backCard.SetActive(true);
    }
}

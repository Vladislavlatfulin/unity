using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private SettingPopUp menu;
    private int _score;


    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void Start()
    {
        _score = 0;
        text.text = _score.ToString();

        menu.Close();
    }


    private void OnEnemyHit()
    {
        _score += 1;
        text.text = _score.ToString();
    }

    public void OpenSettings ()
    {
        menu.Open();
    }
}

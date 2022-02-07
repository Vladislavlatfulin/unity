using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCotroller : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs;
    private GameObject _enemy;
    private Vector3[] _positions = { new Vector3(12.43f, 0.5f, 11.40f),  new Vector3(-13.35f, 0.5f, 13.70f), new Vector3(-16.40f, 0.5f, -11.60f), new Vector3(11.50f, 0.5f, -13.8f)};
    

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefabs) as GameObject;
            int randomPosition = Random.Range(0, _positions.Length);
            _enemy.transform.position = _positions[randomPosition];
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle,0);
        }
    }
}

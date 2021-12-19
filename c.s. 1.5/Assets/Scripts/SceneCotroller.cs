using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCotroller : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs;
    private GameObject enemy;
    

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefabs) as GameObject;
            enemy.transform.position = new Vector3(0, 0.5f, 8.5f);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}

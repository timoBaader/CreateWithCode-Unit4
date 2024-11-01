using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update() { }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), 3, Random.Range(-8, 8));

        // To make sure the enemy doesnt spawn at or too near the players position
        if ((player.transform.position - enemy.transform.position).magnitude > 2)
        {
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
        }
        else
        {
            SpawnEnemy();
        }
    }
}

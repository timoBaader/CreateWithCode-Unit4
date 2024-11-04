using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject powerUp;
    public int enemyCount;
    public int enemyWave = 1;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            SpawnObject(enemy, enemyWave);
            enemyWave++;
            SpawnObject(powerUp, 1);
        }
    }

    private void SpawnObject<T>(T prefab, int Amount)
        where T : Object
    {
        int CreatedInstances = 0;

        while (CreatedInstances < Amount)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));

            // To make sure the enemy doesnt spawn at or too near the players position
            if ((player.transform.position - enemy.transform.position).magnitude > 2)
            {
                Instantiate(prefab, SpawnPosition, enemy.transform.rotation);
                CreatedInstances++;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject warningPrefab;
    public float spawnInterval = 3f;
    public float warningDuration = 1.5f;
    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = -warningDuration;
    }

    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnInterval)
        {
            float x = Random.Range(-8.9f, 8.9f);
            float y = Random.Range(-5f, 5f);
            StartCoroutine(SpawnWithWarning(new Vector2(x, y)));
            lastSpawnTime = Time.time;
        }
    }

    IEnumerator SpawnWithWarning(Vector2 spawnPos)
    {
        GameObject warning = Instantiate(warningPrefab, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(warningDuration);
        Destroy(warning);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
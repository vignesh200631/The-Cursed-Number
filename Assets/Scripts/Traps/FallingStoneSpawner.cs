
using UnityEngine;
using System.Collections;

public class FallingStoneSpawner : MonoBehaviour
{
    [Header("Stone Settings")]
    public GameObject stonePrefab;
    public Transform[] spawnPoints;

    [Header("Spawn Settings")]
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 2.5f;

    [Header("Stone Lifetime")]
    public float stoneLifetime = 8f;

    private void Start()
    {
        StartCoroutine(SpawnStones());
    }

    IEnumerator SpawnStones()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(delay);

            SpawnStone();
        }
    }

    void SpawnStone()
    {
        if (stonePrefab == null || spawnPoints.Length == 0)
            return;

        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject stone = Instantiate(stonePrefab, spawnPoint.position, spawnPoint.rotation);

        Destroy(stone, stoneLifetime);
    }
}

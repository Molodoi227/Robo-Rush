using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] protected Platform[] platforms;
    [SerializeField] protected Platform startPlatform;
    [SerializeField] protected int maxPlatformCount;
    [SerializeField] protected float platformLength;
    protected float spawnDirection;

    [SerializeField] protected GameObject coinPrefab;

    [SerializeField] protected float lineSpacing;

    protected Platform getRandomPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);
        return platforms[randomIndex];
    }

    protected virtual void SpawnPlatform(Platform spawnplatform)
    {
        Instantiate(spawnplatform, 
            transform.forward * spawnDirection,
            transform.rotation);
        spawnDirection += platformLength;
    }

    protected virtual void GeneratePlatforms()
    {
        SpawnPlatform(startPlatform);
        for (int i = 0; i < maxPlatformCount;  i++)
        {
            SpawnPlatform(getRandomPlatform());
        }
    }

    protected virtual GameObject SpawnCoin(float zPos)
    {
        // row = 1, 0, 1
        int row = Random.Range(0, 3) - 1;
        Vector3 pos = new(lineSpacing*row, 1f, zPos);
        return Instantiate(coinPrefab, pos, Quaternion.identity);
    }
}

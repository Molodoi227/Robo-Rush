using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfinitePlatformSpawner : PlatformSpawner
{
    private Transform playerTransform;
    private List<GameObject> spawnedPlatforms = new();

    private static readonly Platform pl = new();


    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMover>().transform;
        GeneratePlatforms();
    }

    protected override void SpawnPlatform(Platform spawnPlatform)
    {
        GameObject newPlatform = Instantiate(spawnPlatform,
            transform.forward * spawnDirection,
            transform.rotation).gameObject;
        spawnedPlatforms.Add(newPlatform);
        spawnDirection += platformLength;
    }
    

    private void RemovePlatform()
    {
        GameObject lost = spawnedPlatforms[0];
        spawnedPlatforms.RemoveAt(0);
        Destroy(lost);
    }


    private void Update()
    {
        if (playerTransform.position.z > spawnDirection - 
            (maxPlatformCount * platformLength))
        {
            SpawnPlatform(getRandomPlatform());
            SpawnCoin(spawnDirection);
            RemovePlatform();
        }
    }
}

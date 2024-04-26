using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<GameObject> tilePrefabs;
    public float spawnInterval = 1.0f;
    public float moveSpeed = 2.0f;
    public float despawnThreshold = -10.0f;

    private float nextSpawnTime;
    private List<GameObject> activeTiles = new List<GameObject>();
    private GameObject lastSpawnedTile;

    private void Start()
    {
        nextSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnTile();
            nextSpawnTime = Time.time + spawnInterval;
        }

        MoveTilesDown();
        DestroyOffscreenTiles();
    }

    private void SpawnTile()
    {
        GameObject randomPrefab = GetRandomPrefab();

        GameObject newTile = Instantiate(randomPrefab, transform.position, Quaternion.identity);

        if (activeTiles.Count > 0)
        {
            float previousTileY = activeTiles[activeTiles.Count - 1].transform.position.y;
            newTile.transform.position = new Vector3(transform.position.x, previousTileY + newTile.GetComponent<SpriteRenderer>().bounds.size.y, transform.position.z);
        }


        activeTiles.Add(newTile);

        lastSpawnedTile = newTile;
    }

    private GameObject GetRandomPrefab()
    {
        GameObject randomPrefab = tilePrefabs[Random.Range(0, tilePrefabs.Count)];

        if (randomPrefab == lastSpawnedTile)
        {
            randomPrefab = tilePrefabs[(tilePrefabs.IndexOf(randomPrefab) + 1) % tilePrefabs.Count];
        }

        return randomPrefab;
    }

    private void MoveTilesDown()
    {
        foreach (var tile in activeTiles)
        {
            tile.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    private void DestroyOffscreenTiles()
    {
        for (int i = activeTiles.Count - 1; i >= 0; i--)
        {
            if (activeTiles[i].transform.position.y < despawnThreshold)
            {
                Destroy(activeTiles[i]);
                activeTiles.RemoveAt(i);
            }
        }
    }
}

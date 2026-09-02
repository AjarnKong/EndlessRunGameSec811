using UnityEngine;
using System.Collections.Generic;

public class ScriptTileManager : MonoBehaviour
{
    public Transform player;
    public GameObject[] tilePrefabs;
    public float tileLength = 20f;
    public int tileOnScreen = 6;
    public int safeTile = 2;

    private float nextSpawnZ;
    private int tilesSpawned = 0;
    private readonly Queue<GameObject> activeTiles = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < tileOnScreen; i++) SpawnTile();
    }

    void Update()
    {
        float triggerZ = nextSpawnZ - (tileOnScreen - 1) * tileLength;

        if (player.position.z > triggerZ)
        {
            SpawnTile(); 
            RecycleOldestTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)], 
            new Vector3(0, 0, nextSpawnZ), Quaternion.identity);

        tile.GetComponent<ScriptTileHandler>()?.Populate(tilesSpawned >= safeTile);

        activeTiles.Enqueue(tile);

        nextSpawnZ += tileLength;
        tilesSpawned++;

    }

    void RecycleOldestTile()
    {
        if (activeTiles.Count > tileOnScreen) Destroy(activeTiles.Dequeue());
    }
}

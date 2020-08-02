using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private GameObject[] tiles;

    //private float speed = 5f;
    private bool spawned;

    void Start()
    {
        tiles = Resources.LoadAll<GameObject>("Tiles");
    }

    void Update()
    {
        transform.Translate(-GameManager.scenarySpeed * Time.deltaTime, 0f, 0f);

        if (!spawned && transform.position.x < 10f) SpawnTile();

        if (transform.position.x < -20f) Destroy(gameObject);
    }

    void SpawnTile()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + 14f, 0f, 0f);
        Debug.Log(tiles.Length);
        int tileNumber = Random.Range(0, tiles.Length);

        Instantiate(tiles[tileNumber], spawnPosition, Quaternion.identity);
        spawned = true;
    }
}

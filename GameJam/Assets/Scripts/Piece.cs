using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    //private GameObject[] tiles;

    //private float speed = 5f;
    private bool spawned;

    GameManager gameManager;
    void Start()
    {
        //tiles = Resources.LoadAll<GameObject>("Tiles");
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(-GameManager.scenarySpeed * Time.deltaTime, 0f, 0f);

        if (!spawned && transform.position.x < 5f) SpawnTile();

        if (transform.position.x < -20f) gameObject.SetActive(false);
    }

    void SpawnTile()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + 14f, 0f, 0f);
        //Debug.Log(tiles.Length);
        //int tileNumber = Random.Range(0, tiles.Length);

        //Instantiate(tiles[tileNumber], spawnPosition, Quaternion.identity);
        gameManager.ActivateRandomTile(spawnPosition);
        spawned = true;
    }
}

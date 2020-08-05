using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    private MenuManager menuManager;
    private Player player;
    private float timeToAddDistance;
    private int distance;

    public static float scenarySpeed = 5f;
    public static float impulseForce = 0f;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        if (!player.isDead)
        {
            timeToAddDistance -= Time.deltaTime;
            if (timeToAddDistance <= 0)
            {
                distance += 1;
                if (scenarySpeed < 20f) scenarySpeed += 0.1f;
                if (impulseForce < 750f) impulseForce += 10f;
                timeToAddDistance = 0.5f;
            }

            menuManager.SetDistance(distance);
        }
    }

    public void ActivateRandomTile(Vector3 transform)
    {
        List<GameObject> tilesUsable = new List<GameObject>();
        tilesUsable.Clear();

        for (int i = 0; i < tiles.Length; i++)
        {
            if (!tiles[i].activeSelf) tilesUsable.Add(tiles[i]);
        }

        int tileNumber = Random.Range(0, tilesUsable.Count);
        GameObject tile = tilesUsable[tileNumber];
        tile.SetActive(true);
        tile.transform.position = transform;
        Debug.Log(tile.name);
    }

    public static void StopGameplay()
    {
        scenarySpeed = 0f;
        impulseForce = 0f;
    }

    public static void SetDefaultValues()
    {
        scenarySpeed = 5f;
        impulseForce = 0f;
    }
}

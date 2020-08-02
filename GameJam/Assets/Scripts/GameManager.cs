using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

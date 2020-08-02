using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(0f, 0f, -speed * Time.deltaTime);
    }
}

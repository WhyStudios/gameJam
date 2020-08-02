using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    public Material material;
    public Color[] colors;

    private float smoothTime = 0.1f;
    private float changeTime = 2f;
    private int actualColor;

    void Start()
    {

    }
    
    void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0)
        {
            actualColor = (actualColor >= colors.Length - 1) ? actualColor = 0 : actualColor++;
            changeTime = 2f;
        }

        material.SetColor("_Emissive", colors[actualColor]);
        //material.color. = Color.Lerp(material.color, colors[actualColor], smoothTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp.Assets.Scripts;
using System;

public class SunLight : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] float leftIntensivity = 0f;
    [SerializeField] [Range(0, 100)] float rightIntensivity = 1f;
    [SerializeField] [Range(0, 100)] float topIntensivity = 0f;
    [SerializeField] [Range(0, 100)] float bottomIntensivity = 1f;
    [SerializeField] float intensivity = 5f;

    int width = 16;
    int hight = 9;

    float[,] sunIntensivity2D = new float[16,9];

    BinaryParameterStorage b;

    // Start is called before the first frame update
    void Start()
    {
        string s = "";
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < hight; ++j)
            {
                sunIntensivity2D[i, j] += (leftIntensivity / hight) * (hight - j);
                sunIntensivity2D[i, j] += (rightIntensivity / hight) * (j + 1);
                sunIntensivity2D[i, j] += (topIntensivity / width) * (i + 1);
                sunIntensivity2D[i, j] += (bottomIntensivity / width) * (width - i);
                
                s += (int)(sunIntensivity2D[i, j]) + " ";
            }
            s += '\n';
        }
        Debug.Log(s);

        BinaryParameterStorage b = new BinaryParameterStorage(10, 7, 7);
        Debug.Log(b.GetValue());
        Debug.Log(Convert.ToString(b.GetValue(), 2).PadLeft(10, '0'));

        Debug.Log("-->" + b.GetLeft() + "  |||  " + b.GetRight() + "<--");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSunEnergy(Vector2 coord)
    {
        float intensivity = 0;
        intensivity += (leftIntensivity / hight) * (hight - coord.y);
        intensivity += (rightIntensivity / hight) * (coord.y + 1);
        intensivity += (topIntensivity / width) * (width - coord.x);
        intensivity += (bottomIntensivity / width) * (coord.x + 1);

        return intensivity;
    }
}

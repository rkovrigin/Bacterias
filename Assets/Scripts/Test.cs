﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] SunLight sunlight;
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(text);
        //text.text = sunlight.GetSunEnergy(gameObject.transform.position).ToString();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toudai_hikari : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0));
    }
}

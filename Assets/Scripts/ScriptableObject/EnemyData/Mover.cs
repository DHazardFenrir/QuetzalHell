﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletDamage;
    [SerializeField]

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject,3.0f);
    }
}

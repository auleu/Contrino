using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{ 
    [SerializeField]
    private float despawnTime;

    private void Update()
    {
        Destroy(gameObject, despawnTime);
    }
}
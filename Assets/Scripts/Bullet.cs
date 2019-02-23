using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    [SerializeField]
    private GameObject debris;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject debrisInstance;
        debrisInstance = Instantiate(debris, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject,3.0f);
    }
}

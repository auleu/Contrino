using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private Transform barrelEnd;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float rateOfFire;
    [SerializeField]
    private int clipSize;

    public float recoil;

    private int clipInv;
    private bool allowFire = false;
    private float timeLastShot = 0.0f;

    void FixedUpdate()
    {
        float nextShot = timeLastShot + (1.0f / rateOfFire);
        float isShooting = Input.GetAxis("Fire1");
        Debug.Log(clipInv);

        if (isShooting > 0.5f)
        {
            if (clipInv == 0)
            {
                allowFire = false;
            }
            else
            {
                if (allowFire == true)
                {
                    Rigidbody bulletInstance;
                    bulletInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                    bulletInstance.AddForce(barrelEnd.up * bulletSpeed);
                    timeLastShot = Time.time;
                    allowFire = false;
                    clipInv--;
                }
                if (Time.time > nextShot)
                {
                    allowFire = true;
                }
            }
        }
    }
    private void Update()
    {
        if (clipInv < clipSize)
        {
            if (Input.GetButtonDown("Reload") == true)
            {
                clipInv = clipSize;
            }
        }
    }
}
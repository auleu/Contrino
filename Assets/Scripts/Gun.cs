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
    [SerializeField]
    private float spread;

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
            if (Time.time > nextShot)
            {
                allowFire = true;
            }
            if (clipInv == 0)
            {
                allowFire = false;
            }
            else
            {
                if (allowFire == true)
                {
                    Rigidbody bulletInstance;
                    bulletSpawner.Rotate(Random.Range(spread * -1f, spread), Random.Range(spread * -1f, spread), 0f, Space.Self);
                    bulletInstance = Instantiate(bullet, bulletSpawner.position, bulletSpawner.localRotation) as Rigidbody;
                    bulletInstance.AddForce(bulletSpawner.forward * bulletSpeed);
                    bulletSpawner.transform.LookAt(barrelEnd);
                    timeLastShot = Time.time;
                    allowFire = false;
                    clipInv--;
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
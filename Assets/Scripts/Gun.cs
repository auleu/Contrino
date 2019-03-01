using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private Transform bulletSpawner;
    [SerializeField]
    private Transform aimingAt;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float rateOfFire;
    [SerializeField]
    private int clipSize;
    [SerializeField]
    private float spread;
    [SerializeField]
    private float spreadDamp;

    private int clipInv;
    private bool allowFire = false;
    private float timeLastShot = 0.0f;
    private float cumulativeSpread;
    private Light reticle;

    void Start()
    {
        reticle = GetComponent<Light>();
        reticle.type = LightType.Spot;
    }

    void FixedUpdate()
    {
        float nextShot = timeLastShot + (1.0f / rateOfFire);
        float isShooting = Input.GetAxis("Fire1");
        cumulativeSpread = cumulativeSpread * (spreadDamp*0.01f);
        reticle.spotAngle = cumulativeSpread;
        if (cumulativeSpread < 0.5f)
        {
            cumulativeSpread = 0f;
        }
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
                    this.transform.Rotate(Random.Range(cumulativeSpread * -1f, cumulativeSpread), Random.Range(cumulativeSpread * -1f, cumulativeSpread), 0f, Space.Self);
                    bulletInstance = Instantiate(bullet, bulletSpawner.position, bulletSpawner.localRotation) as Rigidbody;
                    bulletInstance.AddForce(bulletSpawner.forward * bulletSpeed);
                    cumulativeSpread = cumulativeSpread + spread;
                    this.transform.LookAt(aimingAt);
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